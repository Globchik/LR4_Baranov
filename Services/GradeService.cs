using LR4_Baranov.Models;
using LR4_Baranov.Services.Interfaces;

namespace LR4_Baranov.Services
{
    public class GradeService : BaseService<Grade>, IGradeService
    {
        public GradeService(UniversityDbContext context) : base(context) { }
    }
}
