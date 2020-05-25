using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Domain.App.Enums;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoutineMapper = PublicApi.DTO.V1.Mappers.WorkoutRoutineMapper;
using RoutineInfoMapper = PublicApi.DTO.V1.Mappers.RoutineGenerationInfoMapper;

namespace WebApplication.ApiControllers
{
    /// <summary>
    /// Controller for requesting base routines. 
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = AppRoles.User)]
    [ApiController]
    public class BaseWorkoutRoutinesController : ControllerBase
    {
        private readonly IAppBLL _bll;
        
        /// <summary>
        /// Constructor for base routines controller.
        /// </summary>
        /// <param name="bll">App business logic layer</param>
        public BaseWorkoutRoutinesController(IAppBLL bll)
        {
            _bll = bll;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.V1.BaseWorkoutRoutine>), 200)]
        public async Task<ActionResult<IEnumerable<PublicApi.DTO.V1.BaseWorkoutRoutine>>> GetBaseWorkoutRoutines()
        {
            var workoutRoutines = await _bll.WorkoutRoutines.AllPublishedBaseRoutinesAsync();
            return Ok(workoutRoutines.Select(RoutineMapper.MapBLLEntityToBaseWorkoutRoutine));
        }
    }
}
