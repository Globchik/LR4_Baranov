using LR4_Baranov.Models;
using LR4_Baranov.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LR4_Baranov.Services
{
    public class ClassService : BaseService<Class>, IClassService
    {
        public ClassService(UniversityDbContext context) : base(context) { }
        public async Task<object?> GetClassWithDetailsAsync(int id)
        {
            return await dbSet
                .Where(c => c.ClassId == id)
                .Select(c => new
                {
                    c.ClassId,
                    c.Semester,
                    c.ScheduleInfo,
                    CourseName = c.Course.CourseName,
                    TeacherName = c.Teacher != null ? c.Teacher.FirstName + " " + c.Teacher.LastName : "No Teacher Assigned"
                })
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<object>> GetAllClassesWithDetailsAsync()
        {
            return await dbSet
                .Select(c => new
                {
                    c.ClassId,
                    c.Semester,
                    c.ScheduleInfo,
                    CourseName = c.Course.CourseName,
                    TeacherName = c.Teacher != null ? c.Teacher.FirstName + " " + c.Teacher.LastName : "No Teacher Assigned"
                })
                .ToListAsync();
        }
    }
}
