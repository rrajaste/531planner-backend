using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PublicApi.DTO.V1;
using Mapper = PublicApi.DTO.V1.Mappers.BodyMeasurementMapper;

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
        public async Task<ActionResult<BodyMeasurement>> GetStatistics()
        {
            var userMeasurements = await _bll.BodyMeasurements.AllWithAppUserIdAsync(User.UserId());
            if (userMeasurements.ToList().Count < 2)
            {
                return BadRequest("User needs at least 2 records for statistic calculation");
            }
            var stats = await _bll.BodyMeasurements.GetUserStatisticsAsync(User.UserId());
            return Ok(Mapper.MapBLLEntityToPublicDTO(stats));
        }
    }
}

