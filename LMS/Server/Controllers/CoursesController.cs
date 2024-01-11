﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using LMS.Server.Data;
//using LMS.Server.Models.Domain;
//using LMS.Shared.Dtos;
//using AutoMapper;
//using LMS.Server.Mappers;

//namespace LMS.Server.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class CoursesController : ControllerBase
//    {
//        private readonly ApplicationDbContext _context;
//        private readonly IMapper _mapper;


//        public CoursesController(ApplicationDbContext context, IMapper mapper)
//        {
//            _context = context;
//            _mapper = mapper;
//        }

//        // GET: api/Courses
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<CourseDTO>>> GetCourses()
//        {
//            var courses = await _context.Courses.ToListAsync();
//            var courseDtos = courses.Select(c => CourseMapper.MapToCourseDTO(c));

//            return Ok(courseDtos);
//        }



//        // GET: api/Courses/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<Course>> GetCourse(Guid id)
//        {
//          if (_context.Courses == null)
//          {
//              return NotFound();
//          }
//            var course = await _context.Courses.FindAsync(id);

//            if (course == null)
//            {
//                return NotFound();
//            }

//            return course;
//        }


//        // PUT: api/Courses/5
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutCourse(Guid id, Course course)
//        {
//            if (id != course.Id)
//            {
//                return BadRequest();
//            }

//            _context.Entry(course).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!CourseExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }



//        //POST: api/Courses
//        //To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPost]
//        public async Task<ActionResult<Course>> PostCourse(Course course)
//        {
//            if (_context.Courses == null)
//            {
//                return Problem("Entity set 'ApplicationDbContext.Courses'  is null.");
//            }
//            _context.Courses.Add(course);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction("GetCourse", new { id = course.Id }, course);
//        }



//        // DELETE: api/Courses/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteCourse(Guid id)
//        {
//            if (_context.Courses == null)
//            {
//                return NotFound();
//            }
//            var course = await _context.Courses.FindAsync(id);
//            if (course == null)
//            {
//                return NotFound();
//            }

//            _context.Courses.Remove(course);
//            await _context.SaveChangesAsync();

//            return NoContent();
//        }


//        private bool CourseExists(Guid id)
//        {
//            return (_context.Courses?.Any(e => e.Id == id)).GetValueOrDefault();
//        }
//    }
//}
