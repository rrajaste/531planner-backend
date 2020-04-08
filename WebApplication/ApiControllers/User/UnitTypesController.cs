using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App;
using Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PublicApi.DTO.V1.UnitType;

namespace WebApplication.ApiControllers.User
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "user, admin")]
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
        private static UnitTypeDto CreateNewDtoFromDomainEntity(UnitType unitType)
        {
            return new UnitTypeDto()
            {
                Id = unitType.Id.ToString(),
                Name = unitType.Name,
                Description = unitType.Description
            };
        }
    }
}