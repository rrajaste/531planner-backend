using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using PublicApi.DTO.V1;

namespace WebApplication.ApiControllers
{
    /// <summary>
    /// Controller for requesting backend culture info.
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]/")]
    public class CulturesController : ControllerBase
    {
        private readonly IOptions<RequestLocalizationOptions> _localizationOptions;
        /// <summary>
        /// Constructor for cultures controller.
        /// </summary>
        /// <param name="localizationOptions">Backend localization options.</param>
        public CulturesController(IOptions<RequestLocalizationOptions> localizationOptions)
        {
            _localizationOptions = localizationOptions;
        }
        
        /// <summary>
        /// Get list of supported cultures.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<Culture>> GetCultures()
        {
            var cultureItems = _localizationOptions.Value.SupportedUICultures
                .Select(c => new Culture()
                {
                    Code = c.Name,
                    Name = c.NativeName
                }).ToList();
            
            return Ok(cultureItems);
        } 
    }
}