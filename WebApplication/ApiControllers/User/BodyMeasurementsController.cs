using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App;
using Domain;
using Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PublicApi.DTO.V1.BodyMeasurement;
using PublicApi.DTO.V1.UnitType;

namespace WebApplication.ApiControllers.User
{
    
    /// <summary>
    /// Controller with full CRUD functionality for managing BodyMeasurement objects belonging to logged-in user.
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "user")]
    [ApiController]
    public class BodyMeasurementsController : ControllerBase
    {
        private readonly IAppUnitOfWork _unitOfWork;
        
        /// <summary>
        /// Constructor for BodyMeasurementsController
        /// </summary>
        /// <param name="unitOfWork">App unit of work</param>
        public BodyMeasurementsController(IAppUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Get all BodyMeasurements belonging to logged-in user.
        /// </summary>
        /// <returns>Array of BodyMeasurementDtos</returns>
        /// <response code="200">BodyMeasurements were successfully retrieved from data source.</response>
        /// <response code="401">User is either not in correct role or not logged in.</response>
        [HttpGet]
        [ProducesResponseType( typeof(IEnumerable<BodyMeasurementDto>), 200)]
        [ProducesResponseType(401)]
        public async Task<ActionResult<IEnumerable<BodyMeasurementDto>>> GetBodyMeasurements()
        {
            var bodyMeasurements = await _unitOfWork.BodyMeasurements.AllWithAppUserIdAsync(User.UserId());
            return Ok(bodyMeasurements.Select(CreateNewDtoFromDomainEntity));
        }
        
        /// <summary>
        /// Get BodyMeasurement with specified ID.
        /// </summary>
        /// <param name="id">BodyMeasurement ID - GUID</param>
        /// <returns>BodyMeasurementDto with data belonging to BodyMeasurement with specified ID.</returns>
        /// <response code="200">BodyMeasurement was successfully found and retrieved from data source.</response>
        /// <response code="401">User is either not in correct role or not logged in.</response>
        /// <response code="404">BodyMeasurement with specified ID belonging to logged-in user was not found</response>
        [HttpGet("{id}")]
        [ProducesResponseType( typeof(BodyMeasurementDto), 200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<BodyMeasurementDto>> GetBodyMeasurement(Guid id)
        {
            var bodyMeasurement = await _unitOfWork.BodyMeasurements.FindWithAppUserIdAsync(id, User.UserId());
            
            if (bodyMeasurement == null)
            {
                return NotFound();
            }
            return Ok(CreateNewDtoFromDomainEntity(bodyMeasurement));
        }
        
        /// <summary>
        /// Update BodyMeasurement with specified ID stored inside data source.
        /// </summary>
        /// <param name="id">BodyMeasurement ID - GUID</param>
        /// <param name="dto">BodyMeasurementEditDto</param>
        /// <returns>
        /// BodyMeasurementDto equivalent to what BodyMeasurement with specified ID now looks like in data source
        /// </returns>
        /// <response code="200">
        /// Body measurement was successfully updated inside data source.</response>
        /// <response code="401"> User is either not in correct role or not logged in.</response>
        /// <response code="404">BodyMeasurement with specified ID belonging to logged-in user was not found</response>
        /// <response code="400">ID parameter does not match the ID of received BodyMeasurementEditDto</response>
        [HttpPut("{id}")]
        [ProducesResponseType( typeof(BodyMeasurementDto), 200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<BodyMeasurementDto>> PutBodyMeasurement(Guid id, BodyMeasurementEditDto dto)
        {
            if (id != Guid.Parse(dto.Id))
            {
                return BadRequest();
            }
            var bodyMeasurement = await _unitOfWork.BodyMeasurements.FindWithAppUserIdAsync(id, User.UserId());
            if (bodyMeasurement == null)
            {
                return NotFound();
            }
            
            MapDtoToDomainEntity(dto, bodyMeasurement);
            await _unitOfWork.SaveChangesAsync();
            return Ok(CreateNewDtoFromDomainEntity(bodyMeasurement));
        }
        
        /// <summary>
        /// Add new BodyMeasurement with logged-in user's ID to data source.
        /// </summary>
        /// <param name="dto">BodyMeasurementCreateDto</param>
        /// <returns>BodyMeasurementDto equivalent to what was created and stored in data source.</returns>
        /// <response code="200">Body measurement was successfully created and added into data source.</response>
        /// <response code="401">User is either not in correct role or not logged in.</response>
        [ProducesResponseType( typeof(BodyMeasurementDto), 200)]
        [ProducesResponseType(401)]
        [HttpPost]
        public async Task<ActionResult<BodyMeasurementDto>> PostBodyMeasurement(BodyMeasurementCreateDto dto)
        {
            var bodyMeasurement = new BodyMeasurement();
            MapDtoToDomainEntity(dto, bodyMeasurement);
            bodyMeasurement.AppUserId = User.UserId();
            _unitOfWork.BodyMeasurements.Add(bodyMeasurement);
            await _unitOfWork.SaveChangesAsync();
            bodyMeasurement = await _unitOfWork.BodyMeasurements.FindWithAppUserIdAsync(bodyMeasurement.Id, User.UserId());
            return Ok(CreateNewDtoFromDomainEntity(bodyMeasurement));
        }

        // DELETE: api/BodyMeasurements/5
        /// <summary>
        /// Remove BodyMeasurement from data source.
        /// </summary>
        /// <param name="id">Body measurement ID - GUID</param>
        /// <returns>BodyMeasurementDto equivalent to object that was deleted.</returns>
        /// <response code="200">Body measurement was successfully deleted from data source.</response>
        /// <response code="404">Body measurement with specified ID was not found.</response>
        /// <response code="401">User is not in correct role, not logged in or body measurement with specified ID does not belong to them.</response>
        [ProducesResponseType( typeof(BodyMeasurementDto), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<BodyMeasurementDto>> DeleteBodyMeasurement(Guid id)
        {
            var bodyMeasurement = await _unitOfWork.BodyMeasurements.FindWithAppUserIdAsync(id, User.UserId());
            if (bodyMeasurement == null)
            {
                return NotFound();
            }
            _unitOfWork.BodyMeasurements.Remove(bodyMeasurement);
            await _unitOfWork.SaveChangesAsync();
            return Ok(CreateNewDtoFromDomainEntity(bodyMeasurement));
        }

        private static BodyMeasurementDto CreateNewDtoFromDomainEntity(BodyMeasurement bodyMeasurement)
        {
            return new BodyMeasurementDto()
            {
                Id = bodyMeasurement.Id.ToString(),
                Weight = bodyMeasurement.Weight,
                Height = bodyMeasurement.Height,
                Chest = bodyMeasurement.Chest,
                Waist = bodyMeasurement.Waist,
                Arm = bodyMeasurement.Arm,
                Hip = bodyMeasurement.Hip,
                BodyFatPercentage = bodyMeasurement.BodyFatPercentage,
                CreatedAt = bodyMeasurement.CreatedAt.ToString(CultureInfo.InvariantCulture),
                UnitType = new UnitTypeDto()
                {
                    Description = bodyMeasurement.UnitType.Description,
                    Name = bodyMeasurement.UnitType.Name,
                    Id = bodyMeasurement.UnitType.Id.ToString()
                }
            };
        }
        
        private static void MapDtoToDomainEntity<TDto>(TDto dto, BodyMeasurement bodyMeasurement) 
            where TDto : BodyMeasurementCreateDto
        {
            bodyMeasurement.Weight = dto.Weight;
            bodyMeasurement.Height = dto.Height;
            bodyMeasurement.Chest = dto.Chest;
            bodyMeasurement.Waist = dto.Waist;
            bodyMeasurement.Arm = dto.Arm;
            bodyMeasurement.Hip = dto.Hip;
            bodyMeasurement.BodyFatPercentage = dto.BodyFatPercentage;
            bodyMeasurement.UnitTypeId = Guid.Parse(dto.UnitTypeId);
        }
    }
}
