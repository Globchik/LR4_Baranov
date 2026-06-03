using LR4_Baranov.Models;
using LR4_Baranov.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LR4_Baranov.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : BaseController<Teacher>
    {
        private readonly ITeacherService teacherService;

        public TeachersController(ITeacherService service) : base(service)
        {
            teacherService = service;
        }

        [HttpGet("{id}/classes")]
        public async Task<IActionResult> GetTeacherWithClasses(int id)
        {
            var teacher = await teacherService.GetTeacherWithClassesAsync(id);

            if (teacher == null)
            {
                return NotFound();
            }

            return Ok(teacher);
        }
    }
}