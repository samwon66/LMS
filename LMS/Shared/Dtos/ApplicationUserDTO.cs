using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Shared.Dtos
{
    public class ApplicationUserDTO
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public CourseDTO Course { get; set; }
        public List<ApplicationUserDTO> CourseParticipants { get; set; }
        public List<ModuleDTO> Modules { get; set; }
        public bool IsTeacher { get; set; } // Add this property
    }
}
