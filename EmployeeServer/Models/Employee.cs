using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using EmployeeServer.ViewModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace EmployeeServer.Models;

[Index(nameof(SSNumber), IsUnique = true)]
[Index(nameof(TIN), IsUnique = true)]
[Index(nameof(MIDNumber), IsUnique = true)]
[Index(nameof(PhilHealthNumber), IsUnique = true)]
[Index(nameof(Email), IsUnique = true)]
[Index(nameof(MobileNumber), IsUnique = true)]
public class Employee {

    public Guid Id { get; set; }
    
    public string GivenName { get; set; } = string.Empty;

    public string? MiddleName { get; set; }

    public string Surname { get; set; } = string.Empty;
   
    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }
  
    public string Address { get; set; } = string.Empty;

    public string SSNumber { get; set; } = string.Empty;

    public string TIN { get; set; } = string.Empty;

    public string MIDNumber { get; set; } = string.Empty;

    [JsonPropertyName("philhealthNumber")]
    public string PhilHealthNumber { get; set; } = string.Empty;

    public string MobileNumber { get; set; } = string.Empty;
   
    public string Email { get; set; } = string.Empty;
  
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public Employee(){}

    public Employee(EmployeeViewModel employeeVM){
        GivenName = employeeVM.GivenName ?? string.Empty;
        MiddleName = employeeVM.MiddleName;
        Surname = employeeVM.Surname ?? string.Empty;
        DateOfBirth = employeeVM.DateOfBirth ?? DateTime.MinValue;
        Address = employeeVM.Address ?? string.Empty;
        SSNumber = employeeVM.SSNumber ?? string.Empty;
        TIN = employeeVM.TIN ?? string.Empty;
        MIDNumber = employeeVM.MIDNumber ?? string.Empty;
        PhilHealthNumber = employeeVM.PhilHealthNumber ?? string.Empty;
        MobileNumber = employeeVM.MobileNumber ?? string.Empty;
        Email = employeeVM.Email ?? string.Empty;
        CreatedAt = DateTime.UtcNow;
    }
     public void Update(EmployeeViewModel employeeVM){
        GivenName = employeeVM.GivenName ?? string.Empty;
        MiddleName = employeeVM.MiddleName;
        Surname = employeeVM.Surname ?? string.Empty;
        DateOfBirth = employeeVM.DateOfBirth ?? DateTime.MinValue;
        Address = employeeVM.Address ?? string.Empty;
        SSNumber = employeeVM.SSNumber ?? string.Empty;
        TIN = employeeVM.TIN ?? string.Empty;
        MIDNumber = employeeVM.MIDNumber ?? string.Empty;
        PhilHealthNumber = employeeVM.PhilHealthNumber ?? string.Empty;
        MobileNumber = employeeVM.MobileNumber ?? string.Empty;
        Email = employeeVM.Email ?? string.Empty;
    }
}