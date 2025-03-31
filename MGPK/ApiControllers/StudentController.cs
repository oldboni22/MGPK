using Microsoft.AspNetCore.Mvc;
using Service;

namespace MGPK.ApiControllers;

[Route("api/Students")]
[ApiController]
public class StudentController(IServiceManager serviceManager) : ControllerBase
{
    private readonly IServiceManager _serviceManager = serviceManager;


    [HttpGet]
    public IActionResult GetStudents()
    {
        var students = _serviceManager.Student.GetStudents(false);

        return Ok(students);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetStudent(int id)
    {
        var student = _serviceManager.Student.GetStudent(id, false);
        
        return Ok(student);
    }
    
}