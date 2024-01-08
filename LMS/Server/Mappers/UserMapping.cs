using LMS.Server.Models;
using LMS.Server.Models.Domain;
using LMS.Server.Models.DTOs;
using LMS.Shared.Dtos;
using Microsoft.AspNetCore.Identity;

namespace LMS.Server.Mappers
{
    public static class CourseMapper
    {
        public static TeacherDTO MapToTeacherDTO(ApplicationUser teacher)
        {
            if (teacher == null)
                return null;

            return new TeacherDTO
            {
                Id = teacher.Id, // Assuming Id is a string
                UserName = teacher.UserName,
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                FullName = teacher.FullName,
                CourseId = teacher.CourseId,
                // Map other properties
            };
        }

        public static StudentDTO MapToStudentDTO(ApplicationUser user)
        {
            if (user == null)
                return null;

            return new StudentDTO
            {
                Id = user.Id, // Assuming Id is a string
                UserName = user.UserName,
                // Map other properties specific to StudentDTO
            };
        }
    }
}