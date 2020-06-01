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
using Mapper = PublicApi.DTO.V1.Mappers.DailyNutritionIntakeMapper;

namespace WebApplication.ApiControllers
{
    /// <summary>
    ///     Controller with full CRUD functionality for managing DailyNutritionIntake objects belonging to logged-in user.
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "user")]
    [ApiController]
    public class DailyNutritionIntakesController : ControllerBase
    {
        private readonly IAppBLL _bll;

        /// <summary>
        ///     Constructor for DailyNutritionIntakesController
        /// </summary>
        /// <param name="bll">App unit of work</param>
        public DailyNutritionIntakesController(IAppBLL bll)
        {
            _bll = bll;
        }

        /// <summary>
        ///     Get all DailyNutritionIntake objects belonging to logged-in user.
        /// </summary>
        /// <returns>Array of DailyNutritionIntake objects</returns>
        /// <response code="200">DailyNutritionIntakes were successfully retrieved from data source.</response>
        /// <response code="401">User is either not in correct role or not logged in.</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<DailyNutritionIntake>), 200)]
        [ProducesResponseType(401)]
        public async Task<ActionResult<IEnumerable<DailyNutritionIntake>>> GetDailyNutritionIntakes()
        {
            var dailyNutritionIntakes =
                await _bll.DailyNutritionIntakes.AllWithAppUserIdAsync(User.UserId());
            return Ok(dailyNutritionIntakes.Select(Mapper.MapBLLEntityToPublicDTO));
        }

        /// <summary>
        ///     Get DailyNutritionIntake with specified ID belonging to logged-in user.
        /// </summary>
        /// <param name="id">DailyNutritionIntake ID - GUID</param>
        /// <returns>DailyNutritionIntake with specified ID.</returns>
        /// <response code="200">DailyNutritionIntake was successfully found and retrieved from data source.</response>
        /// <response code="401">User is either not in correct role or not logged in.</response>
        /// <response code="404">BodyMeasurement with specified ID belonging to logged-in user was not found.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(DailyNutritionIntake), 200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<DailyNutritionIntake>> GetDailyNutritionIntake(Guid id)
        {
            var dailyNutritionIntake = await _bll.DailyNutritionIntakes.FindWithAppUserIdAsync(id, User.UserId());

            if (dailyNutritionIntake == null) return NotFound();
            return Ok(Mapper.MapBLLEntityToPublicDTO(dailyNutritionIntake));
        }

        /// <summary>
        ///     Update DailyNutritionIntake with specified ID stored inside data source.
        /// </summary>
        /// <param name="id">DailyNutritionIntake ID - GUID</param>
        /// <param name="dto">DailyNutritionIntakeEdit dto</param>
        /// <returns>
        ///     Updated DailyNutritionIntake with specified ID.
        /// </returns>
        /// <response code="200">
        ///     DailyNutritionIntake was successfully updated inside data source.
        /// </response>
        /// <response code="401"> User is either not in correct role or not logged in.</response>
        /// <response code="404">DailyNutritionIntake with specified ID belonging to logged-in user was not found</response>
        /// <response code="400">ID parameter does not match the ID of received DailyNutritionIntakeEdit</response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(DailyNutritionIntake), 200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> PutDailyNutritionIntake(Guid id, DailyNutritionIntakeEdit dto)
        {
            if (id != new Guid(dto.Id)) return BadRequest();
            var dailyNutritionIntake = await _bll.DailyNutritionIntakes.FindWithAppUserIdAsync(id, User.UserId());
            if (dailyNutritionIntake == null) return NotFound();
            _bll.DailyNutritionIntakes.Update(Mapper.MapPublicDTOFieldsToBLLEntity(dto, dailyNutritionIntake));
            await _bll.SaveChangesAsync();
            return Ok(Mapper.MapBLLEntityToPublicDTO(dailyNutritionIntake));
        }

        /// <summary>
        ///     Add new DailyNutritionIntake object with logged-in user's ID to data source.
        /// </summary>
        /// <param name="dto">DailyNutritionIntakeCreate dto</param>
        /// <returns>DailyNutritionIntake object created for logged-in user.</returns>
        /// <response code="200">DailyNutritionIntake object was successfully created for logged-in user.</response>
        /// <response code="401">User is either not in correct role or not logged in.</response>
        [ProducesResponseType(typeof(DailyNutritionIntake), 200)]
        [ProducesResponseType(401)]
        [HttpPost]
        public async Task<ActionResult<DailyNutritionIntake>> PostDailyNutritionIntake(DailyNutritionIntakeCreate dto)
        {
            var dailyNutritionIntake = Mapper.MapPublicDTOToBLLEntity(dto);
            dailyNutritionIntake.AppUserId = User.UserId();
            var result = _bll.DailyNutritionIntakes.Add(dailyNutritionIntake);
            await _bll.SaveChangesAsync();
            return Ok(Mapper.MapBLLEntityToPublicDTO(result));
        }

        /// <summary>
        ///     Remove DailyNutritionIntake with specified ID belonging to logged-in user from data source.
        /// </summary>
        /// <param name="id">DailyNutritionIntake object ID - GUID</param>
        /// <returns>DailyNutritionIntake object that was deleted.</returns>
        /// <response code="200">DailyNutritionIntake object was successfully deleted from data source.</response>
        /// <response code="404">
        ///     DailyNutritionIntake object with specified ID belonging to logged-in user was not found.
        /// </response>
        /// <response code="401">
        ///     User is not in correct role, not logged in or DailyNutritionIntake with specified ID does not belong to them.
        /// </response>
        [ProducesResponseType(typeof(DailyNutritionIntake), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<DailyNutritionIntake>> DeleteDailyNutritionIntake(Guid id)
        {
            var dailyNutritionIntake = await _bll.DailyNutritionIntakes.FindAsync(id);
            if (dailyNutritionIntake == null) return NotFound();
            _bll.DailyNutritionIntakes.Remove(dailyNutritionIntake);
            await _bll.SaveChangesAsync();
            return Ok(Mapper.MapBLLEntityToPublicDTO(dailyNutritionIntake));
        }
    }
}