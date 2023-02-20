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
            _employeeService = employeeService;
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
            var employee = _employeeService.GetAnEmployee(id);
            if (employee.Status == false)
            {
                ViewBag.Message = employee.Message;
                return View();
            }
            return View(employee.Data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeDto employeeDto)
        {
            var employee = _employeeService.Create(employeeDto);
            if (employee.Status == false)
            {
                ViewBag.Message = employee.Message;
                return View();
            }

            return RedirectToAction("Index");
        }

    
        public IActionResult EditEmployee(int id)
        {
            var employee = _employeeService.GetAnEmployee(id);
            return View(employee.Data);
        }
        [HttpGet]
        public IActionResult  Edit()
        {
            return View();
        }
    

        // POST: AdminController/Edit/5

        [HttpPost]
        public IActionResult Edit(int id, UpdateEmployeeDto request)
        {
            var employee = _employeeService.Update(id, request);
            if (employee.Status == false)
            {
                ViewBag.Message = employee.Message;
            }
            return RedirectToAction("Index");
        }

        // GET: AdminController/Delete/5
        public IActionResult DeleteEmployee(int id)
        {
            var employee = _employeeService.GetAnEmployee(id);
            if (employee.Status == false)
            {
                ViewBag.Message = employee.Message;
                return View();
            }
            return View(employee.Data);
        }

        // POST: AdminController/Delete/5
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var employee = _employeeService.Delete(id);
            if (employee.Status == false)
            {
                ViewBag.Message = employee.Message;
                return View();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Login(string code, string password)
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
            return RedirectToAction("Login");
        }
        public IActionResult ChangePassword(string code, string oldPassword, string newPassword, string confirmPassword)
        {
            var employee = _employeeService.ChangePassword(code, oldPassword, newPassword, confirmPassword);
            if (employee.Status == false)
            {
                ViewBag.Message = employee.Message;
                return View();
            }
            return RedirectToAction("Index");
        }
    }
}
