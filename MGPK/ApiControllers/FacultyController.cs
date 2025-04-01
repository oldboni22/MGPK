using Entities;
using Microsoft.AspNetCore.Mvc;
using Service;
using Shared.DTO;

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

    [HttpGet("collection/{ids}",Name = "GetFacultiesByIds")]
    public IActionResult GetFacultiesById([ModelBinder(typeof(ArrayModelBinder))] IEnumerable<int> ids)
    {
        var faculties = _serviceManager.Faculty.GetFacultiesById(ids, false);
        return Ok(faculties);
    }
    
    [HttpGet("{id:int}",Name = "GetFacultyById")]
    public IActionResult GetFaculty(int id)
    {
        var faculty = _serviceManager.Faculty.GetFaculty(id,false);
        return Ok(faculty);
    }

    [HttpPost]
    public IActionResult CreateFaculty([FromBody]FacultyCreationDto? faculty)
    {
        if (faculty == null)
            return BadRequest("Faculty creation dto object is null");

        var created = _serviceManager.Faculty.CreateFaculty(faculty);
        return CreatedAtRoute("GetFacultyById", new { id = created.Id }, created);
    }

    [HttpPost("collection")]
    public IActionResult CreateFaculties([FromBody] IEnumerable<FacultyCreationDto> faculties)
    {
        var result = _serviceManager.Faculty.CreateFaculties(faculties);
        return CreatedAtRoute("GetFacultiesByIds", new { result.ids }, result.faculties);
    }
}