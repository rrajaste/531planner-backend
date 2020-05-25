using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Mvc;
using PublicApi.DTO.V1;
using RoutineMapper = PublicApi.DTO.V1.Mappers.WorkoutRoutineMapper;
using RoutineInfoMapper = PublicApi.DTO.V1.Mappers.RoutineGenerationInfoMapper;

namespace WebApplication.ApiControllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "user, admin")]
    [ApiController]
    public class BaseWorkoutRoutinesController : ControllerBase
    {
        private readonly IAppBLL _bll;
        
        public BaseWorkoutRoutinesController(IAppBLL bll)
        {
            _bll = bll;
        }
        
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PublicApi.DTO.V1.BaseWorkoutRoutine>), 200)]
        public async Task<ActionResult<IEnumerable<PublicApi.DTO.V1.BaseWorkoutRoutine>>> GetBaseWorkoutRoutines()
        {
            var workoutRoutines = await _bll.WorkoutRoutines.AllPublishedBaseRoutinesAsync();
            return Ok(workoutRoutines.Select(RoutineMapper.MapBLLEntityToBaseWorkoutRoutine));
        }
    }
}
