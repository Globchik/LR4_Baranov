using LR4_Baranov.Models;
using LR4_Baranov.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LR4_Baranov.Services
{
    public class StudentService : BaseService<Student>, IStudentService
    {
        public StudentService(UniversityDbContext context) : base(context) { }
        public async Task<object?> GetStudentWithGradesAsync(int id)
        {
            return await dbSet
                .Where(s => s.StudentId == id)
                .Select(s => new
                {
                    s.StudentId,
                    s.FirstName,
                    s.LastName,
                    s.Email,
                    Grades = s.Grades.Select(g => new
                    {
                        g.GradeId,
                        g.Score,
                        g.DateAwarded,
                        CourseName = g.Class.Course.CourseName,
                        Semester = g.Class.Semester
                    })
                })
                .FirstOrDefaultAsync();
        }
    }
}
