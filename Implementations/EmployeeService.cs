using MGQSEmployeeAppMVC.DTO;
using MGQSEmployeeAppMVC.Entities;
using MGQSEmployeeAppMVC.Interfaces;
using MGQSEmployeeAppMVC.Response;
using MGQSEmployeeAppMVC.Shared;

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
            var employees = _employeerepository.GetAll();
            int id = (employees.Count != 0) ? employees[employees.Count - 1].Id + 1 : 1;
            var employee = _employeerepository.GetById(id);
            var code = Helper.GenerateCode(id);
            if(employee == null)
            {
                return new EmployeeResponseModel()
                {
                    Message = "Employee Already Exist",
                    Status = false
                };
            }
            Employee newemployee = new()
            {
                Id = id,
                Code = code,
                FirstName = request.FirstName,
                LastName = request.LastName,
                MiddleName = request.LastName,
                Email = request.Email,
                Phone = request.Phone,
                Gender = request.Gender,
                Role = request.Role,
                Password = request.Password
            };
            _employeerepository.CreateRecord(newemployee);
            return new EmployeeResponseModel
            {
                Data = new EmployeeDto
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    MiddleName = request.LastName,
                    Email = request.Email,
                    Phone = request.Phone,
                    Gender = request.Gender,
                    Role = request.Role,
                },
                Message = "Employee Successfully created",
                Status=  false;
            }
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
