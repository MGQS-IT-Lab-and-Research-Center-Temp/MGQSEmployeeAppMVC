using MGQSEmployeeAppMVC.DTO;
using MGQSEmployeeAppMVC.Entities;
using MGQSEmployeeAppMVC.Response;

namespace MGQSEmployeeAppMVC.Interfaces
{
    public interface IEmployeeService
    {

        Employee Login(string code, string password);
        EmployeeResponseModel Create(EmployeeDto request);
        EmployeesResponseModel GetAll();
        EmployeeResponseModel GetAnEmployee(int id);
        EmployeeResponseModel Update(int id, UpdateEmployeeDto updateEmployeeDto);
        EmployeeResponseModel Delete(int id);
        EmployeeResponseModel PrintListView(Employee employee);
        EmployeeResponseModel PrintDetailView(Employee employee);
        EmployeeResponseModel ChangePassword(string code, string oldPassword, string newPassword, string confirmPassword);

    }
}
