using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.DTO;
using Contracts.BLL.App;
using Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PublicApi.DTO.V1;
using BodyMeasurementStatistics = BLL.App.DTO.BodyMeasurementStatistics;
using BodyMeasurementMapper = PublicApi.DTO.V1.Mappers.BodyMeasurementMapper;
using NutritionIntakeMapper = PublicApi.DTO.V1.Mappers.DailyNutritionIntakeMapper;

namespace WebApplication.ApiControllers
{
    
    /// <summary>
    /// Controller for getting statistics related to user progression.
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "user")]
    [ApiController]
    public class UserStatisticsController : ControllerBase
    {
        private readonly IAppBLL _bll;
        
        /// <summary>
        /// Constructor for UserStatisticsController.
        /// </summary>
        /// <param name="bll">App unit of work</param>
        public UserStatisticsController(IAppBLL bll)
        {
            _bll = bll;
        }

        /// <summary>
        /// Get body composition change statistics for logged-in user.
        /// </summary>
        /// <returns>Body composition statistics DTO</returns>
        /// <response code="200">Statistics were successfully calculated and returned.</response>
        /// <response code="401">User is not in correct role or not logged in.</response>
        /// <response code="400">User does not have at least 2 body measurement records needed to calculate statistics.</response>
        [HttpGet]
        [ActionName("BodyMeasurements")]
        [ProducesResponseType( typeof(IEnumerable<BodyMeasurementStatistics>), 200)]
        public async Task<ActionResult<BodyMeasurementStatistics>> GetBodyMeasurementStatistics()
        {
            var userMeasurements = await _bll.BodyMeasurements.AllWithAppUserIdAsync(User.UserId());
            if (userMeasurements.ToList().Count < 2)
            {
                return BadRequest("User needs at least 2 records for statistic calculation");
            }
            var stats = await _bll.BodyMeasurements.GetUserStatisticsAsync(User.UserId());
            return Ok(BodyMeasurementMapper.MapBLLEntityToPublicDTO(stats));
        }
        
        /// <summary>
        /// Get nutrition statistics for logged-in user.
        /// </summary>
        /// <returns>Calculated nutrition statistics</returns>
        /// <response code="200">Nutrition statistics were successfully calculated and returned.</response>
        /// <response code="401">User is not in correct role or not logged in.</response>
        /// <response code="400">User does not have at least 2 nutrition intake records needed to calculate statistics.</response>
        [HttpGet]
        [ActionName("DailyNutritionIntakes")]
        public async Task<ActionResult<PublicApi.DTO.V1.NutritionStatistics>> GetNutritionStatistics()
        {
            var userMeasurements = (await _bll.DailyNutritionIntakes.AllWithAppUserIdAsync(User.UserId())).ToList();
            if (userMeasurements.Count < 2)
            {
                return BadRequest("User needs at least 2 records for statistic calculation");
            }
            var stats = await _bll.DailyNutritionIntakes.GetNutritionStatisticsAsync(User.UserId(), userMeasurements);
            return Ok(NutritionIntakeMapper.MapBLLEntityToPublicDTO(stats));
        }
    }
}

