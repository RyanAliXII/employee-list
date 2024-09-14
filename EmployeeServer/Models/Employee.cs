
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

    public string PhilHealthNumber { get; set; } = string.Empty;

    public string MobileNumber { get; set; } = string.Empty;
   
    public string Email { get; set; } = string.Empty;
    
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedAt { get; set; }
}