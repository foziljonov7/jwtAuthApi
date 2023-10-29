using jwtAuth.Data.Model;
using jwtAuthApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace jwtAuthApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthService authService;
        private readonly ILogger<AuthenticationController> logger;

        public AuthenticationController(IAuthService authService,
            ILogger<AuthenticationController> logger)
        {
            this.authService = authService;
            this.logger = logger;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid payload");

                var (status, message) = await authService.Login(model);

                if (status == 0)
                    return BadRequest(message);

                return Ok(message);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid payload");

                var (status, message) = await authService.Registeration(model, UserRoles.Admin);

                if (status == 0)
                    return BadRequest(message);

                return CreatedAtAction(nameof(Register), model);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }   
    }
}
