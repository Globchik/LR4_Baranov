using LR4_Baranov.Models;
using LR4_Baranov.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LR4_Baranov.Services
{
    public class ClassService : BaseService<Class>, IClassService
    {
        public ClassService(UniversityDbContext context) : base(context) { }
        public async Task<Class?> GetClassWithDetailsAsync(int id)
        {
            return await dbSet
                .Include(c => c.Course)
                .Include(c => c.Teacher)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.ClassId == id);
        }

        public async Task<IEnumerable<Class>> GetAllClassesWithDetailsAsync()
        {
            return await dbSet
                .Include(c => c.Course)
                .Include(c => c.Teacher)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
