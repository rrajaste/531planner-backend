using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain;
using PublicApi.DTO.V1;

namespace WebApplication.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BodyMeasurementsController : ControllerBase
    {
        private readonly IAppUnitOfWork _unitOfWork;

        public BodyMeasurementsController(IAppUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/BodyMeasurements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BodyMeasurementDto>>> GetBodyMeasurements()
        {
            var bodyMeasurements = await _unitOfWork.BodyMeasurements.AllAsync();
            return new ActionResult<IEnumerable<BodyMeasurementDto>>(bodyMeasurements.Select(CreateNewDtoFromDomainEntity));
        }

        // GET: api/BodyMeasurements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BodyMeasurementDto>> GetBodyMeasurement(Guid id)
        {
            var bodyMeasurement = await _unitOfWork.BodyMeasurements.FindAsync(id);

            if (bodyMeasurement == null)
            {
                return NotFound();
            }

            return CreateNewDtoFromDomainEntity(bodyMeasurement);
        }

        // PUT: api/BodyMeasurements/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBodyMeasurement(Guid id, BodyMeasurementDto bodyMeasurementDto)
        {
            if (id != Guid.Parse(bodyMeasurementDto.Id))
            {
                return BadRequest();
            }
            var bodyMeasurement = await _unitOfWork.BodyMeasurements.FindAsync(id);
            MapDtoToDomainEntity(bodyMeasurementDto, bodyMeasurement);
            _unitOfWork.BodyMeasurements.Add(bodyMeasurement);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/BodyMeasurements
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<BodyMeasurement>> PostBodyMeasurement(BodyMeasurementDto bodyMeasurementDto)
        {
            var bodyMeasurement = new BodyMeasurement();
            MapDtoToDomainEntity(bodyMeasurementDto, bodyMeasurement);
            _unitOfWork.BodyMeasurements.Add(bodyMeasurement);
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction("GetBodyMeasurement", new { id = bodyMeasurement.Id }, bodyMeasurement);
        }

        // DELETE: api/BodyMeasurements/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BodyMeasurement>> DeleteBodyMeasurement(Guid id)
        {
            var bodyMeasurement = await _unitOfWork.BodyMeasurements.FindAsync(id);
            if (bodyMeasurement == null)
            {
                return NotFound();
            }

            _unitOfWork.BodyMeasurements.Remove(bodyMeasurement);
            await _unitOfWork.SaveChangesAsync();

            return bodyMeasurement;
        }
        
        private static BodyMeasurementDto CreateNewDtoFromDomainEntity(BodyMeasurement bodyMeasurement)
        {
            return new BodyMeasurementDto()
            {
                Id = bodyMeasurement.Id.ToString(),
                UnitType = new UnitTypeDto()
                {
                    Description = bodyMeasurement.UnitType.Description,
                    Name = bodyMeasurement.UnitType.Name,
                    Id = bodyMeasurement.UnitType.Id.ToString()
                },
                Arm = bodyMeasurement.Arm,
                BodyFatPercentage = bodyMeasurement.BodyFatPercentage,
                Chest = bodyMeasurement.Chest,
                Height = bodyMeasurement.Height,
                Hip = bodyMeasurement.Hip,
                Waist = bodyMeasurement.Waist,
                Weight = bodyMeasurement.Weight
            };
        }

        private static void MapDtoToDomainEntity(BodyMeasurementDto dto, BodyMeasurement domainEntity)
        {
            domainEntity.Arm = dto.Arm;
            domainEntity.Chest = dto.Chest;
            domainEntity.Height = dto.Height;
            domainEntity.Hip = dto.Hip;
            domainEntity.Waist = dto.Waist;
            domainEntity.Weight = dto.Weight;
            domainEntity.BodyFatPercentage = dto.BodyFatPercentage;
            domainEntity.UnitTypeId = Guid.Parse(dto.UnitType.Id);
        }
    }
}
