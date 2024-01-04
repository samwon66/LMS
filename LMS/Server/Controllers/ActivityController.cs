using LMS.Server.Data;
using LMS.Shared.Dtos;
using LMS.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LMS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public ActivityController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/<ActivityController>
        [HttpGet]
        public ActionResult<IEnumerable<ActivityDTO>> GetActivities()
        {
            var activities = _dbContext.Activities
                .Select(a => new ActivityDTO
                {
                    Id = a.Id,
                    Name = a.Name,
                    Description = a.Description,
                    StartDate = a.StartDate,
                    EndDate = a.EndDate,
                    ActivityType = new ActivityTypeDTO
                    {
                        Id = a.ActivityType.Id,
                        Name = a.ActivityType.Name
                    },
                    ModuleId = a.ModuleId
                })
                .ToList();

            return Ok(activities);
        }

        // GET api/<ActivityController>/5
        [HttpGet("{id}")]
        public ActionResult<ActivityDTO> GetActivity(Guid id)
        {
            var activity = _dbContext.Activities
                .Where(a => a.Id == id)
                .Select(a => new ActivityDTO
                {
                    Id = a.Id,
                    Name = a.Name,
                    Description = a.Description,
                    StartDate = a.StartDate,
                    EndDate = a.EndDate,
                    ActivityType = new ActivityTypeDTO
                    {
                        Id = a.ActivityType.Id,
                        Name = a.ActivityType.Name
                    },
                    ModuleId = a.ModuleId
                })
                .FirstOrDefault();

            if (activity == null)
            {
                return NotFound();
            }

            return Ok(activity);
        }

        // POST api/<ActivityController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ActivityController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ActivityController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
