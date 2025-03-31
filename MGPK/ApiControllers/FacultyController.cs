using Entities;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace MGPK.ApiControllers;


[Route("api/Faculties")]
[ApiController]
public class FacultyController(IServiceManager serviceManager) : ControllerBase
{
    private readonly IServiceManager _serviceManager = serviceManager;

    [HttpGet]
    public IActionResult GetFaculties()
    {
            var result = _serviceManager.Faculty.GetAllFaculties(false);
            return Ok(result);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetFaculty(int id)
    {
        var faculty = _serviceManager.Faculty.GetFaculty(id,false);
        return Ok(faculty);
    }
}