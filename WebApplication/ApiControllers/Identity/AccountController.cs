using System.Threading.Tasks;
using Contracts.BLL.App;
using Domain.App.Identity;
using Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PublicApi.DTO.V1.Account;

namespace WebApplication.ApiControllers.Identity
{
    /// <summary>
    ///     Controller for managing user account related actions.
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    public class AccountController : ControllerBase
    {
        private readonly IAppBLL _bll;

        private readonly IConfiguration _configuration;
        private readonly ILogger<AccountController> _logger;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        /// <summary>
        ///     Constructor for AccountController
        /// </summary>
        /// <param name="configuration">WebApplication configuration.</param>
        /// <param name="userManager">WebApplication User Manager</param>
        /// <param name="signInManager">WebApplication Sign-in Manager</param>
        /// <param name="bll">Application business logic layer</param>
        /// <param name="logger">WebApplication logger</param>
        public AccountController(
            IConfiguration configuration,
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            IAppBLL bll,
            ILogger<AccountController> logger)

        {
            _configuration = configuration;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _bll = bll;
        }


        /// <summary>
        ///     Authenticate user credentials and return JSON Web Token for user.
        /// </summary>
        /// <param name="dto">DTO containing login information.</param>
        /// <returns>
        ///     Response object containing JSON Web Token for authenticated User
        /// </returns>
        /// <response code="200">
        ///     User was successfully authenticated and appropriate login response containing JSON Web Token was returned.
        /// </response>
        /// <response code="403">User authentication with provided credentials failed.</response>
        [ProducesResponseType(typeof(LoginResponse), 200)]
        [ProducesResponseType(403)]
        [HttpPost]
        public async Task<ActionResult<string>> Login([FromBody] Login dto)
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
                return Ok(new LoginResponse
                {
                    Token = jwt,
                    Status = "Logged in",
                    HasActiveRoutine = await _bll.WorkoutRoutines.UserWithIdHasActiveRoutineAsync(appUser.Id)
                });
            }

            _logger.LogInformation("Web-api login. Login attempt with incorrect password.");
            return StatusCode(403);
        }


        /// <summary>
        ///     Register new user with provided credentials into system.
        /// </summary>
        /// <param name="dto">DTO containing registration information.</param>
        /// <returns>Response object containing created user's User Name and Email</returns>
        /// <response code="200">User was successfully registered into the system.</response>
        /// <response code="403">User registration failed, see response message for details.</response>
        [HttpPost]
        [ProducesResponseType(typeof(RegisterResponse), 200)]
        [ProducesResponseType(403)]
        public async Task<ActionResult<string>> Register([FromBody] Register dto)
        {
            if (await _userManager.FindByEmailAsync(dto.Email) != null)
                return BadRequest(new {message = $"User with email {dto.Email} already exists"});

            var newUser = new AppUser
            {
                UserName = dto.UserName,
                Email = dto.Email
            };
            var result = await _userManager.CreateAsync(newUser, dto.Password);
            if (!result.Succeeded) return BadRequest();
            await _userManager.AddToRoleAsync(newUser, "user");
            return Ok(new RegisterResponse {Email = newUser.Email, UserName = newUser.UserName});
        }
    }
}