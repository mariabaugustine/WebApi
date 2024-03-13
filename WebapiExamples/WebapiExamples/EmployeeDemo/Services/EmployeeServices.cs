using EmployeeDemo.Models;

namespace EmployeeDemo.Services
{
    public class EmployeeServices : IEmployeeService
    {
        static List<Employee> EmployeesList=new List<Employee>();
        public void AddEmployee(Employee employee)
        {
            employee.Id = EmployeesList.Count == 0 ? 1 : EmployeesList.Max(x => x.Id) + 1;
            EmployeesList.Add(employee);
        }

        public void DeleteById(int id)
        {
          var item=EmployeesList.Find(x => x.Id == id);
            if (item != null) 
            {
                EmployeesList.Remove(item);
            }
        }

        public void DeleteEmployee()
        {
            EmployeesList.Clear();
        }

        public IEnumerable<Employee> GetAll()
        {
           return EmployeesList;
        }

        public IEnumerable<Employee> GetById(int id)
        {
           var fid=EmployeesList.FindAll(x => x.Id == id);
            return fid;
        }

        public void UpdateEmployee(Employee employee, int id)
        {
            var item=EmployeesList.Find(x => x.Id == id);
            item.Name=employee.Name;
            item.Age=employee.Age;
            
        }
    }
}
