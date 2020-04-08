using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App;
using Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PublicApi.DTO.V1.MuscleGroups;

namespace WebApplication.ApiControllers.User
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "user, admin")]
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

        private static MuscleGroupDto CreateNewDtoFromDomainEntity(MuscleGroup muscleGroup)
        {
            return new MuscleGroupDto()
            {
                Id = muscleGroup.Id.ToString(),
                Name = muscleGroup.Name,
                Description = muscleGroup.Description,
            };
        }
    }
}