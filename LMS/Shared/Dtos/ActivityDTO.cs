using LMS.Shared.Dtos;
using System;

namespace LMS.Shared.DTOs
{
    public class ActivityDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ActivityTypeDTO ActivityType { get; set; }
        public Guid ModuleId { get; set; }

        public ActivityDTO()
        {
            // Default constructor
        }

        public ActivityDTO(Guid id, string name, string description, DateTime startDate, DateTime endDate, ActivityTypeDTO activityType, Guid moduleId)
        {
            Id = id;
            Name = name;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            ActivityType = activityType;
            ModuleId = moduleId;
        }
    }

}