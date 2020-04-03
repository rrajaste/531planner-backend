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
    public class DailyNutritionIntakeController : ControllerBase
    {
        private readonly IAppUnitOfWork _unitOfWork;

        public DailyNutritionIntakeController(IAppUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/DailyNutritionIntake
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DailyNutritionIntakeDto>>> GetDailyNutritionIntakes()
        {
            var dailyNutritionIntakes = await _unitOfWork.DailyNutritionIntakes.AllAsync();
            return new ActionResult<IEnumerable<DailyNutritionIntakeDto>>(
                dailyNutritionIntakes.Select(CreateNewDtoFromDomainEntity)
            );
        }

        // GET: api/DailyNutritionIntake/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DailyNutritionIntakeDto>> GetDailyNutritionIntake(Guid id)
        {
            var dailyNutritionIntake = await _unitOfWork.DailyNutritionIntakes.FindAsync(id);

            if (dailyNutritionIntake == null)
            {
                return NotFound();
            }
            return CreateNewDtoFromDomainEntity(dailyNutritionIntake);
        }

        // PUT: api/DailyNutritionIntake/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDailyNutritionIntake(Guid id, DailyNutritionIntakeDto dailyNutritionIntakeDto)
        {
            if (id != dailyNutritionIntakeDto.Id)
            {
                return BadRequest();
            }

            var dailyNutritionIntake = await _unitOfWork.DailyNutritionIntakes.FindAsync(id);
            MapDtoToDomainEntity(dailyNutritionIntakeDto, dailyNutritionIntake);
            _unitOfWork.DailyNutritionIntakes.Update(dailyNutritionIntake);
            await _unitOfWork.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/DailyNutritionIntake
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<DailyNutritionIntake>> PostDailyNutritionIntake(DailyNutritionIntakeDto dailyNutritionIntakeDto)
        {
            
            var dailyNutritionIntake = new DailyNutritionIntake();
            MapDtoToDomainEntity(dailyNutritionIntakeDto, dailyNutritionIntake);
            _unitOfWork.DailyNutritionIntakes.Add(dailyNutritionIntake);
            await _unitOfWork.SaveChangesAsync();
            return CreatedAtAction("GetDailyNutritionIntake", new { id = dailyNutritionIntake.Id }, dailyNutritionIntake);
        }

        // DELETE: api/DailyNutritionIntake/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DailyNutritionIntake>> DeleteDailyNutritionIntake(Guid id)
        {
            var dailyNutritionIntake = await _unitOfWork.DailyNutritionIntakes.FindAsync(id);
            if (dailyNutritionIntake == null)
            {
                return NotFound();
            }

            _unitOfWork.DailyNutritionIntakes.Remove(dailyNutritionIntake);
            await _unitOfWork.SaveChangesAsync();
            return dailyNutritionIntake;
        }

        private static DailyNutritionIntakeDto CreateNewDtoFromDomainEntity(DailyNutritionIntake dailyNutritionIntake)
        {
            return new DailyNutritionIntakeDto()
            {
                Id = dailyNutritionIntake.Id,
                Calories = dailyNutritionIntake.Calories,
                Carbohydrates =  dailyNutritionIntake.Carbohydrates,
                Fats = dailyNutritionIntake.Fats,
                Protein = dailyNutritionIntake.Protein,
                UnitType = dailyNutritionIntake.UnitType
            };
        }

        private static void MapDtoToDomainEntity(DailyNutritionIntakeDto dto, DailyNutritionIntake domainEntity)
        {
            domainEntity.Calories = dto.Calories;
            domainEntity.Carbohydrates = dto.Carbohydrates;
            domainEntity.Fats = dto.Fats;
            domainEntity.Protein = dto.Protein;
            domainEntity.UnitType = dto.UnitType;
        }
    }
}
