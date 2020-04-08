using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App;
using Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PublicApi.DTO.V1.BaseDTOs.BaseDictionaryTypeDto;
using PublicApi.DTO.V1.UnitType;

namespace WebApplication.ApiControllers.Admin
{
    [Route("api/admin/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
    [ApiController]
    public class UnitTypesController : ControllerBase
    {
        private readonly IAppUnitOfWork _unitOfWork;

        public UnitTypesController(IAppUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnitTypeDetailsDto>>> GetUnitTypes()
        {
            var unitTypes = await _unitOfWork.UnitTypes.AllAsync();
            return Ok(unitTypes.Select(CreateNewDtoFromDomainEntity));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UnitTypeDetailsDto>> GetUnitType(Guid id)
        {
            var unitType = await _unitOfWork.UnitTypes.FindAsync(id);
            if (unitType == null)
            {
                return NotFound();
            }
            return Ok(CreateNewDtoFromDomainEntity(unitType));
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUnitType(Guid id, UnitTypeBaseEditDto dto)
        {
            if (id != Guid.Parse(dto.Id))
            {
                return BadRequest();
            }
            var unitType = await _unitOfWork.UnitTypes.FindAsync(id);
            if (unitType == null)
            {
                return NotFound();
            }
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
            where TDto : BaseCreateDto
        {
            unitType.Name = dto.Name;
            unitType.Description = dto.Description;
        }
    }
}
