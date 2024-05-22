

namespace Nika1337.Library.Web.Models.EmployeeAccount;

using System;
using System.ComponentModel.DataAnnotations;

public class EmployeeProfileViewModel
{
    [Required]
    public int Id { get; set; }

    [Required]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    [Required]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }

    [Required]
    [Display(Name = "Username")]
    public string UserName { get; init; }

    [Display(Name = "Phone Number")]
    [DataType(DataType.PhoneNumber)]
    public string PhoneNumber { get; set; }

    [Required]
    public string Gender { get; set; }

    [Required]
    [Display(Name = "ID Number")]
    public string IdNumber { get; init; }



    [Display(Name = "Date of Birth")]
    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }

    [Display(Name = "Email")]
    [EmailAddress]
    public string? Email { get; init; }

    [Display(Name = "Salary")]
    [DataType(DataType.Currency)]
    public decimal Salary { get; init; }

    [Display(Name = "Start Date")]
    [DataType(DataType.Date)]
    public DateTime StartDate { get; init; }



    [Display(Name = "Country")]
    public string Country { get; set; }

    [Display(Name = "State")]
    public string? State { get; set; }


    [Display(Name = "City")]
    public string City { get; set; }

    [Display(Name = "Street")]
    public string Street { get; set; }


    [Display(Name = "Postal Code")]
    public string? PostalCode { get; set; }
}
