using LMS.Shared.Dtos;
using Microsoft.AspNetCore.Components;
using System.Text.Json;

namespace LMS.Client.Components
{
    public partial class CourseAdd
    {
    
    [Parameter]

        public Guid Id { get; set; }
        private CourseDTO course { get; set; } = new CourseDTO();

        protected override async Task OnInitializedAsync()
        {
            try
            {
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync($"https://localhost:7050/api/course/{Id}");

                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"API Response: {content}");

                response.EnsureSuccessStatusCode();

                course = JsonSerializer.Deserialize<CourseDTO>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching course data: {ex}");
                course = null;
            }
        }
    }
}


