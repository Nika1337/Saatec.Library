using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nika1337.Library.Web.Models;
using Nika1337.Library.Web.Models.EmployeeAccount;
using System.Diagnostics;

namespace Web.Controllers;

//[Authorize()]
public class HomeController : Controller
{
    private static List<EmployeeViewModel> _employees = new List<EmployeeViewModel>
    {
        new EmployeeViewModel { Id = 1, FirstName = "John", TerminationDate = DateTime.Now, LastName = "Doe", Username = "jdoe", Email = "jdoe@example.com", PhoneNumber = "123-456-7890", DateOfBirth = new DateTime(1980, 1, 1), IdNumber = "123456", StartDate = new DateTime(2020, 1, 1)},
        new EmployeeViewModel { Id = 2, FirstName = "Jane", LastName = "Smith", Username = "jsmith", Email = "jsmith@example.com", PhoneNumber = "098-765-4321", DateOfBirth = new DateTime(1990, 2, 2), IdNumber = "654321", StartDate = new DateTime(2021, 2, 2), Roles = ["HR Manager", "Administrator"] }
    };
    private static EmployeeRegistrationViewModel employeeRegistrationViewModel = new()
    {
        AvailableRoles = [
            new SelectListItem { Value = "Consultant", Text = "Consultant" },
            new SelectListItem { Value = "Librarian", Text = "Librarian" },
            new SelectListItem { Value = "Core Librarian", Text = "Core Librarian" },
            new SelectListItem { Value = "HR Manager", Text = "HR Manager" },
            new SelectListItem { Value = "Administrator", Text = "Administrator" }
            ]
    };
    private static EmployeeEditViewModel employeeEditViewModel = new() {
        AvailableRoles = [
            new SelectListItem { Value = "Consultant", Text = "Consultant" },
            new SelectListItem { Value = "Librarian", Text = "Librarian" },
            new SelectListItem { Value = "Core Librarian", Text = "Core Librarian" },
            new SelectListItem { Value = "HR Manager", Text = "HR Manager" },
            new SelectListItem { Value = "Administrator", Text = "Administrator" }
            ] 
    };
    private static EmployeeProfileViewModel employeeProfileViewModel = new() { FirstName = "Pablo", LastName = "Escobar", UserName = "ThePablo", IdNumber = "01008060513", Gender = "Male", PhoneNumber = "551553443", Email = "pabloescobar@gmail.com", Salary = 100_000 };
    private static SignInViewModel signInViewModel = new SignInViewModel();
    private static ForgotPasswordViewModel forgotPasswordViewModel = new ForgotPasswordViewModel();
    private static ChangePasswordViewModel changePasswordViewModel = new ChangePasswordViewModel();
    public IActionResult Index()
    {
        return View("~/Views/EmployeeAccount/ChangePassword.cshtml", changePasswordViewModel);
        //return View("~/Views/EmployeeAccount/ForgotPassword.cshtml", forgotPasswordViewModel);
        //return View("~/Views/EmployeeAccount/EmployeeProfile.cshtml", employeeProfileViewModel);

        //return View("~/Views/EmployeeAccount/SignIn.cshtml", signInViewModel);

        //return View("~/Views/EmployeeManagement/EditEmployee.cshtml", employeeEditViewModel);

        //return View("~/Views/EmployeeManagement/Employees.cshtml", _employees);

        //return View("~/Views/EmployeeManagement/RegisterEmployee.cshtml", employeeRegistrationViewModel);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
