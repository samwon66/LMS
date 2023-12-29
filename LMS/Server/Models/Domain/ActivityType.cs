using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Server.Models.Domain
{
    public class ActivityType
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Activity> Activities { get; set; } = new List<Activity>();
    }
}
