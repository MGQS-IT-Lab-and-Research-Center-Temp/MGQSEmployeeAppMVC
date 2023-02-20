using MGQSEmployeeAppMVC.Entities;
using MGQSEmployeeAppMVC.Enums;
using Microsoft.EntityFrameworkCore;

namespace MGQSEmployeeAppMVC.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
       public  DbSet<Employee> Employee{ get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Employee>().HasData
             (
                new Employee
                {
                    Id = 1,
                    Code = "EMP-0001",
                    FirstName = "Admin",
                    LastName = "Baba",
                    MiddleName = "Boss",
                    Email = "AdminBoss@gmail.com.com",
                    Phone = "08098987654",
                    Password = "password",
                    Gender = Gender.Male,
                    Role = Role.Admin,
                }
             );
        }
    }
}
