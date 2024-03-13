using EmployeeDemo.Models;
using EmployeeDemo.Services;
using EmployeeDemo.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService) 
        {
            _employeeService = employeeService;
        }
        [HttpPost]
        public IActionResult Add(AddViewModel addViewModel)  
        {
            var employee = new Employee()
            {
                Name = addViewModel.Name,
                Age = addViewModel.Age,
            };
         _employeeService.AddEmployee(employee);
            return Ok("Added Successfully");
        }
        [HttpGet]
        public IActionResult GetEmployee()
        {
            var abc = _employeeService.GetAll();
            if (abc.Count() == 0)
            {
                return Ok("No record Found");
            }
            return Ok(abc);
        }
        [HttpPut("{id}")]   
        public IActionResult PutEmployee(Employee employee,int id) 
        {
            _employeeService.UpdateEmployee(employee,id);
            return Ok("Updated Successfully");
        }
        [HttpDelete]
        public IActionResult Delete() 
        { 
            _employeeService.DeleteEmployee();
            return Ok("Deleted Successfully");
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        {
            var item= _employeeService.GetAll();
            if(item.Count() == 0)
            {
                return Ok("No record found");
            }
            return Ok(item);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            _employeeService.DeleteById(id);
            return Ok("Deleted Successfuuly");
        }

      
    }
}
