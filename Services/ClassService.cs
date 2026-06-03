using LR4_Baranov.Models;
using LR4_Baranov.Services.Interfaces;

namespace LR4_Baranov.Services
{
    public class ClassService : BaseService<Class>, IClassService
    {
        public ClassService(UniversityDbContext context) : base(context) { }
    }
}
