using System.Net;
using EmployeeServer.Extensions;
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
        return Json(new {
           employees = Array.Empty<object>()
        });
    }
    [HttpPost]
    [Route("/api/employees/")]
    public IActionResult Create([FromBody]EmployeeViewModel employeeVM){

        if(!ModelState.IsValid){
           return BadRequest(new {
              status = HttpStatusCode.BadRequest,
              errors = ModelState.ToValidationErrors()
           });
        }
        return Json(new {
           employee = employeeVM,
        });
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