using MGQSEmployeeAppMVC.DTO;
using MGQSEmployeeAppMVC.Entities;
using MGQSEmployeeAppMVC.Enums;
using MGQSEmployeeAppMVC.Interfaces;
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
            if (newPassword == confirmPassword)
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
            var employee = _employeerepository.GetById(request.EmpId);
           string code = Helper.GenerateCode(id);
            if (employee != null)
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
                MiddleName = request.MiddleName,
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
                    EmpId = newemployee.Id,
                    EmpCode = newemployee.Code,
                    FirstName = newemployee.FirstName,
                    LastName = newemployee.LastName,
                    MiddleName = newemployee.MiddleName,
                    Email = newemployee.Email,
                    Phone = newemployee.Phone,
                    Gender = newemployee.Gender,
                    Role = newemployee.Role,
                    Password = newemployee.Password
                },
                Message = "Employee Successfully created",
                Status = true
            };
        }

        public EmployeeResponseModel Delete(int id)
        {
            var employee = _employeerepository.GetById(id);
            if (employee == null)
            {
                return new EmployeeResponseModel
                {
                    Message = "Employee does not exist",
                    Status = false
                };
            }
            _employeerepository.Delete(id);
            return new EmployeeResponseModel()
            {
                Message = "Employee Succesfully deleted",
                Status = true

            };
        }

        public EmployeesResponseModel GetAll()
        {
            var employees = _employeerepository.GetAll();
            return new EmployeesResponseModel
            {
                AllEmployees = employees,
                Message = "List Of Employees",
                Status = true
            };
        }

        public EmployeeResponseModel GetAnEmployee(int id)
        {
            var employee = _employeerepository.GetById(id);
            if (employee == null)
            {
                return new EmployeeResponseModel
                {
                    Message = "Employee Does not exist",
                    Status = false
                };
            }
            return new EmployeeResponseModel
            {
                Data = new EmployeeDto
                {
                    EmpId = employee.Id,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    MiddleName = employee.MiddleName,
                    Phone = employee.Phone,
                    Email = employee.Email,
                    Role = employee.Role,
                    Gender = employee.Gender
                },
                Message = "Data Of employee",
                Status = true
            };
        }

        public EmployeeResponseModel Login(string code, string password)
        {
            var employee = _employeerepository.Login(code, password);
            if (employee == null)
            {
                return new EmployeeResponseModel()
                {
                    Message = "Employee does not exist",
                    Status = false
                };
            }
            return new EmployeeResponseModel
            {
                Message = "Login Successful",
                Status = true
            };
        }
        public EmployeeResponseModel Update(int id, UpdateEmployeeDto updateEmployeeDto)
        {
            var employee = _employeerepository.GetById(id);
            if (employee == null)
            {
                return new EmployeeResponseModel()
                {
                    Message = "Employee does not exist",
                    Status = false
                };
            }
            employee.FirstName = updateEmployeeDto.FirstName;
            employee.LastName = updateEmployeeDto.LastName;
            employee.MiddleName = updateEmployeeDto.MiddleName;
            employee.Phone = updateEmployeeDto.Phone;
            employee.Email = updateEmployeeDto.Email;
            employee.Role = updateEmployeeDto.Role;
            employee.Gender = updateEmployeeDto.Gender;
            _employeerepository.Update(id);
            return new EmployeeResponseModel()
            {
                Message = "Employee Updated",
                Status = true
            };
        }
    }
}
