using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Shared.Dtos
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public bool IsTeacher { get; set; }
        public bool IsStudent { get; set; }
        public Guid CourseId { get; set; }
        public string CourseUrl { get; set; } // New property for course URL
        public string CourseName { get; set; } // Add this property for the course name
    }
}