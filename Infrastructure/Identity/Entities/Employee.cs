using Microsoft.AspNetCore.Identity;
using Nika1337.Library.ApplicationCore.Entities;
using System;

namespace Nika1337.Library.Infrastructure.Identity.Entities;

public class Employee : IdentityUser
{
    public required string IdNumber { get; set; }
    public required Address Address { get; set; }
    public required DateTime DateOfBirth { get; set; }
    public required DateTime StartDate { get; set; }
    public required DateTime? TerminationDate { get; set;}
}
