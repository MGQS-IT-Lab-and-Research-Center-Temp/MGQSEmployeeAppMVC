using MGQSEmployeeAppMVC.DTO;
using MGQSEmployeeAppMVC.Entities;
using MGQSEmployeeAppMVC.Interfaces;
using MGQSEmployeeAppMVC.Response;

namespace MGQSEmployeeAppMVC.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeerepository;
        public EmployeeService(IEmployeeRepository employeerepository) 
        {
            _employeerepository = employeerepository;
        }

        public EmployeeResponseModel ChangePassword(string code, string oldPassword, string newPassword, string confirmPassword)
        {
            var employee = _employeerepository.GetByCode(code);
            if (employee == null)
            {
                 return new EmployeeResponseModel()
                 {
                     Message = "Employee Does not exist",
                     Status = false
                 };
            }
            if (employee.Password == oldPassword)
            {
                return new EmployeeResponseModel
                {
                    Message = "Incorrect password",
                    Status = false
                };
            }
            if(newPassword == confirmPassword)
            {
                return new EmployeeResponseModel
                {
                    Message = "Password  Missmatch",
                    Status = false
                };
            }
            return new EmployeeResponseModel
            {
                Data = new EmployeeDto
                {
                    Password = newPassword
                },
                Message = "Password successfully Updayted",
                Status = true
            };
        }

        public EmployeeResponseModel Create(EmployeeDto request)
        {
            throw new NotImplementedException();
        }

        public EmployeeResponseModel Delete(int id)
        {
            throw new NotImplementedException();
        }

        public EmployeesResponseModel GetAll()
        {
            throw new NotImplementedException();
        }

        public EmployeeResponseModel GetAnEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public Employee Login(string code, string password)
        {
            throw new NotImplementedException();
        }

        public EmployeeResponseModel PrintDetailView(Employee employee)
        {
            throw new NotImplementedException();
        }

        public EmployeeResponseModel PrintListView(Employee employee)
        {
            throw new NotImplementedException();
        }

        public EmployeeResponseModel Update(int id, UpdateEmployeeDto updateEmployeeDto)
        {
            throw new NotImplementedException();
        }
    }
}
