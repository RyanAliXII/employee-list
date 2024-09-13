using EmployeeServer.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeServer.Controllers;

public class EmployeeController : Controller{
    protected ILogger<EmployeeController> _logger;
    public EmployeeController(ILogger<EmployeeController> logger){
        _logger = logger;
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
        _logger.LogInformation(employeeVM.GivenName);
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