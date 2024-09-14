
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using EmployeeServer.ViewModels;

namespace EmployeeServer.Models;

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
    
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedAt { get; set; }

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
     // Note: CreatedAt should not be set by the view model, it should be set by the database.
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
        // Note: CreatedAt should not be set by the view model, it should be set by the database.
    }
}