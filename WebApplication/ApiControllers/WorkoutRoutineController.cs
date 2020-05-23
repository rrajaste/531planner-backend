using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PublicApi.DTO.V1;
using RoutineMapper = PublicApi.DTO.V1.Mappers.WorkoutRoutineMapper;
using RoutineInfoMapper = PublicApi.DTO.V1.Mappers.RoutineGenerationInfoMapper;

namespace WebApplication.ApiControllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "user, admin")]
    [ApiController]
    public class WorkoutRoutinesController : ControllerBase
    {
        private readonly IAppBLL _bll;
        
        public WorkoutRoutinesController(IAppBLL bll)
        {
            _bll = bll;
        }
        
        [HttpGet]
        [ActionName("BaseRoutines")]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.V1.WorkoutRoutine>), 200)]
        public async Task<ActionResult<IEnumerable<PublicApi.DTO.V1.WorkoutRoutine>>> GetBaseWorkoutRoutines()
        {
            var workoutRoutines = await _bll.WorkoutRoutines.AllPublishedBaseRoutinesAsync();
            return Ok(workoutRoutines.Select(RoutineMapper.MapBLLEntityToPublicDTO));
        }
        [HttpPost]
        [ActionName("Generate")]
        [ProducesResponseType(typeof(PublicApi.DTO.V1.WorkoutRoutine), 200)]
        public async Task<ActionResult<IEnumerable<PublicApi.DTO.V1.WorkoutRoutine>>> GenerateNewRoutine(RoutineGenerationInfo dto)
        {
            if (await _bll.WorkoutRoutines.BaseRoutineWithIdExistsAsync(dto.BaseRoutineId))
            {
                var workoutRoutine = await _bll.WorkoutRoutines.FindFullRoutineWithIdAsync(dto.BaseRoutineId);
                if (!workoutRoutine.IsPublished)
                {
                    return BadRequest();
                }
                var newRoutineInfo = RoutineInfoMapper.MapPublicDTOToBLLEntity(dto, workoutRoutine);
                var generatedRoutine = _bll.WorkoutRoutines.GenerateNewFiveThreeOneRoutine(newRoutineInfo);

                _bll.WorkoutRoutines.Add(generatedRoutine);
                await _bll.SaveChangesAsync();
                
                var routineFromDatabase = await _bll.WorkoutRoutines.FindFullRoutineWithIdAsync(generatedRoutine.Id);
                return Ok(RoutineMapper.MapBLLEntityToPublicDTO(routineFromDatabase));
            }
            return BadRequest();
        }
    }
}