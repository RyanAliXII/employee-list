using System.Net;
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
    [HttpPost] 
    [Route("/api/employees/")]
    public async Task<IActionResult> Create([FromBody]EmployeeViewModel employeeVM){
     try{
        if(!ModelState.IsValid){
           return BadRequest(new {
              status = HttpStatusCode.BadRequest,
              errors = ModelState.ToValidationErrors(),
              details = "One or more fields have validation errors."
           });
        }
       var employee = await _employeeRepo.CreateAsync(new Employee(employeeVM)); 
       await _employeeRepo.SaveAsync();
       return Ok(new {
            status = StatusCodes.Status400BadRequest,
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
    public IActionResult Update(Guid? id){
        return Json(new {
            id
        });
    }
    [HttpDelete]
    [Route("/api/employees/{id?}/")]
    public IActionResult Delete(Guid? id){
        return Json(new {
            id
        });
    }
}