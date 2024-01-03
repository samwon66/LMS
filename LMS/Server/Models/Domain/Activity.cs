using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Server.Models.Domain
{
    public class Activity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ActivityType ActivityType { get; set; } = new ActivityType();
        public Guid ActivtityTypeId { get; set; }
        public Guid ModuleId { get; set; }
        public Module Module { get; set; }

    }
}
