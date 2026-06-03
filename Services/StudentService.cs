using LR4_Baranov.Models;
using LR4_Baranov.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LR4_Baranov.Services
{
    public class StudentService : BaseService<Student>, IStudentService
    {
        public StudentService(UniversityDbContext context) : base(context) { }
        public async Task<Student?> GetStudentWithGradesAsync(int id)
        {
            return await dbSet
                .Include(s => s.Grades)
                    .ThenInclude(g => g.Class)
                        .ThenInclude(c => c.Course)
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.StudentId == id);
        }
    }
}
