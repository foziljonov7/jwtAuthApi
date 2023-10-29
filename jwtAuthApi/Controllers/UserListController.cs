using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace jwtAuthApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UserListController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var userList = await Task.FromResult(new string[] { "Abdulvosid", "Messi", "Ozil", "Nodirbek", "Davron" });
            return Ok(userList);
        }
    }
}
