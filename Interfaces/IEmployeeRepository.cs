using MGQSEmployeeAppMVC.Entities;

namespace MGQSEmployeeAppMVC.Interfaces
{
    public interface IEmployeeRepository
    {
        Employee GetById(int id);
        Employee GetByCode(string code);
        List<Employee> GetAll();
        Employee CreateRecord(Employee employee);
        bool Delete(int id);
        Employee Update(Employee employee);
        Employee Login(string code,string password);
    }
}
