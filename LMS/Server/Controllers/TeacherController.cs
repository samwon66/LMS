using LMS.Server.Data;
using LMS.Server.Models;
using LMS.Server.Models.Domain;
using LMS.Shared.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LMS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var userDTO = new UserDTO
            {
                Id = user.Id,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                FullName = user.FullName,
                CourseId = user.CourseId
            };

            // Check if the user is a teacher
            userDTO.IsTeacher = await user.IsTeacherAsync(_userManager);

            // Check if the user is a student
            userDTO.IsStudent = await user.IsStudentAsync(_userManager);

            // Set the course URL based on user role
            userDTO.CourseUrl = userDTO.IsTeacher
                ? $"/course/overview/{user.CourseId}"  // Replace with the actual URL for teacher course overview
                : $"/course/details/{user.CourseId}";   // Replace with the actual URL for student course details

            return Ok(userDTO);
        }
    }
}