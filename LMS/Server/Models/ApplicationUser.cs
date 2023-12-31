﻿using LMS.Server.Models.Domain;
using Microsoft.AspNetCore.Identity;

namespace LMS.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName => FirstName + " " + LastName;
        
        public Guid CourseId { get; set; }
        public Course Course { get; set; }
    }
}
