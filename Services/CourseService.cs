using LR4_Baranov.Models;
using LR4_Baranov.Services.Interfaces;

namespace LR4_Baranov.Services
{
    public class CourseService : BaseService<Course>, ICourseService
    {
        public CourseService(UniversityDbContext context) : base(context) { }
    }
}
