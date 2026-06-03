using LR4_Baranov.Models;
using LR4_Baranov.Services.Interfaces;

namespace LR4_Baranov.Services
{
    public class StudentService : BaseService<Student>, IStudentService
    {
        public StudentService(UniversityDbContext context) : base(context) { }
    }
}
