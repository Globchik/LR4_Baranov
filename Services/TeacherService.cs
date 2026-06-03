using LR4_Baranov.Models;
using LR4_Baranov.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LR4_Baranov.Services
{
    public class TeacherService : BaseService<Teacher>, ITeacherService
    {
        public TeacherService(UniversityDbContext context) : base(context) { }
        public async Task<Teacher?> GetTeacherWithClassesAsync(int id)
        {
            return await dbSet
                .Include(t => t.Classes)
                    .ThenInclude(c => c.Course)
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.TeacherId == id);
        }
    }
}
