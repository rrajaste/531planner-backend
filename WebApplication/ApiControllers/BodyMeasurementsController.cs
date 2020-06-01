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
    ///     Controller with full CRUD functionality for managing BodyMeasurement objects belonging to logged-in user.
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]/")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "user")]
    [ApiController]
    public class BodyMeasurementsController : ControllerBase
    {
        private readonly IAppBLL _bll;

        /// <summary>
        ///     Constructor for BodyMeasurementsController.
        /// </summary>
        /// <param name="bll">App unit of work</param>
        public BodyMeasurementsController(IAppBLL bll)
        {
            _bll = bll;
        }

        /// <summary>
        ///     Get all BodyMeasurements belonging to logged-in user.
        /// </summary>
        /// <returns>Array of BodyMeasurements belonging to logged-in user</returns>
        /// <response code="200">BodyMeasurements belonging to logged-in user were successfully retrieved from data source.</response>
        /// <response code="401">User is either not in correct role or not logged in.</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<BodyMeasurement>), 200)]
        [ProducesResponseType(401)]
        public async Task<ActionResult<IEnumerable<BodyMeasurement>>> GetBodyMeasurements()
        {
            var bodyMeasurements = await _bll.BodyMeasurements.AllWithAppUserIdAsync(User.UserId());
            var orderedMeasurements = bodyMeasurements.OrderBy(
                measurement => measurement.LoggedAt);
            return Ok(orderedMeasurements.Select(Mapper.MapBLLEntityToPublicDTO));
        }

        /// <summary>
        ///     Get BodyMeasurement with specified ID belonging to logged-in user.
        /// </summary>
        /// <param name="id">BodyMeasurement ID - GUID</param>
        /// <returns>BodyMeasurementDto with data belonging to BodyMeasurement with specified ID.</returns>
        /// <response code="200">BodyMeasurement belonging to logged-in user was successfully found and retrieved from data source.</response>
        /// <response code="401">User is either not in correct role or not logged in.</response>
        /// <response code="404">BodyMeasurement with specified ID belonging to logged-in user was not found</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BodyMeasurement), 200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<BodyMeasurement>> GetBodyMeasurement(Guid id)
        {
            var bodyMeasurement = await _bll.BodyMeasurements.FindWithAppUserIdAsync(id, User.UserId());

            if (bodyMeasurement == null) return NotFound();
            return Ok(Mapper.MapBLLEntityToPublicDTO(bodyMeasurement));
        }

        /// <summary>
        ///     Update BodyMeasurement with specified ID stored inside data source.
        /// </summary>
        /// <param name="id">BodyMeasurement ID - GUID</param>
        /// <param name="dto">BodyMeasurementEditDto</param>
        /// <returns>
        ///     BodyMeasurementDto equivalent to what BodyMeasurement with specified ID now looks like in data source
        /// </returns>
        /// <response code="200">
        ///     Body measurement was successfully updated inside data source.
        /// </response>
        /// <response code="401"> User is either not in correct role or not logged in.</response>
        /// <response code="404">BodyMeasurement with specified ID belonging to logged-in user was not found</response>
        /// <response code="400">ID parameter does not match the ID of received BodyMeasurementEditDto</response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(BodyMeasurement), 200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<BodyMeasurement>> PutBodyMeasurement(Guid id, BodyMeasurementEdit dto)
        {
            if (id != Guid.Parse(dto.Id)) return BadRequest();
            var bodyMeasurement = await _bll.BodyMeasurements.FindWithAppUserIdAsync(id, User.UserId());
            if (bodyMeasurement == null) return NotFound();
            _bll.BodyMeasurements.Update(Mapper.MapPublicDTOFieldsToBLLEntity(dto, bodyMeasurement));
            await _bll.SaveChangesAsync();
            return Ok(Mapper.MapBLLEntityToPublicDTO(bodyMeasurement));
        }

        /// <summary>
        ///     Add new BodyMeasurement with logged-in user's ID to data source.
        /// </summary>
        /// <param name="dto">BodyMeasurementCreateDto</param>
        /// <returns>BodyMeasurementDto equivalent to what was created and stored in data source.</returns>
        /// <response code="200">Body measurement was successfully created and added into data source.</response>
        /// <response code="401">User is either not in correct role or not logged in.</response>
        [ProducesResponseType(typeof(BodyMeasurement), 200)]
        [ProducesResponseType(401)]
        [HttpPost]
        public async Task<ActionResult<BodyMeasurement>> PostBodyMeasurement(BodyMeasurementCreate dto)
        {
            var bodyMeasurement = Mapper.MapPublicDTOToBLLEntity(dto);
            bodyMeasurement.AppUserId = User.UserId();
            var result = _bll.BodyMeasurements.Add(bodyMeasurement);
            await _bll.SaveChangesAsync();
            return Ok(Mapper.MapBLLEntityToPublicDTO(result));
        }

        /// <summary>
        ///     Remove BodyMeasurement object belonging to logged-in user from data source.
        /// </summary>
        /// <param name="id">Body measurement ID - GUID</param>
        /// <returns>BodyMeasurement object that was deleted.</returns>
        /// <response code="200">BodyMeasurement object belonging to logged-in user was successfully deleted from data source.</response>
        /// <response code="404">BodyMeasurement object with specified ID object belonging to logged-in user was not found.</response>
        /// <response code="401">
        ///     User is not in correct role, not logged in or BodyMeasurement with specified ID does not belong to
        ///     them.
        /// </response>
        [ProducesResponseType(typeof(BodyMeasurement), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<BodyMeasurement>> DeleteBodyMeasurement(Guid id)
        {
            var bodyMeasurement = await _bll.BodyMeasurements.FindWithAppUserIdAsync(id, User.UserId());
            if (bodyMeasurement == null) return NotFound();
            _bll.BodyMeasurements.Remove(bodyMeasurement);
            await _bll.SaveChangesAsync();
            return Ok(Mapper.MapBLLEntityToPublicDTO(bodyMeasurement));
        }
    }
}