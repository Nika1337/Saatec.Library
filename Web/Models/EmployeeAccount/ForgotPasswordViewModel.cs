using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Nika1337.Library.Web.Models.EmployeeAccount;

public class ForgotPasswordViewModel
{
    [Required]
    [EmailAddress]
    [DisplayName("Email")]
    public string Email { get; set; }

    [DisplayName("Code")]
    public string InputCode { get; set; }
    public bool CodeSent { get; set; }
    public string ErrorMessage { get; set; }
}