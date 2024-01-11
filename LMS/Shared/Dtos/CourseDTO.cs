using LMS.Server.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;



namespace LMS.Shared.Dtos
{
    public class CourseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }

        public TeacherDTO HeadTeacher { get; set; } 
        public ICollection<StudentDTO> Participants { get; set; } = new List<StudentDTO>();
        public ICollection<ModuleDTO> Modules { get; set; } = new List<ModuleDTO>();


        public CourseDTO()
        {
        }
        

        
    }

}
