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
    public async Task<IActionResult> Update(Guid id, [FromBody]EmployeeViewModel employeeVM){
        try{
            if(id == Guid.Empty){
                return NotFound(new{status = StatusCodes.Status404NotFound, details="Record not found."});
            }
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

    protected void ValidateUniqueFieldOnCreate(){

    }
}