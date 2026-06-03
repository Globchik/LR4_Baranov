using LR4_Baranov.Models;

namespace LR4_Baranov.Services.Interfaces
{
    public interface ICourseService : IBaseService<Course>
    {
        Task<Course?> GetCourseWithClassesAsync(int id);
    }
}
