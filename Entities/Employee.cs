using MGQSEmployeeAppMVC.Enums;
using System.Data;
using System.Reflection;

namespace MGQSEmployeeAppMVC.Entities
{
    public class Employee
    {

        public int Id { get; set; }
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public Gender Gender { get; set; }
        public Role Role { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateJoined { get; set; }
    }
}
