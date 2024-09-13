using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EmployeeServer.ViewModels;

public class EmployeeViewModel{
    
    [JsonPropertyName("givenName")]
    [Required(ErrorMessage = "Given name is required")]
    public string? GivenName { get; set; }

    [JsonPropertyName("middleName")]
    public string? MiddleName { get; set; }

    [JsonPropertyName("surname")]
    [Required(ErrorMessage = "Surname is required")]
    public string? Surname { get; set; }

    [JsonPropertyName("dateOfBirth")]
    [Required(ErrorMessage = "Date of birth is required")]
    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }

    [JsonPropertyName("address")]
    [Required(ErrorMessage = "Address is required")]
    public string? Address { get; set; }

    [JsonPropertyName("ssNumber")]
    [Required(ErrorMessage = "SS number is required")]
    public string? SSNumber { get; set; }

    [JsonPropertyName("tin")]
    [Required(ErrorMessage = "TIN is required")]
    public string? TIN { get; set; }

    [JsonPropertyName("midNumber")]
    [Required(ErrorMessage = "MID number is required")]
    public string? MIDNumber { get; set; }

    [JsonPropertyName("philhealthNumber")]
    [Required(ErrorMessage = "PhilHealth number is required")]
    public string? PhilHealthNumber { get; set; }

    [JsonPropertyName("mobileNumber")]
    [Required(ErrorMessage = "Mobile number is required")]
    public string? MobileNumber { get; set; }

    [JsonPropertyName("email")]
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public string? Email { get; set; }

}