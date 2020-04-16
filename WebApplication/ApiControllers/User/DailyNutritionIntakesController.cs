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
using PublicApi.DTO.V1.DailyNutritionIntake;
using PublicApi.DTO.V1.UnitType;

namespace WebApplication.ApiControllers.User
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "user")]
    [ApiController]
    public class DailyNutritionIntakesController : ControllerBase
    {
        private readonly IAppUnitOfWork _unitOfWork;

        public DailyNutritionIntakesController(IAppUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DailyNutritionIntakeDto>>> GetDailyNutritionIntakes()
        {
            var dailyNutritionIntakes = 
                await _unitOfWork.DailyNutritionIntakes.AllWithAppUserIdAsync(User.UserId());
            return Ok(dailyNutritionIntakes.Select(CreateNewDtoFromDomainEntity));
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<DailyNutritionIntakeDto>> GetDailyNutritionIntake(Guid id)
        {
            var dailyNutritionIntake = await _unitOfWork.DailyNutritionIntakes.FindWithAppUserIdAsync(id, User.UserId());

            if (dailyNutritionIntake == null)
            {
                return NotFound();
            }
            return Ok(CreateNewDtoFromDomainEntity(dailyNutritionIntake));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDailyNutritionIntake(Guid id, DailyNutritionIntakeEditDto dto)
        {
            if (id != new Guid(dto.Id))
            {
                return BadRequest();
            }
            var dailyNutritionIntake = await _unitOfWork.DailyNutritionIntakes.FindWithAppUserIdAsync(id, User.UserId());
            if (dailyNutritionIntake == null)
            {
                return NotFound();
            }
            MapDtoToDomainEntity(dto, dailyNutritionIntake);
            _unitOfWork.DailyNutritionIntakes.Update(dailyNutritionIntake);
            await _unitOfWork.SaveChangesAsync();
            return Ok(CreateNewDtoFromDomainEntity(dailyNutritionIntake));
        }
        
        [HttpPost]
        public async Task<ActionResult<DailyNutritionIntake>> PostDailyNutritionIntake(DailyNutritionIntakeCreateDto dto)
        {
            var dailyNutritionIntake = new DailyNutritionIntake();
            MapDtoToDomainEntity(dto, dailyNutritionIntake);
            dailyNutritionIntake.AppUserId = User.UserId();
            _unitOfWork.DailyNutritionIntakes.Add(dailyNutritionIntake);
            await _unitOfWork.SaveChangesAsync();
            dailyNutritionIntake =
                await _unitOfWork.DailyNutritionIntakes.FindWithAppUserIdAsync(dailyNutritionIntake.Id, User.UserId());
            return Ok(CreateNewDtoFromDomainEntity(dailyNutritionIntake));
        }
        
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
            return Ok(CreateNewDtoFromDomainEntity(dailyNutritionIntake));
        }

        private static DailyNutritionIntakeDto CreateNewDtoFromDomainEntity(DailyNutritionIntake dailyNutritionIntake)
        {
            return new DailyNutritionIntakeDto()
            {
                Id = dailyNutritionIntake.Id.ToString(),
                Calories = dailyNutritionIntake.Calories,
                Carbohydrates =  dailyNutritionIntake.Carbohydrates,
                Fats = dailyNutritionIntake.Fats,
                Protein = dailyNutritionIntake.Protein,
                CreatedAt = dailyNutritionIntake.CreatedAt.ToString(CultureInfo.InvariantCulture),
                UnitType = new UnitTypeDto()
                {
                    Description = dailyNutritionIntake.UnitType.Description,
                    Name = dailyNutritionIntake.UnitType.Name,
                    Id = dailyNutritionIntake.UnitType.Id.ToString()
                }
            };
        }

        private static void MapDtoToDomainEntity<TDto>(TDto dto, DailyNutritionIntake domainEntity)
            where TDto : DailyNutritionIntakeCreateDto 
        {
            domainEntity.Calories = dto.Calories;
            domainEntity.Carbohydrates = dto.Carbohydrates;
            domainEntity.Fats = dto.Fats;
            domainEntity.Protein = dto.Protein;
            domainEntity.UnitTypeId = Guid.Parse(dto.UnitTypeId);
        }
    }
}
