using StudentAPI.Models;

namespace StudentAPI.Repository
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>>GetAllStudentAsync();
    }
}
