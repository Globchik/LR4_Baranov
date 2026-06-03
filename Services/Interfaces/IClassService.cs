using LR4_Baranov.Models;

namespace LR4_Baranov.Services.Interfaces
{
    public interface IClassService : IBaseService<Class>
    {
        Task<Class?> GetClassWithDetailsAsync(int id);
        Task<IEnumerable<Class>> GetAllClassesWithDetailsAsync();
    }
}
