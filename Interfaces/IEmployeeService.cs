using MGQSEmployeeAppMVC.DTO;
using MGQSEmployeeAppMVC.Entities;

namespace MGQSEmployeeAppMVC.Interfaces
{
    public interface IEmployeeService
    {

        EmployeeResponseModel Login(string code, string password);
        EmployeeResponseModel Create(EmployeeDto request);
        EmployeesResponseModel GetAll();
        EmployeeResponseModel GetAnEmployee(int id);
        EmployeeResponseModel Update(int id, UpdateEmployeeDto updateEmployeeDto);
        EmployeeResponseModel Delete(int id);
        EmployeeResponseModel ChangePassword(string code, string oldPassword, string newPassword, string confirmPassword);

    }
}
