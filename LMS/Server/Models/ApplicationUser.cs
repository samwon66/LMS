using LMS.Server.Models.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace LMS.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName => FirstName + " " + LastName;

        public Guid CourseId { get; set; }
        public Course Course { get; set; }

        // Additional properties as needed...

        // Check if the user is a teacher
        public async Task<bool> IsTeacherAsync(UserManager<ApplicationUser> userManager)
        {
            return await userManager.IsInRoleAsync(this, "Teacher");
        }

        // Check if the user is a student
        public async Task<bool> IsStudentAsync(UserManager<ApplicationUser> userManager)
        {
            return await userManager.IsInRoleAsync(this, "Student");
        }
    }
}