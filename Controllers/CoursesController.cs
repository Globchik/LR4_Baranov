using LR4_Baranov.Models;
using LR4_Baranov.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LR4_Baranov.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : BaseController<Course>
    {
        private readonly ICourseService courseService;

        public CoursesController(ICourseService service) : base(service)
        {
            courseService = service;
        }

        [HttpGet("{id}/classes")]
        public async Task<ActionResult<Course>> GetCourseWithClasses(int id)
        {
            var course = await courseService.GetCourseWithClassesAsync(id);

            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }
    }
}