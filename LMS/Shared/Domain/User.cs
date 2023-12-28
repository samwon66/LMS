using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Shared.Domain
{
    public enum UserType
    {
        student,
        teacher
    }

    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => FirstName + " " + LastName;
        public string Email { get; set; }
        public UserType UserType { get; set; }

        public Guid CourseId { get; set; }
        public Course Course { get; set; }
    }
}
