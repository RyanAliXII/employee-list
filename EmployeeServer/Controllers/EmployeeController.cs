using Microsoft.AspNetCore.Mvc;

namespace EmployeeServer.Controllers;

public class EmployeeController : Controller{
    [HttpGet]
    [Route("/api/employees/")]
    public IActionResult Create(){
        return Json(new {
           employees = Array.Empty<object>()
        });
    }
    [HttpPost]
    [Route("/api/employees/")]
    public IActionResult Index(){
        return Json(new {
           employees = Array.Empty<object>()
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