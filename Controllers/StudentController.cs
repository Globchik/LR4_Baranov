using LR4_Baranov.Models;
using LR4_Baranov.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LR4_Baranov.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : BaseController<Student>
    {
        private readonly IStudentService studentService;

        public StudentsController(IStudentService service) : base(service)
        {
            studentService = service;
        }

        [HttpGet("{id}/grades")]
        public async Task<ActionResult<Student>> GetStudentWithGrades(int id)
        {
            var student = await studentService.GetStudentWithGradesAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }
    }
}