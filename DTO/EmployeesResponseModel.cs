using MGQSEmployeeAppMVC.Entities;

namespace MGQSEmployeeAppMVC.DTO
{
    public class EmployeesResponseModel : BaseResponseModel
    {
        public List<Employee> AllEmployees { get; set; }
    }
}
