using MGQSEmployeeAppMVC.Context;
using MGQSEmployeeAppMVC.Entities;
using MGQSEmployeeAppMVC.Interfaces;

namespace MGQSEmployeeAppMVC.Implementations
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationContext _context;
        public EmployeeRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Employee CreateRecord(Employee employee)
        {
            _context.Employee.Add(employee);
            _context.SaveChanges();
            return employee;
        }

        public bool Delete(int id)
        {
            var employee = GetById(id);
            _context.Employee.Remove(employee);
            _context.SaveChanges();
            return true;
        }

        public List<Employee> GetAll()
        {
            var employee = _context.Employee.Select(emp => new Employee
            {
                FirstName = emp.FirstName,
                LastName = emp.LastName,
                MiddleName = emp.MiddleName,
                Gender = emp.Gender,
                Role= emp.Role,
                Phone = emp.Phone,
                Email = emp.Email,

            }).ToList();
            return employee;
        }

        public Employee GetByCode(string code)
        {
            var employee = _context.Employee.FirstOrDefault(emp => emp.Code == code);
            return employee;
        }
        public Employee GetById(int id)
        {

            var employee = _context.Employee.FirstOrDefault(emp => emp.Id == id);
            return employee;
        }

        public Employee Update(Employee employee)
        {
            _context.Employee.Update(employee);
            _context.SaveChanges();
            return employee;
        }
    }
}
