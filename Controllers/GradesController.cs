using LR4_Baranov.Models;
using LR4_Baranov.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LR4_Baranov.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradesController : BaseController<Grade>
    {
        private readonly IGradeService gradeService;

        public GradesController(IGradeService service) : base(service)
        {
            gradeService = service;
        }

        [HttpGet("student/{studentId}")]
        public async Task<ActionResult<IEnumerable<Grade>>> GetGradesForStudent(int studentId)
        {
            var grades = await gradeService.GetGradesForStudentAsync(studentId);
            return Ok(grades);
        }
    }
}