using LR4_Baranov.Models;

namespace LR4_Baranov.Services.Interfaces
{
    public interface IGradeService : IBaseService<Grade>
    {
        Task<IEnumerable<Grade>> GetGradesForStudentAsync(int studentId);
    }
}
