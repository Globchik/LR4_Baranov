using LR4_Baranov.Models;
using LR4_Baranov.Services.Interfaces;

namespace LR4_Baranov.Services
{
    public class TeacherService : BaseService<Teacher>, ITeacherService
    {
        public TeacherService(UniversityDbContext context) : base(context) { }
    }
}
