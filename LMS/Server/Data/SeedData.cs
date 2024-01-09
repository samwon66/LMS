using LMS.Server.Models.Domain;
using Microsoft.AspNetCore.Identity;


namespace LMS.Server.Data

{
    public class SeedData

    {
        private static ApplicationDbContext context;

        private static RoleManager<IdentityRole> roleManager = default!;

        private static UserManager<ApplicationUser> userManager = default!;

        public static async Task InitAsync(ApplicationDbContext _context, IServiceProvider services)

        {
            context = _context;
            if (context.Roles.Any()) return;

            roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

            var roleNames = new[] { "Student", "Teacher" };
            var studentEmail = "student@student.com";
            var teacherEmail = "teacher@teacher.com";

            await AddRolesAsync(roleNames);

            var courses = new List<Course>
            {
                new Course
                {   Id = Guid.NewGuid(),
                    Name = ".NET",
                    Description = "Description for .NET",
                    StartDate = DateTime.Now,
                    Modules = new List<Module>
                    {
                        new Module
                        {
                            Id = Guid.NewGuid(),
                            Name = "C#",
                            Description = "Description for C#",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(30),
                            Activities = new List<Activity>
                            {
                                new Activity
                                {
                                    Id = Guid.NewGuid(),
                                    Name = "C# fundamental",
                                    Description = "Description for C# fundamental",
                                    StartDate = DateTime.Now,
                                    EndDate = DateTime.Now.AddDays(14),
                                    ActivityType = new ActivityType
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "E-learning"
                                    }
                                },
                                // Add more activities as needed
                                new Activity
                                {
                                    Id = Guid.NewGuid(),
                                    Name = "Exercise",
                                    Description = "Description for Exercise",
                                    StartDate = DateTime.Now,
                                    EndDate = DateTime.Now.AddDays(7),
                                    ActivityType = new ActivityType
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "Exercise"
                                    }
                                }
                            }
                        },
                        // Add more modules as needed
                        new Module
                        {
                            Id = Guid.NewGuid(),
                            Name = "Frontend",
                            Description = "Description for Frontend",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(14),
                            Activities = new List<Activity>
                            {
                                new Activity
                                {
                                    Id = Guid.NewGuid(),
                                    Name = "HTML and CSS",
                                    Description = "Description for HTML and CSS",
                                    StartDate = DateTime.Now,
                                    EndDate = DateTime.Now.AddDays(7),
                                    ActivityType = new ActivityType
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "E-learning"
                                    }
                                },
                                // Add more activities as needed
                                new Activity
                                {
                                    Id = Guid.NewGuid(),
                                    Name = "JavaScript",
                                    Description = "Description for JavaScript",
                                    StartDate = DateTime.Now,
                                    EndDate = DateTime.Now.AddDays(7),
                                    ActivityType = new ActivityType
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = "E-learning"
                                    }
                                }
                            }

                    }
                }
                // Add more courses as needed
            }
            };


            foreach (var course in courses)
            {

                context.Courses.Add(course);

            }
            context.SaveChanges();

            Course c = context.Courses.FirstOrDefault();
            await AddAccountAsync(teacherEmail, "Anders", "Andersson", "Teacher", "P@55w.rd", c.Id, c);
            await AddAccountAsync(studentEmail, "Tony", "Olsson", "Student", "Pa55w.rd", c.Id, c);
        }

        private static async Task AddRolesAsync(string[] roleNames)
        {
            foreach (var roleName in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    var result = await roleManager.CreateAsync(new IdentityRole(roleName));

                    if(!result.Succeeded) throw new Exception(string.Join( "\n", result.Errors));
                }
            }
        }

        private static async Task AddAccountAsync(string email, string fName, string lName, string roleName, string password, Guid cId, Course course)
        {
            var found = await userManager.FindByEmailAsync(email);
            if (found != null) return;
            
            var user = new ApplicationUser
            {
                UserName = email,
                Email = email,
                FirstName = fName,
                LastName = lName,
                CourseId = cId, // Assuming CourseId is a property in ApplicationUser
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, roleName);
            }
            else
            {
                throw new Exception($"Failed to create user. Errors: {string.Join(", ", result.Errors)}");
            }

        }
    }
}






