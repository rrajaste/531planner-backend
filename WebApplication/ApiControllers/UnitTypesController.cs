using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Contracts.DAL.App;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mapper = PublicApi.DTO.V1.Mappers.UnitTypeMapper;

namespace WebApplication.ApiControllers
{
    /// <summary>
    /// Controller for getting Unit Type objects.
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "user, admin")]
    [ApiController]
    public class UnitTypesController : ControllerBase
    {
        
        private readonly IAppBLL _bll;

        /// <summary>
        /// Constructor for Unit Types controller.
        /// </summary>
        /// <param name="bll">App business logic layer.</param>
        public UnitTypesController(IAppBLL bll)
        {
            _bll = bll;
        }
        
        /// <summary>
        /// Get all UnitType objects in data source.
        /// </summary>
        /// <returns>List of UnitType objects.</returns>
        /// <response code="200">All UnitType objects were successfully retrieved from data source.</response>
        /// <response code="401">User is not logged in or does not have access to this resource.</response>
        [HttpGet]
        [ProducesResponseType( typeof(IEnumerable<PublicApi.DTO.V1.UnitType>), 200)]
        public async Task<ActionResult<IEnumerable<PublicApi.DTO.V1.UnitType>>> GetUnitTypes()
        {
            var unitTypes = await _bll.UnitTypes.AllAsync();
            return Ok(unitTypes.Select(Mapper.MapBLLEntityToPublicDTO));
        }

        /// <summary>
        /// Get UnitType object with specified ID.
        /// </summary>
        /// <param name="id">UnitType object ID - Guid</param>
        /// <returns>UnitType object with specified ID.</returns>
        /// <response code="200">Requested UnitType object was successfully retrieved from data source.</response>
        /// <response code="401">User is not logged in or does not have access to this resource.</response>
        /// <response code="404">UnitType object with specified ID not found.</response>
        [HttpGet("{id}")]
        [ProducesResponseType( typeof(PublicApi.DTO.V1.UnitType), 200)]
        [ProducesResponseType(401)]
        public async Task<ActionResult<PublicApi.DTO.V1.UnitType>> GetUnitType(Guid id)
        {
            var unitType = await _bll.UnitTypes.FindAsync(id);
            if (unitType == null)
            {
                return NotFound();
            }
            return Ok(Mapper.MapBLLEntityToPublicDTO(unitType));
        }
    }
}