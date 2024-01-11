using LMS.Server.Data;
using LMS.Server.Models.Domain;
using LMS.Shared.Dtos;
using LMS.Shared.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public ApplicationUserController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("{id}")]
        public ActionResult<ApplicationUserDTO> Get(string id)
        {
            var user = _dbContext.Users
                .Include(u => u.Course)
                    .ThenInclude(c => c.ApplicationUsers)
                .Include(u => u.Course)
                    .ThenInclude(c => c.Modules)
                    .ThenInclude(m => m.Activities)
                .Where(u => u.Id == id)
                .Select(u => new ApplicationUserDTO
                {
                    Id = u.Id,
                    FullName = u.FullName,
                    Email = u.Email,
                    Course = new CourseDTO
                    {
                        Id = u.Course.Id,
                        Name = u.Course.Name,
                        Description = u.Course.Description,
                        StartDate = u.Course.StartDate,
                        // Populate other CourseDTO fields as needed
                    },
                    CourseParticipants = u.Course.ApplicationUsers.Select(au => new ApplicationUserDTO
                    {
                        Id = au.Id,
                        FullName = au.FullName,
                        Email = au.Email
                        // Populate other ApplicationUserDTO fields for participants as needed
                    }).ToList(),
                    Modules = u.Course.Modules.Select(m => new ModuleDTO
                    {
                        Id = m.Id,
                        Name = m.Name,
                        Description = m.Description,
                        StartDate = m.StartDate,
                        EndDate = m.EndDate,
                        Activities = m.Activities.Select(a => new ActivityDTO
                        {
                            // Populate ActivityDTO fields as needed
                        }).ToList()
                    }).ToList(),
                })
                .FirstOrDefault();

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [Authorize] // Require authentication for this action
        [HttpPost("AddCourse")]
        public async Task<IActionResult> AddCourse([FromBody] CourseDTO courseDTO)
        {
            // Placeholder for adding a course
            // This action can only be accessed by authenticated users
            // Add your logic here

            // For demonstration purposes, let's assume the course is added successfully
            return Ok("Course added successfully");
        }

        [Authorize(Roles = "Teacher")] // Restrict access to teachers only
        [HttpPut("EditCourse/{courseId}")]
        public async Task<IActionResult> EditCourse(Guid courseId, [FromBody] CourseDTO courseDTO)
        {
            // Placeholder for editing a course
            // This action can only be accessed by users in the "Teacher" role
            // Add your logic here

            // For demonstration purposes, let's assume the course is edited successfully
            return Ok("Course edited successfully");
        }

        [Authorize(Roles = "Teacher")] // Restrict access to teachers only
        [HttpDelete("DeleteCourse/{courseId}")]
        public async Task<IActionResult> DeleteCourse(Guid courseId)
        {
            // Placeholder for deleting a course
            // This action can only be accessed by users in the "Teacher" role
            // Add your logic here

            // For demonstration purposes, let's assume the course is deleted successfully
            return Ok("Course deleted successfully");
        }
    
}
}