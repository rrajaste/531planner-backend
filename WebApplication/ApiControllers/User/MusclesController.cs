using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App;
using Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PublicApi.DTO.V1.Muscle;
using PublicApi.DTO.V1.MuscleGroups;

namespace WebApplication.ApiControllers.User
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "user, admin")]
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

        private static MuscleDto CreateNewDtoFromDomainEntity(Muscle muscle)
        {
            return new MuscleDto()
            {
                Id = muscle.Id.ToString(),
                Name = muscle.Name,
                Description = muscle.Description,
                MuscleGroup = new MuscleGroupDto()
                {
                    Id = muscle.MuscleGroup.Id.ToString(),
                    Name = muscle.MuscleGroup.Name,
                    Description = muscle.MuscleGroup.Description
                }
            };
        }
    }
}