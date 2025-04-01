using Microsoft.AspNetCore.Mvc;
using Service;
using Shared.DTO;

namespace MGPK.ApiControllers;

[Route("api/Faculties/{facultyId}/Groups")]
[ApiController]
public class GroupController(IServiceManager serviceManager) : ControllerBase
{
    private readonly IServiceManager _serviceManager = serviceManager;
    
    [HttpGet]
    public IActionResult GetGroups(int facultyId)
    {
        var groups = _serviceManager.Group.GetGroups(facultyId,false);
        return Ok(groups);
    }

    [HttpGet("{id:int}",Name = "GetGroupById")]
    public IActionResult GetGroup(int facultyId,int id)
    {
        var group = _serviceManager.Group.GetGroup(facultyId, id, false);
        return Ok(group);
    }

    [HttpPost]
    public IActionResult CreateService(int facultyId,[FromBody] GroupCreationDto? group)
    {
        if (group == null)
            return BadRequest("Group creation dto object is null\"");

        var result = _serviceManager.Group.CreateGroupForFaculty(facultyId, group);
        return CreatedAtRoute("GetGroupById",
            new { facultyId, id = result.Id },
            result);
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteGroup(int facultyId, int id)
    {
        _serviceManager.Group.DeleteGroupForFaculty(facultyId,id,false);
        return NoContent();
    }
}