using MGQSEmployeeAppMVC.Enums;
using System.Data;
using System.Reflection;

namespace MGQSEmployeeAppMVC.Entities
{
    public class Employee
    {

        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;    
        public string MiddleName { get; set; } = string.Empty;
        public Gender Gender { get; set; }
        public Role Role { get; set; }
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
