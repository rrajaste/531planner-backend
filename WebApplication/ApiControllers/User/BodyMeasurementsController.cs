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
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "user")]
    [ApiController]
    public class BodyMeasurementsController : ControllerBase
    {
        private readonly IAppUnitOfWork _unitOfWork;

        public BodyMeasurementsController(IAppUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BodyMeasurementDto>>> GetBodyMeasurements()
        {
            var bodyMeasurements = await _unitOfWork.BodyMeasurements.AllWithAppUserIdAsync(User.UserId());
            return Ok(bodyMeasurements.Select(CreateNewDtoFromDomainEntity));
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<BodyMeasurementDto>> GetBodyMeasurement(Guid id)
        {
            var bodyMeasurement = await _unitOfWork.BodyMeasurements.FindWithAppUserIdAsync(id, User.UserId());
            
            if (bodyMeasurement == null)
            {
                return NotFound();
            }
            return Ok(CreateNewDtoFromDomainEntity(bodyMeasurement));
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBodyMeasurement(Guid id, BodyMeasurementEditDto dto)
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
        
        [HttpPost]
        public async Task<ActionResult<BodyMeasurement>> PostBodyMeasurement(BodyMeasurementCreateDto dto)
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
        [HttpDelete("{id}")]
        public async Task<ActionResult<BodyMeasurement>> DeleteBodyMeasurement(Guid id)
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
