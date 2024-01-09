namespace LMS.Shared.Dtos
{
    public class ApplicationUserDTO
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public CourseDTO Course { get; set; }
        public List<ApplicationUserDTO> CourseParticipants { get; set; }
        public List<ModuleDTO> Modules { get; set; }
    }
}