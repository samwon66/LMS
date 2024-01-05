namespace LMS.Shared.Dtos
{
    public class TeacherDTO
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public Guid CourseId { get; set; }
    }
}