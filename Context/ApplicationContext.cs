using MGQSEmployeeAppMVC.Entities;
using Microsoft.EntityFrameworkCore;

namespace MGQSEmployeeAppMVC.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
       public  DbSet<Employee> Employee{ get; set; }
    }
}
