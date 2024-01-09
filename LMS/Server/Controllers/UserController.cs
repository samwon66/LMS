using LMS.Server.Models;
using LMS.Server.Models.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LMS.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // Requires authentication
    public class RoleController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RoleController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet("CheckRole")]
        public async Task<IActionResult> CheckRole()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return Unauthorized();
            }

            var isTeacher = await _userManager.IsInRoleAsync(user, "Teacher");

            if (isTeacher)
            {
                return Ok("User is a Teacher");
            }
            else
            {
                return Ok("User is not a Teacher");
            }
        }
    }
}
