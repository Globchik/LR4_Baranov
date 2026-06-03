using LR4_Baranov.Models;
using LR4_Baranov.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LR4_Baranov.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController : BaseController<Class>
    {
        private readonly IClassService classService;

        public ClassesController(IClassService service) : base(service)
        {
            classService = service;
        }

        [HttpGet("details")]
        public async Task<ActionResult<IEnumerable<Class>>> GetAllClassesWithDetails()
        {
            var classes = await classService.GetAllClassesWithDetailsAsync();
            return Ok(classes);
        }

        [HttpGet("{id}/details")]
        public async Task<ActionResult<Class>> GetClassWithDetails(int id)
        {
            var classEntity = await classService.GetClassWithDetailsAsync(id);

            if (classEntity == null)
            {
                return NotFound();
            }

            return Ok(classEntity);
        }
    }
}