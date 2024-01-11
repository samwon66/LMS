using LMS.Server.Models;
using LMS.Server.Models.Domain;
using LMS.Server.Models.DTOs;
using LMS.Shared.Dtos;
using Microsoft.AspNetCore.Identity;

namespace LMS.Server.Mappers
{
    public static class CourseMapper
    {
        public static CourseDTO MapToCourseDTO(Course course)
        {
            if (course == null)
                return null;

            return new CourseDTO
            {
                Id = course.Id,
                Name = course.Name,
                Description = course.Description,
              
            };
        }
    }
}