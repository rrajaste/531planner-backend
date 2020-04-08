using System.Threading.Tasks;
using Domain.Identity;
using Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace WebApplication.ApiControllers.Identity
{
    [ApiController]
    [Route("api/[controller]/[action]")]

    public class AccountController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ILogger<AccountController> _logger;
        
        public AccountController(IConfiguration configuration, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ILogger<AccountController> logger)
        {
            _configuration = configuration;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }


        [HttpPost]
        public async Task<ActionResult<string>> Login([FromBody] LoginDTO dto)
        {
            var appUser = await _userManager.FindByNameAsync(dto.UserName);
            if (appUser == null)
            {
                _logger.LogInformation($"Web-api login. User with User name {dto.UserName} not found");
                return StatusCode(403);
            }

            var result = await _signInManager.CheckPasswordSignInAsync(appUser, dto.Password, false);
            if (result.Succeeded)
            {
                var claimsPrincipal = await _signInManager.CreateUserPrincipalAsync(appUser);
                var jwt = IdentityExtensions.GenerateJWT(
                    claimsPrincipal.Claims,
                    _configuration.GetSection("JWT").GetValue<string>("SigningKey"),
                    _configuration.GetSection("JWT").GetValue<string>("Issuer"),
                    _configuration.GetSection("JWT").GetValue<int>("ExpireInDays")
                    );
                _logger.LogInformation($@"Token generated for user {dto.UserName}");
                return Ok(new {token = jwt, status = "Logged in"});
            } 
            _logger.LogInformation($"Web-api login. Login attempt with incorrect password.");
            return StatusCode(403);
        }

        [HttpPost]
        public async Task<ActionResult<string>> Register([FromBody] RegisterDTO dto)
        {
            return "{}";
        }

        public class LoginDTO
        {
            public string UserName { get; set; }
            public string Password { get; set; }
        }
        
        
        public class RegisterDTO
        {
            public string Email { get; set; }           
            public string UserName { get; set; }           
            public string Password { get; set; }           
        }
    }
}