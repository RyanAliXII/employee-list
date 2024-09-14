using EmployeeServer.Extensions;
using EmployeeServer.Models;
using EmployeeServer.Repositories;
using EmployeeServer.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeServer.Controllers;

public class EmployeeController : Controller{
    protected ILogger<EmployeeController> _logger;
    protected IEmployeeRepository _employeeRepo;
    public EmployeeController(ILogger<EmployeeController> logger, IEmployeeRepository employeeRepo){
        _logger = logger;
        _employeeRepo = employeeRepo;
    }
    [Route("/api/employees/")]
    public IActionResult Index(){
        var employees = _employeeRepo.GetEmployeesOrderedByCreatedAtDesc();
        return Ok(new {
           status = StatusCodes.Status200OK,
           employees,
           details = "Employees fetched."
        });
    }
    [Route("/api/employees/{id?}")]
    public async Task<IActionResult> GetOne(Guid id){
        if(id == Guid.Empty){
            return NotFound(new{status = StatusCodes.Status404NotFound, details="Record not found."});
        }
        var employee = await _employeeRepo.GetByIdAsync(id);
        if(employee is null){
            return NotFound(new{status = StatusCodes.Status404NotFound, details="Record not found."});
        }
        return Ok(new {
           status = StatusCodes.Status200OK,
           employee,
           details = "Employee fetched."
        });
    }
    [HttpPost] 
    [Route("/api/employees/")]
    public async Task<IActionResult> Create([FromBody]EmployeeViewModel employeeVM){
        try{
            await ValidateUniqueFieldsOnCreate(employeeVM);
            if(!ModelState.IsValid){
            return BadRequest(new {
                status = StatusCodes.Status400BadRequest,
                errors = ModelState.ToValidationErrors(),
                details = "One or more fields have validation errors."
            });
            }
        var employee = await _employeeRepo.CreateAsync(new Employee(employeeVM)); 
        await _employeeRepo.SaveAsync();
        return Ok(new {
                status = StatusCodes.Status200OK,
                employee,
                details = "Employee created."
        });
        }
        catch(Exception error){
            _logger.LogError("{Message} {StackTrace}", error.Message, error.StackTrace);
            return StatusCode(StatusCodes.Status500InternalServerError, new {
                status =  StatusCodes.Status500InternalServerError,
                details = "Unknown error occured."
            });
        }
    }
    [HttpPut]
    [Route("/api/employees/{id?}/")]
    public async Task<IActionResult> Update([FromBody]EmployeeViewModel employeeVM, Guid id){
        try{
            if(id == Guid.Empty){
                return NotFound(new{status = StatusCodes.Status404NotFound, details="Record not found."});
            }
            await ValidateUniqueFieldOnUpdate(employeeVM, id);
            if(!ModelState.IsValid){
                return BadRequest(new {
                status = StatusCodes.Status400BadRequest,
                errors = ModelState.ToValidationErrors(),
                details = "One or more fields have validation errors."
            });
            }
            var employee = await  _employeeRepo.GetByIdAsync(id);
            if(employee is null){
                return NotFound(new{status = StatusCodes.Status404NotFound, details="Record not found."});
            }
            employee.Update(employeeVM);
            await _employeeRepo.SaveAsync();
            return Ok(new {
                status = StatusCodes.Status200OK,
                employee,
                details = "Employee has been updated"
            });
        }catch(Exception error){
            _logger.LogError("{Message} {StackTrace}", error.Message, error.StackTrace);
            return StatusCode(StatusCodes.Status500InternalServerError, new {
                status =  StatusCodes.Status500InternalServerError,
                details = "Unknown error occured."
            });
        }
    }
    [HttpDelete]
    [Route("/api/employees/{id?}/")]
    public async Task<IActionResult> Delete(Guid id){
        try {
            if(id == Guid.Empty){
               return NotFound(new{status = StatusCodes.Status404NotFound, details="Record not found."});
            }
            await _employeeRepo.DeleteAsync(id);
            await _employeeRepo.SaveAsync();
            return Ok(new {
                status = StatusCodes.Status200OK,
                details = "Employee deleted."
            });
        }catch(Exception error){
            _logger.LogError("{Message} {StackTrace}", error.Message, error.StackTrace);
            return StatusCode(StatusCodes.Status500InternalServerError, new {
                status =  StatusCodes.Status500InternalServerError,
                details = "Unknown error occured."
            });
        }
        
    }
    protected async Task ValidateUniqueFieldsOnCreate(EmployeeViewModel employeeVM)
    {
        /*
            Validate unique fields.
            I dont know where put this long ass lines of code.
        */
        if (!string.IsNullOrEmpty(employeeVM.Email) && await _employeeRepo.IsEmailExistsAsync(employeeVM.Email))
        {
            ModelState.AddModelError(nameof(employeeVM.Email), "Email already exists.");
        }
        if (!string.IsNullOrEmpty(employeeVM.SSNumber) && await _employeeRepo.IsSSNumberExistsAsync(employeeVM.SSNumber))
        {
            ModelState.AddModelError(nameof(employeeVM.SSNumber), "SS Number already exists.");
        }
        if (!string.IsNullOrEmpty(employeeVM.TIN) && await _employeeRepo.IsTINExistsAsync(employeeVM.TIN))
        {
            ModelState.AddModelError(nameof(employeeVM.TIN), "TIN already exists.");
        }
        if (!string.IsNullOrEmpty(employeeVM.MIDNumber) && await _employeeRepo.IsMIDNumberExistsAsync(employeeVM.MIDNumber))
        {
            ModelState.AddModelError(nameof(employeeVM.MIDNumber), "MID Number already exists.");
        }
        if (!string.IsNullOrEmpty(employeeVM.PhilHealthNumber) && await _employeeRepo.IsPhilHealthNumberExistsAsync(employeeVM.PhilHealthNumber))
        {
            ModelState.AddModelError("philhealthNumber", "PhilHealth Number already exists.");
        }
        if (!string.IsNullOrEmpty(employeeVM.MobileNumber) && await _employeeRepo.IsMobileNumberExistsAsync(employeeVM.MobileNumber))
        {
            ModelState.AddModelError(nameof(employeeVM.MobileNumber), "Mobile number already exists.");
        }
    }
    protected async Task ValidateUniqueFieldOnUpdate(EmployeeViewModel employeeVM, Guid id){
        /*
            Validate unique fields for current existing employee.
            I dont know where put this long ass lines of code.
        */
        if (!string.IsNullOrEmpty(employeeVM.Email) && await _employeeRepo.IsEmailForCurrentEmployeeAsync(employeeVM.Email, id))
        {
            ModelState.AddModelError(nameof(employeeVM.Email), "Email already exists.");
        }
        if (!string.IsNullOrEmpty(employeeVM.SSNumber) && await _employeeRepo.IsSSNumberForCurrentEmployeeAsync(employeeVM.SSNumber, id))
        {
            ModelState.AddModelError(nameof(employeeVM.SSNumber), "SS Number already exists.");
        }
        if (!string.IsNullOrEmpty(employeeVM.TIN) && await _employeeRepo.IsTINForCurrentEmployeeAsync(employeeVM.TIN, id))
        {
            ModelState.AddModelError(nameof(employeeVM.TIN), "TIN already exists.");
        }
        if (!string.IsNullOrEmpty(employeeVM.MIDNumber) && await _employeeRepo.IsMIDNumberForCurrentEmployeeAsync(employeeVM.MIDNumber, id))
        {
            ModelState.AddModelError(nameof(employeeVM.MIDNumber), "MID Number already exists.");
        }
        if (!string.IsNullOrEmpty(employeeVM.PhilHealthNumber) && await _employeeRepo.IsPhilHealthNumberForCurrentEmployeeAsync(employeeVM.PhilHealthNumber, id))
        {
            ModelState.AddModelError("philhealthNumber", "PhilHealth Number already exists.");
        }
        if (!string.IsNullOrEmpty(employeeVM.MobileNumber) && await _employeeRepo.IsMobileNumberForCurrentEmployeeAsync(employeeVM.MobileNumber, id))
        {
            ModelState.AddModelError(nameof(employeeVM.MobileNumber), "Mobile number already exists.");
        }
    }

}