using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Shared.Dtos
{
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


            public ICollection<TeacherDTO> ApplicationUsers { get; set; } = new List<TeacherDTO>();
            public ICollection<ModuleDTO> Modules { get; set; } = new List<ModuleDTO>();


            public CourseDTO()
            {
            }
            public CourseDTO(Guid id, string name, string description, DateTime startDate)
            {
                Id = id;
                Name = name;
                Description = description;
                StartDate = startDate;

            }

            public CourseDTO(Guid id, string name, string description, DateTime startDate, ICollection<TeacherDTO> applicationUsers, ICollection<ModuleDTO> modules)
            {
                Id = id;
                Name = name;
                Description = description;
                StartDate = startDate;
                ApplicationUsers = applicationUsers;
                Modules = modules;
            }


        }

    }

}
