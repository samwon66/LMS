using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Shared.Dtos
{
    public class ActivityTypeDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ActivityTypeDTO()
        {
            // Default constructor
        }

        public ActivityTypeDTO(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
