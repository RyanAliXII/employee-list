using System.ComponentModel.DataAnnotations;

namespace EmployeeServer.ViewModels;

public class EmployeeViewModel{

    [Required(ErrorMessage = "Given name is required")]
    public string? GivenName { get; set; }

    public string? MiddleName { get; set; }

    [Required(ErrorMessage = "Surname is required")]
    public string? Surname { get; set; }

    [Required(ErrorMessage = "Date of birth is required")]
    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }

    [Required(ErrorMessage = "Address is required")]
    public string? Address { get; set; }

    [Required(ErrorMessage = "SS number is required")]
    public string? SSNumber { get; set; }

    [Required(ErrorMessage = "TIN is required")]
    public string? TIN { get; set; }

    [Required(ErrorMessage = "MID number is required")]
    public string? MIDNumber { get; set; }

    [Required(ErrorMessage = "PhilHealth number is required")]
    public string? PhilHealthNumber { get; set; }

    [Required(ErrorMessage = "Mobile number is required")]
    public string? MobileNumber { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public string? Email { get; set; }

}