using LMS.Server.Data;
using LMS.Server.Models.Domain;
using LMS.Shared.Dtos;
using LMS.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LMS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModuleController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public ModuleController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET: api/<ModuleController>
        [HttpGet]
        public ActionResult <IEnumerable<Module>> GetModules()
        {
            var modules = _dbContext.Modules.ToList();
            return Ok(modules);
        }

        // GET api/<ModuleController>/5
        [HttpGet("{id}")]
        public ActionResult<ModuleDTO> GetModule(Guid id)
        {
            var module = _dbContext.Modules
                .Where(m => m.Id == id)
                .Select(m => new ModuleDTO
                {
                    Id = m.Id,
                    Name = m.Name,
                    Description = m.Description,
                    StartDate = m.StartDate,
                    EndDate = m.EndDate,
                    Activities = m.Activities.Select(a => new ActivityDTO
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
                        }
                    }).ToList()
                })
                .FirstOrDefault();

            if (module == null)
            {
                return NotFound();
            }

            return Ok(module);
        }


        // POST api/<ModuleController>
        [HttpPost]
        public IActionResult PostModule([FromBody] Module module)
        {
           _dbContext.Modules.Add(module);
            _dbContext.SaveChanges();
            return CreatedAtAction(nameof(GetModule), new { id =  module.Id }, module);
        }

        // PUT api/<ModuleController>/5
        [HttpPut("{id}")]
        public IActionResult PutModule(Guid id, [FromBody] Module module)
        {
            if (id != module.Id)
            {
                return BadRequest();
            }

            _dbContext.Entry(module).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return NoContent();
        }

        // DELETE api/<ModuleController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteModule(Guid id)
        {
            var module = _dbContext.Modules.Find(id);

            if (module == null) { return NotFound(); }  

            _dbContext.Modules.Remove(module);
            _dbContext.SaveChanges();

            return NoContent(); 
        }
    }
}
