using LR4_Baranov.Models;
using LR4_Baranov.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LR4_Baranov.Services
{
    public class GradeService : BaseService<Grade>, IGradeService
    {
        public GradeService(UniversityDbContext context) : base(context) { }
        public async Task<IEnumerable<Grade>> GetGradesForStudentAsync(int studentId)
        {
            return await dbSet
                .Include(g => g.Class)
                    .ThenInclude(c => c.Course)
                .Where(g => g.StudentId == studentId)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
