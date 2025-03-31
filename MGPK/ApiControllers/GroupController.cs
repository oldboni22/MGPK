using Microsoft.AspNetCore.Mvc;
using Service;

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

    [HttpGet("{id:int}")]
    public IActionResult GetGroup(int facultyId,int id)
    {
        var group = _serviceManager.Group.GetGroup(facultyId, id, false);
        return Ok(group);
    }
}