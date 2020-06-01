using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.DTO;
using Contracts.BLL.App;
using DAL.App.DTO;
using Domain.App.Constants;
using Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PublicApi.DTO.V1;
using PublicApi.DTO.V1.Mappers;
using RoutineMapper = PublicApi.DTO.V1.Mappers.WorkoutRoutineMapper;
using RoutineInfoMapper = PublicApi.DTO.V1.Mappers.RoutineGenerationInfoMapper;
using TrainingCycle = PublicApi.DTO.V1.TrainingCycle;

namespace WebApplication.ApiControllers
{
    /// <summary>
    ///     Controller with functionality related to user workout routine generation and modification.
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = AppRoles.User)]
    [ApiController]
    public class UserWorkoutRoutinesController : ControllerBase
    {
        private readonly IAppBLL _bll;

        /// <summary>
        ///     Constructor for User workout routine controller.
        /// </summary>
        /// <param name="bll">App business logic layer.</param>
        public UserWorkoutRoutinesController(IAppBLL bll)
        {
            _bll = bll;
        }

        /// <summary>
        ///     Generate and save into data source new workout routine for logged-in user based on posted generation info.
        /// </summary>
        /// <param name="dto">DTO containing routine generation information.</param>
        /// <returns>Full WorkoutRoutine that was generated and saved into data source.</returns>
        /// <response code="200">Workout routine was successfully generated and saved into data source.</response>
        /// <response code="400">Provided routine generation information was not correct.</response>
        [HttpPost]
        [ActionName("GenerateRoutine")]
        [ProducesResponseType(typeof(FullWorkoutRoutine), 200)]
        public async Task<ActionResult<FullWorkoutRoutine>> GenerateRoutine(RoutineGenerationInfo dto)
        {
            if (await _bll.WorkoutRoutines.UserWithIdHasActiveRoutineAsync(User.UserId()))
                return BadRequest(new {Message = "User already has an active workout routine"});

            if (await _bll.WorkoutRoutines.BaseRoutineWithIdExistsAsync(dto.BaseRoutineId))
            {
                var workoutRoutine = await _bll.WorkoutRoutines.FindFullRoutineWithIdAsync(dto.BaseRoutineId);
                if (!workoutRoutine.IsPublished) return BadRequest();

                if (dto.StartingDate < DateTime.Now.AddDays(-1))
                    return BadRequest(new {Message = "Routine starting date was more than 24 hours in the past"});

                if (dto.StartingDate > DateTime.Now.AddDays(14))
                    return BadRequest(new {Message = "Routine starting date was more than 14 days in the future"});

                var newRoutineInfo = RoutineInfoMapper.MapPublicDTOToBLLEntity(dto, workoutRoutine);
                var generatedRoutine = _bll.WorkoutRoutines.GenerateNewFiveThreeOneRoutine(newRoutineInfo);
                generatedRoutine.AppUserId = User.UserId();
                _bll.WorkoutRoutines.Add(generatedRoutine);
                var translations = await
                    _bll.WorkoutRoutines.AllTranslationsForWorkoutRoutineWithIdAsync(newRoutineInfo.BaseRoutine.Id);
                AddTranslationsToRoutine(generatedRoutine.Id, translations);
                await _bll.SaveChangesAsync();

                var routineFromDatabase = await _bll.WorkoutRoutines.FindFullRoutineWithIdAsync(generatedRoutine.Id);
                return Ok(RoutineMapper.MapBLLEntityToFullWorkoutRoutine(routineFromDatabase));
            }

            return BadRequest();
        }

        /// <summary>
        ///     Remove logged-in user's active workout routine from data source.
        /// </summary>
        /// <returns>Workout routine that was removed from data source</returns>
        /// <response code="200">Logged-in user's active workout routine was successfully removed from data source.</response>
        /// <response code="404">Logged-in user does not have an active workout routine.</response>
        [HttpPost]
        [ActionName("Delete")]
        [ProducesResponseType(typeof(BaseWorkoutRoutine), 200)]
        public async Task<ActionResult<IEnumerable<BaseWorkoutRoutine>>> DeleteRoutine()
        {
            if (await _bll.WorkoutRoutines.UserWithIdHasActiveRoutineAsync(User.UserId()))
            {
                var workoutRoutine = await _bll.WorkoutRoutines.ActiveRoutineForUserWithIdAsync(User.UserId());
                _bll.WorkoutRoutines.Remove(workoutRoutine);
                await _bll.SaveChangesAsync();

                return Ok(RoutineMapper.MapBLLEntityToBaseWorkoutRoutine(workoutRoutine));
            }

            return NotFound(new {message = "User does not have an active routine!"});
        }

        /// <summary>
        ///     Get active workout routine for logged-in user.
        /// </summary>
        /// <returns>Active workout routine belonging to logged-in user</returns>
        /// <response code="200">Active workout routine for logged-in user was successfully retrieved from data source.</response>
        /// <response code="404">Logged-in user does not have an active routine.</response>
        [HttpGet]
        [ActionName("Active")]
        [ProducesResponseType(typeof(BaseWorkoutRoutine), 200)]
        public async Task<ActionResult<IEnumerable<BaseWorkoutRoutine>>> GetActiveRoutine()
        {
            if (await _bll.WorkoutRoutines.UserWithIdHasActiveRoutineAsync(User.UserId()))
            {
                var workoutRoutine = await _bll.WorkoutRoutines.ActiveRoutineForUserWithIdAsync(User.UserId());
                return Ok(RoutineMapper.MapBLLEntityToBaseWorkoutRoutine(workoutRoutine));
            }

            return NotFound(new {message = "User does not have an active routine!"});
        }

        /// <summary>
        ///     Generate and save into data source a new training cycle for logged-in user's active routine.
        /// </summary>
        /// <param name="cycleInfo">New training cycle generation information.</param>
        /// <returns>Full training cycle that was generated and saved into data source.</returns>
        /// <response code="200">Training cycle was successfully generated and saved into data source.</response>
        /// <response code="404">Active workout routine for logged-in user with specified ID was not found.</response>
        [HttpPost]
        [ActionName("GenerateCycle")]
        [ProducesResponseType(typeof(TrainingCycle), 200)]
        public async Task<ActionResult<IEnumerable<TrainingCycle>>> AddNewCycleActiveRoutine(
            NewFiveThreeOneCycleInfo cycleInfo)
        {
            if (await _bll.WorkoutRoutines.UserWithIdHasActiveRoutineAsync(User.UserId()))
            {
                var baseRoutineId = (await _bll.WorkoutRoutines.ActiveRoutineForUserWithIdAsync(User.UserId())).Id;
                var baseRoutine = await _bll.WorkoutRoutines.FindFullRoutineWithIdAsync(baseRoutineId);
                var newCycle = _bll.WorkoutRoutines.GenerateNewCycleForFiveThreeOneRoutine(baseRoutine, cycleInfo);

                _bll.TrainingCycles.Add(newCycle);
                await _bll.SaveChangesAsync();

                var cycle = await _bll.TrainingCycles.GetFullActiveCycleForUserWithIdAsync(User.UserId());
                return Ok(TrainingCycleMapper.MapBLLEntityToPublicDTO(cycle));
            }

            return NotFound(new {message = "User does not have an active workout routine"});
        }

        private void AddTranslationsToRoutine(Guid generatedRoutineId,
            IEnumerable<WorkoutRoutineTranslation> translations)
        {
            var newTranslations = translations.Select(oldTranslation => new WorkoutRoutineTranslation
            {
                CultureCode = oldTranslation.CultureCode,
                Name = oldTranslation.Name,
                Description = oldTranslation.Description
            }).ToList();
            foreach (var translation in newTranslations)
                _bll.WorkoutRoutines.AddTranslationToWorkoutRoutine(translation, generatedRoutineId);
        }
    }
}