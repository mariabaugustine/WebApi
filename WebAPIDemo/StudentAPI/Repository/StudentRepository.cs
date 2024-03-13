using Microsoft.EntityFrameworkCore;
using StudentAPI.DBContext;
using StudentAPI.Models;

namespace StudentAPI.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentDBContext _dbContext;
        public StudentRepository(StudentDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Student>> GetAllStudentAsync()
        {
            return await _dbContext.students.ToListAsync();
        }
    }
}
