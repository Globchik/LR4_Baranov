using LR4_Baranov.Models;
using LR4_Baranov.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LR4_Baranov.Services
{
    public class CourseService : BaseService<Course>, ICourseService
    {
        public CourseService(UniversityDbContext context) : base(context) { }
        public async Task<object?> GetCourseWithClassesAsync(int id)
        {
            return await dbSet
                .Where(c => c.CourseId == id)
                .Select(c => new
                {
                    c.CourseId,
                    c.CourseName,
                    c.Credits,
                    Classes = c.Classes.Select(cl => new
                    {
                        cl.ClassId,
                        cl.Semester,
                        cl.ScheduleInfo,
                        TeacherName = cl.Teacher != null ? cl.Teacher.FirstName + " " + cl.Teacher.LastName : "Unassigned"
                    })
                })
                .FirstOrDefaultAsync();
        }
    }
}
