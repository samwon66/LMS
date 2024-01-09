using LMS.Server.Data;
using LMS.Server.Models.Domain;
using LMS.Server.Models.DTOs;
using LMS.Shared.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LMS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CourseController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public CourseController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("{id}")]
        public ActionResult<CourseDTO> GetCourse(Guid id)
        {
            var course = _dbContext.Courses
                .Include(c => c.Modules)
                .FirstOrDefault(c => c.Id == id);

            if (course == null)
            {
                return NotFound(); // Return a 404 Not Found response if the course is not found
            }

            var courseDTO = new CourseDTO
            {
                Id = course.Id,
                Name = course.Name,
                Description = course.Description,
                StartDate = course.StartDate,
                HeadTeacher = new TeacherDTO
                {
                    // Set properties based on your actual logic for getting the head teacher
                },
                Participants = new List<StudentDTO>(), // Initialize an empty list since Participants is not in the Course entity
                Modules = course.Modules.Select(m => new ModuleDTO
                {
                    // Map properties from Module entity to ModuleDTO
                    Id = m.Id,
                    Name = m.Name,
                    Description = m.Description,
                    StartDate = m.StartDate,
                    EndDate = m.EndDate,
                    // ... Map other properties
                }).ToList()
            };

            return Ok(courseDTO);
        }




        [HttpPost]
        [Authorize(Roles = "Teacher")]
        public IActionResult PostCourse([FromBody] CourseDTO courseDTO)
        {
            // Map CourseDTO to Course entityf
            var course = new Course
            {
                // Map properties from CourseDTO to Course entity
            };

            _dbContext.Courses.Add(course);
            _dbContext.SaveChanges();

            return CreatedAtAction(nameof(GetCourse), new { id = course.Id }, courseDTO);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Teacher")]
        public IActionResult PutCourse(Guid id, [FromBody] CourseDTO courseDTO)
        {
            var course = _dbContext.Courses.Find(id);

            if (course == null)
            {
                return NotFound();
            }

            // Map properties from CourseDTO to Course entity

            _dbContext.Entry(course).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Teacher")]
        public IActionResult DeleteCourse(Guid id)
        {
            var course = _dbContext.Courses.Find(id);

            if (course == null)
            {
                return NotFound();
            }

            _dbContext.Courses.Remove(course);
            _dbContext.SaveChanges();

            return NoContent();
        }
    }
}