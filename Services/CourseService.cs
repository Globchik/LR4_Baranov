using LR4_Baranov.Models;
using LR4_Baranov.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LR4_Baranov.Services
{
    public class CourseService : BaseService<Course>, ICourseService
    {
        public CourseService(UniversityDbContext context) : base(context) { }
        public async Task<Course?> GetCourseWithClassesAsync(int id)
        {
            return await dbSet
                .Include(c => c.Classes)
                    .ThenInclude(cl => cl.Teacher)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.CourseId == id);
        }
    }
}
