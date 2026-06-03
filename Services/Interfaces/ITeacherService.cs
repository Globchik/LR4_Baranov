using LR4_Baranov.Models;

namespace LR4_Baranov.Services.Interfaces
{
    public interface ITeacherService : IBaseService<Teacher>
    {
        Task<object?> GetTeacherWithClassesAsync(int id);
    }
}
