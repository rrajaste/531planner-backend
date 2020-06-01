using System.Threading.Tasks;
using Contracts.BLL.App;
using Domain.App.Constants;
using Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PublicApi.DTO.V1;
using Mapper = PublicApi.DTO.V1.Mappers.TrainingCycleMapper;

namespace WebApplication.ApiControllers
{
    /// <summary>
    /// Controller with functionality related to user training cycles.
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = AppRoles.User)]
    [ApiController]
    public class TrainingCyclesController : ControllerBase
    {
        private readonly IAppBLL _bll;
        
        /// <summary>
        /// Constructor for training cycle controller.
        /// </summary>
        /// <param name="bll">App business logic layer.</param>
        public TrainingCyclesController(IAppBLL bll)
        {
            _bll = bll;
        }
        
        /// <summary>
        /// Get currently active training cycle for logged-in user. 
        /// </summary>
        /// <returns>Full training cycle that is currently active for logged-in user.</returns>
        /// <response code="200">Training cycle belonging to logged-in user was successfully retrieved from data source.</response>
        /// <response code="404">Active training cycle not found, user does not have an active workout routine in data source.</response>
        [HttpGet]
        [ActionName("Active")]
        [ProducesResponseType(typeof(TrainingCycle), 200)]
        public async Task<ActionResult<TrainingCycle>> GetActiveTrainingCycle()
        {
            if (await _bll.WorkoutRoutines.UserWithIdHasActiveRoutineAsync(User.UserId()))
            {
                var cycle = await _bll.TrainingCycles.GetFullActiveCycleForUserWithIdAsync(User.UserId());
                var mappedCycle = Mapper.MapBLLEntityToPublicDTO(cycle);
                return Ok(mappedCycle);   
            }
            return NotFound();
        }
    }
}
