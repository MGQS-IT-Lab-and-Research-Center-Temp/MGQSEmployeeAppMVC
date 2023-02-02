using MGQSEmployeeAppMVC.DTO;
using MGQSEmployeeAppMVC.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MGQSEmployeeAppMVC.Controllers
{
    public class AdminController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public AdminController(IEmployeeService employeeService)
        {
            _employeeService= employeeService;
        }
        // GET: AdminController
        public IActionResult Index()
        {
            var employees = _employeeService.GetAll();
            return View(employees.AllEmployees);
        }

        // GET: AdminController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminController/Create
        public IActionResult Create(EmployeeDto employeeDto)
        {
            var employee = _employeeService.Create(employeeDto);
            if(employee.Status == false)
            {
                ViewBag.Message = employee.Message;
                return View();
            }
            return View(employee.Data);
        }

        // POST: AdminController/Create
        [HttpPost]
 

        // GET: AdminController/Edit/5
        public IActionResult EditEmployee(int id)
        {
           var employee = _employeeService.GetAnEmployee(id);
            if (employee.Status == false)
            {
                ViewBag.Message = employee.Message;
                return View();
            }
            return View(employee.Data);
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        
        public IActionResult Edit(int id)
        {
            var employee = _employeeService.Update(id);
        }

        // GET: AdminController/Delete/5
        public IActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminController/Delete/5
        [HttpPost]
        
        public IActionResult Delete(int id)
        {
            return View();
        }
        public IActionResult Login(string code ,string password)
        {
            var employee = _employeeService.Login(code, password);
            if (employee.Status == false)
            {
                ViewBag.Message = employee.Message;
                return View();
            }
            return RedirectToAction("Index");
            
        }
        public IActionResult Logout()
        {
          return  RedirectToAction("Login");
        }
    }
}
