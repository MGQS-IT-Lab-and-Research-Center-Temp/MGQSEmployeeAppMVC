using MGQSEmployeeAppMVC.Enums;

namespace MGQSEmployeeAppMVC.DTO
{
    public class UpdateEmployeeDto
    {
        public int EmpId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public Gender Gender { get; set; }
        public Role Role { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
