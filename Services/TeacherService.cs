using LR4_Baranov.Models;
using LR4_Baranov.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LR4_Baranov.Services
{
    public class TeacherService : BaseService<Teacher>, ITeacherService
    {
        public TeacherService(UniversityDbContext context) : base(context) { }
        public async Task<object?> GetTeacherWithClassesAsync(int id)
        {
            return await dbSet
                .Where(t => t.TeacherId == id)
                .Select(t => new
                {
                    t.TeacherId,
                    t.FirstName,
                    t.LastName,
                    Classes = t.Classes.Select(c => new
                    {
                        c.ClassId,
                        c.Semester,
                        CourseName = c.Course.CourseName
                    })
                })
                .FirstOrDefaultAsync();
        }
    }
}
