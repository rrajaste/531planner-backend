using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mapper = PublicApi.DTO.V1.Mappers.MuscleMapper;

namespace WebApplication.ApiControllers
{
    /// <summary>
    /// Controller for getting Muscle objects.
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "user")]
    [ApiController]
    public class MusclesController : ControllerBase
    {
        private readonly IAppBLL _bll;

        /// <summary>
        /// Constructor for Muscles controller.
        /// </summary>
        /// <param name="bll">App business logic layer.</param>
        public MusclesController(IAppBLL bll)
        {
            _bll = bll;
        }
        
        /// <summary>
        /// Get all Muscle objects in data source.
        /// </summary>
        /// <returns>List of Muscle objects.</returns>
        /// <response code="200">All Muscle objects were successfully retrieved from data source.</response>
        /// <response code="401">User is not logged in or does not have access to this resource.</response>
        [HttpGet]
        [ProducesResponseType( typeof(IEnumerable<PublicApi.DTO.V1.Muscle>), 200)]
        public async Task<ActionResult<IEnumerable<PublicApi.DTO.V1.Muscle>>> GetMuscles()
        {
            var muscles = await _bll.Muscles.AllAsync();
            return Ok(muscles.Select(m => Mapper.MapBLLEntityToPublicDTO(m)));
        }

        /// <summary>
        /// Get Muscle object with specified ID.
        /// </summary>
        /// <param name="id">Muscle object ID - Guid.</param>
        /// <returns>Muscle object with specified ID.</returns>
        /// <response code="200">Requested Muscle object was successfully retrieved from data source.</response>
        /// <response code="401">User is not logged in or does not have access to this resource.</response>
        /// <response code="404">Muscle object with specified ID not found.</response>
        [HttpGet("{id}")]
        [ProducesResponseType( typeof(PublicApi.DTO.V1.Muscle), 200)]
        public async Task<ActionResult<IEnumerable<PublicApi.DTO.V1.Muscle>>> GetMuscle(Guid id)
        {
            var muscle = await _bll.Muscles.FindAsync(id);

            if (muscle == null)
            {
                return NotFound();
            }

            return Ok(Mapper.MapBLLEntityToPublicDTO(muscle));
        }
    }
}