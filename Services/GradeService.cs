using LR4_Baranov.Models;
using LR4_Baranov.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LR4_Baranov.Services
{
    public class GradeService : BaseService<Grade>, IGradeService
    {
        public GradeService(UniversityDbContext context) : base(context) { }
        public async Task<IEnumerable<object>> GetGradesForStudentAsync(int studentId)
        {
            return await dbSet
                .Where(g => g.StudentId == studentId)
                .Select(g => new
                {
                    g.GradeId,
                    g.Score,
                    g.DateAwarded,
                    CourseName = g.Class.Course.CourseName,
                    Semester = g.Class.Semester
                })
                .ToListAsync();
        }
    }
}
