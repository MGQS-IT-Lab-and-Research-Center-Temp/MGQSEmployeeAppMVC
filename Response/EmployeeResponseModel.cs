using MGQSEmployeeAppMVC.DTO;
using MGQSEmployeeAppMVC.Entities;

namespace MGQSEmployeeAppMVC.Response
{
    public class EmployeeResponseModel : BaseResponseModel
    {
        public EmployeeDto Data { get; set; }  
    }
}
