using Microsoft.AspNetCore.Mvc;
using Service;

namespace MGPK.ApiControllers;

[Route("api/Faculties/{facultyId}/Groups/{groupId}/Students")]
[ApiController]
public class StudentController(IServiceManager serviceManager) : ControllerBase
{
    private readonly IServiceManager _serviceManager = serviceManager;


    [HttpGet]
    public IActionResult GetStudents(int facultyId,int groupId)
    {
        var students = _serviceManager.Student.GetStudents(facultyId,groupId,false);

        return Ok(students);
    }

    [HttpGet("{id:int}",Name = "GetStudentById")]
    public IActionResult GetStudent(int facultyId,int groupId,int id)
    {
        var student = _serviceManager.Student.GetStudent(facultyId,groupId,id, false);
        
        return Ok(student);
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteStudent(int facultyId,int groupId,int id)
    {   
        _serviceManager.Student.DeleteStudentForGroup(facultyId,groupId,id,false);
        return NoContent();
    }
    
}