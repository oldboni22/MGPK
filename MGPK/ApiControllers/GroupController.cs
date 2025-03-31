using Microsoft.AspNetCore.Mvc;
using Service;

namespace MGPK.ApiControllers;

[Route("api/Faculty")]
[ApiController]
public class GroupController(IServiceManager serviceManager) : ControllerBase
{
    private readonly IServiceManager _serviceManager = serviceManager;
    
    [HttpGet]
    public IActionResult GetGroups()
    {
        var groups = _serviceManager.Group.GetGroups(false);
        return Ok(groups);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetGroup(int id)
    {
        var group = _serviceManager.Group.GetGroup(id, false);
        return Ok(group);
    }
}