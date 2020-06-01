using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PublicApi.DTO.V1;
using Mapper = PublicApi.DTO.V1.Mappers.MuscleGroupMapper;

namespace WebApplication.ApiControllers
{
    /// <summary>
    ///     Controller for getting Muscle Group objects.
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "user")]
    [ApiController]
    public class MuscleGroupsController : ControllerBase
    {
        private readonly IAppBLL _bll;

        /// <summary>
        ///     Constructor for Muscle Groups controller.
        /// </summary>
        /// <param name="bll">App business logic layer.</param>
        public MuscleGroupsController(IAppBLL bll)
        {
            _bll = bll;
        }

        /// <summary>
        ///     Get all MuscleGroup objects in data source.
        /// </summary>
        /// <returns>List of MuscleGroup objects.</returns>
        /// <response code="200">All MuscleGroup objects were successfully retrieved from data source.</response>
        /// <response code="401">User is not logged in or does not have access to this resource.</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MuscleGroup>), 200)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MuscleGroup>>> GetMuscleGroups()
        {
            var muscleGroups = await _bll.MuscleGroups.AllAsync();
            return Ok(muscleGroups.Select(Mapper.MapBLLEntityToPublicDTO));
        }

        /// <summary>
        ///     Get MuscleGroup object with specified ID.
        /// </summary>
        /// <param name="id">MuscleGroup object ID - Guid.</param>
        /// <returns>MuscleGroup object with specified ID.</returns>
        /// <response code="200">Requested MuscleGroup object was successfully retrieved from data source.</response>
        /// <response code="401">User is not logged in or does not have access to this resource.</response>
        /// <response code="404">MuscleGroup object with specified ID not found.</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<MuscleGroup>> GetMuscleGroup(Guid id)
        {
            var muscleGroup = await _bll.MuscleGroups.FindAsync(id);
            if (muscleGroup == null) return NotFound();
            return Ok(Mapper.MapBLLEntityToPublicDTO(muscleGroup));
        }
    }
}