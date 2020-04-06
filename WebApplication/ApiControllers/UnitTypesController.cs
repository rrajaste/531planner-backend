using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain;
using PublicApi.DTO.V1;
using PublicApi.DTO.V1.UnitType;

namespace WebApplication.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitTypesController : ControllerBase
    {
        private readonly IAppUnitOfWork _unitOfWork;

        public UnitTypesController(IAppUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnitTypeDto>>> GetUnitTypes()
        {
            var unitTypes = await _unitOfWork.UnitTypes.AllAsync();
            return Ok(unitTypes.Select(CreateNewDtoFromDomainEntity));
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<UnitTypeDto>> GetUnitType(Guid id)
        {
            var unitType = await _unitOfWork.UnitTypes.FindAsync(id);
            if (unitType == null)
            {
                return NotFound();
            }
            return Ok(CreateNewDtoFromDomainEntity(unitType));
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUnitType(Guid id, UnitTypeEditDto dto)
        {
            if (id != Guid.Parse(dto.Id))
            {
                return BadRequest();
            }
            var unitType = await _unitOfWork.UnitTypes.FindAsync(id);
            MapDtoToDomainEntity(dto, unitType);
            await _unitOfWork.SaveChangesAsync();
            return NoContent();
        }
        
        [HttpPost]
        public async Task<ActionResult<UnitType>> PostUnitType(UnitTypeCreateDto dto)
        {
            var unitType = new UnitType();
            MapDtoToDomainEntity(dto, unitType);
            _unitOfWork.UnitTypes.Add(unitType);
            await _unitOfWork.SaveChangesAsync();
            return CreatedAtAction("GetUnitType", new {id = unitType.Id}, unitType);
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<UnitType>> DeleteUnitType(Guid id)
        {
            var unitType = await _unitOfWork.UnitTypes.FindAsync(id);
            if (unitType == null)
            {
                return NotFound();
            }
            _unitOfWork.UnitTypes.Remove(unitType);
            await _unitOfWork.SaveChangesAsync();
            return Ok(unitType);
        }

        private static UnitTypeDetailsDto CreateNewDtoFromDomainEntity(UnitType unitType)
        {
            return new UnitTypeDetailsDto()
            {
                Id = unitType.Id.ToString(),
                Name = unitType.Name,
                Description = unitType.Description,
                CreatedAt = unitType.CreatedAt.ToString(CultureInfo.InvariantCulture)
            };
        }
        
        private static void MapDtoToDomainEntity<TDto>(TDto dto, UnitType unitType) 
            where TDto : UnitTypeCreateDto
        {
            unitType.Name = unitType.Name;
            unitType.Description = unitType.Description;
        }
    }
}
