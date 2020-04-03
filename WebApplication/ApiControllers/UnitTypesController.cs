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
    public class UnitTypesController : ControllerBase
    {
        private readonly IAppUnitOfWork _unitOfWork;

        public UnitTypesController(IAppUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/UnitTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnitTypeDto>>> GetUnitTypes()
        {
            var unitTypes = await _unitOfWork.UnitTypes.AllAsync();
            return new ActionResult<IEnumerable<UnitTypeDto>>(unitTypes.Select(CreateNewDtoFromDomainEntity));
        }

        // GET: api/UnitTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UnitTypeDto>> GetUnitType(Guid id)
        {
            var unitType = await _unitOfWork.UnitTypes.FindAsync(id);

            if (unitType == null)
            {
                return NotFound();
            }

            return CreateNewDtoFromDomainEntity(unitType);
        }

        // PUT: api/UnitTypes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUnitType(Guid id, UnitTypeDto unitTypeDto)
        {
            if (id != unitTypeDto.Id)
            {
                return BadRequest();
            }

            var unitType = await _unitOfWork.UnitTypes.FindAsync(id);
            MapDtoFieldsToDomainEntityFields(unitTypeDto, unitType);
            await _unitOfWork.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/UnitTypes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<UnitType>> PostUnitType(UnitTypeDto unitTypeDto)
        {
            var unitType = new UnitType();
            MapDtoFieldsToDomainEntityFields(unitTypeDto, unitType);
            _unitOfWork.UnitTypes.Add(unitType);
            await _unitOfWork.SaveChangesAsync();
            return CreatedAtAction("GetUnitType", new {id = unitType.Id}, unitTypeDto);
        }

        // DELETE: api/UnitTypes/5
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

            return unitType;
        }

        private static UnitTypeDto CreateNewDtoFromDomainEntity(UnitType unitType)
        {
            return new UnitTypeDto()
            {
                Id = unitType.Id,
                Name = unitType.Name,
                Description = unitType.Description
            };
        }

        private static void MapDtoFieldsToDomainEntityFields(UnitTypeDto dto, UnitType domainEntity)
        {
            domainEntity.Description = dto.Description;
            domainEntity.Name = dto.Name;
        }
    }
}
