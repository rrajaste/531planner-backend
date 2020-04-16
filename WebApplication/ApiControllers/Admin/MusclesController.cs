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
using PublicApi.DTO.V1.Muscle;
using PublicApi.DTO.V1.MuscleGroups;

namespace WebApplication.ApiControllers.Admin
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/admin/[controller]")]

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
    [ApiController]
    public class MusclesController : ControllerBase
    {
        private readonly IAppUnitOfWork _unitOfWork;

        public MusclesController(IAppUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MuscleDetailsDto>>> GetMuscles()
        {
            var muscles = await _unitOfWork.Muscles.AllAsync();
            return Ok(muscles.Select(CreateNewDtoFromDomainEntity));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MuscleDetailsDto>> GetMuscle(Guid id)
        {
            var muscle = await _unitOfWork.Muscles.FindAsync(id);

            if (muscle == null)
            {
                return NotFound();
            }
            return Ok(CreateNewDtoFromDomainEntity(muscle));
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMuscle(Guid id, MuscleEditDto dto)
        {
            if (id != Guid.Parse(dto.Id))
            {
                return BadRequest();
            }
            var muscle = await _unitOfWork.Muscles.FindAsync(id);
            if (muscle == null)
            {
                return NotFound();
            }
            MapDtoToDomainEntity(dto, muscle);
            await _unitOfWork.SaveChangesAsync();
            return NoContent();
        }
        
        [HttpPost]
        public async Task<ActionResult<Muscle>> PostMuscle(MuscleCreateDto dto)
        {
            var muscle = new Muscle();
            MapDtoToDomainEntity(dto, muscle);
            _unitOfWork.Muscles.Add(muscle);
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction("GetMuscle", new { id = muscle.Id }, muscle);
        }

        // DELETE: api/Muscles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Muscle>> DeleteMuscle(Guid id)
        {
            var muscle = await _unitOfWork.Muscles.FindAsync(id);
            if (muscle == null)
            {
                return NotFound();
            }
            _unitOfWork.Muscles.Remove(muscle);
            await _unitOfWork.SaveChangesAsync();
            return Ok();
        }
        private static MuscleDetailsDto CreateNewDtoFromDomainEntity(Muscle muscle)
        {
            return new MuscleDetailsDto()
            {
                Id = muscle.Id.ToString(),
                Name = muscle.Name,
                Description = muscle.Description,
                CreatedAt = muscle.CreatedAt.ToString(CultureInfo.InvariantCulture),
                MuscleGroup = new MuscleGroupDto()
                {
                    Id = muscle.MuscleGroup.Id.ToString(),
                    Name = muscle.MuscleGroup.Name,
                    Description = muscle.MuscleGroup.Description
                }
            };
        }
            
        private static void MapDtoToDomainEntity<TDto>(TDto dto, Muscle muscle) 
                where TDto : MuscleCreateDto
        {
            muscle.Name = dto.Name;
            muscle.Description = dto.Description;
            muscle.MuscleGroupId = Guid.Parse(dto.MuscleGroupId);
        }
    }
}
