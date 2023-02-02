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
            throw new NotImplementedException();
        }

        public List<Employee> GetAll()
        {
            throw new NotImplementedException();
        }

        public Employee GetByCode(string code)
        {
            throw new NotImplementedException();
        }

        public Employee GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Employee Update(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
