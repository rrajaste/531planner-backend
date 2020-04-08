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
using PublicApi.DTO.V1.MuscleGroups;

namespace WebApplication.ApiControllers.Admin
{
    [Route("api/admin/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
    [ApiController]
    public class MuscleGroupsController : ControllerBase
    {
        private readonly IAppUnitOfWork _unitOfWork;

        public MuscleGroupsController(IAppUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/MuscleGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MuscleGroupDetailsDto>>> GetMuscleGroups()
        {
            var muscleGroups = await _unitOfWork.MuscleGroups.AllAsync();
            return Ok(muscleGroups.Select(CreateNewDtoFromDomainEntity));
        }

        // GET: api/MuscleGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MuscleGroupDetailsDto>> GetMuscleGroup(Guid id)
        {
            var muscleGroup = await _unitOfWork.MuscleGroups.FindAsync(id);
            if (muscleGroup == null)
            {
                return NotFound();
            }
            
            return Ok(CreateNewDtoFromDomainEntity(muscleGroup));
        }

        // PUT: api/MuscleGroups/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMuscleGroup(Guid id, MuscleGroupEditDto dto)
        {
            if (id != Guid.Parse(dto.Id))
            {
                return BadRequest();
            }
            
            var muscleGroup = await _unitOfWork.MuscleGroups.FindAsync(id);
            if (muscleGroup == null)
            {
                return NotFound();
            }
            MapDtoToDomainEntity(dto, muscleGroup);
            await _unitOfWork.SaveChangesAsync();
            return NoContent();
        }
        
        [HttpPost]
        public async Task<ActionResult<MuscleGroup>> PostMuscleGroup(MuscleGroup muscleGroup)
        {
            _unitOfWork.MuscleGroups.Add(muscleGroup);
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction("GetMuscleGroup", new { id = muscleGroup.Id }, muscleGroup);
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<MuscleGroup>> DeleteMuscleGroup(Guid id)
        {
            var muscleGroup = await _unitOfWork.MuscleGroups.FindAsync(id);
            if (muscleGroup == null)
            {
                return NotFound();
            }

            _unitOfWork.MuscleGroups.Remove(muscleGroup);
            await _unitOfWork.SaveChangesAsync();

            return muscleGroup;
        }
        
        private static MuscleGroupDetailsDto CreateNewDtoFromDomainEntity(MuscleGroup muscleGroup)
        {
            return new MuscleGroupDetailsDto()
            {
                Id = muscleGroup.Id.ToString(),
                Name = muscleGroup.Name,
                Description = muscleGroup.Description,
                CreatedAt = muscleGroup.CreatedAt.ToString(CultureInfo.InvariantCulture),
            };
        }
            
        private static void MapDtoToDomainEntity<TDto>(TDto dto, MuscleGroup muscleGroup) 
            where TDto : MuscleGroupCreateDto
        {
            muscleGroup.Name = dto.Name;
            muscleGroup.Description = dto.Description;
        }
    }
}
