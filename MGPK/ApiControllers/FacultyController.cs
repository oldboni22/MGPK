using Entities;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace MGPK.ApiControllers;


[Route("api/Faculty")]
public class FacultyController(IServiceManager serviceManager) : ControllerBase
{
    private readonly IServiceManager _serviceManager = serviceManager;

    [HttpGet]
    public IActionResult FindFaculties(bool trackChanges)
    {
        try
        {
            var result = _serviceManager.Faculty.GetAllFaculties(trackChanges);
            return Ok(result);
        }
        catch (Exception e)
        {
            return StatusCode(500, "Internal server error");
        }
    }
}