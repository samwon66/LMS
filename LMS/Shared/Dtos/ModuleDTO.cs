using LMS.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Shared.Dtos
{
    public class ModuleDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<ActivityDTO> Activities { get; set; }

        public ModuleDTO()
        {
            // Default constructor
        }

        public ModuleDTO(Guid id, string name, string description, DateTime startDate, DateTime endDate, ICollection<ActivityDTO> activities)
        {
            Id = id;
            Name = name;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            Activities = activities;
        }
    }
}
