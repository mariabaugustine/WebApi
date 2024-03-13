using EmployeeDemo.Models;

namespace EmployeeDemo.Services
{
    public interface IEmployeeService
    {
        public void AddEmployee(Employee employee);
        public IEnumerable<Employee> GetAll();
        public void DeleteEmployee();
        public void UpdateEmployee(Employee employee,int id);

        public IEnumerable<Employee>GetById(int id);
         
        public void DeleteById(int id);
    }
}
