using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App;
using Microsoft.AspNetCore.Mvc;
using Domain;
using PublicApi.DTO.V1;
using PublicApi.DTO.V1.BodyMeasurement;

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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BodyMeasurementDto>>> GetBodyMeasurements()
        {
            var bodyMeasurements = await _unitOfWork.BodyMeasurements.AllAsync();
            return Ok(bodyMeasurements.Select(CreateNewDtoFromDomainEntity));
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<BodyMeasurementDto>> GetBodyMeasurement(Guid id)
        {
            var bodyMeasurement = await _unitOfWork.BodyMeasurements.FindAsync(id);
            
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
            var bodyMeasurement = await _unitOfWork.BodyMeasurements.FindAsync(id);
            MapDtoToDomainEntity(dto, bodyMeasurement);
            _unitOfWork.BodyMeasurements.Add(bodyMeasurement);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/BodyMeasurements
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<BodyMeasurement>> PostBodyMeasurement(BodyMeasurementCreateDto dto)
        {
            var bodyMeasurement = new BodyMeasurement();
            MapDtoToDomainEntity(dto, bodyMeasurement);
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

            return Ok(bodyMeasurement);
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
                CreatedAt = bodyMeasurement.CreatedAt.ToString(CultureInfo.InvariantCulture)
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
        }
    }
}
