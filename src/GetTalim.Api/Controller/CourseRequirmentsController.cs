using GetTalim.DataAccess.Utils;
using GetTalim.Service.Dtos.CourseRequirments;
using GetTalim.Service.Interfaces.CourseRequirments;
using Microsoft.AspNetCore.Mvc;

namespace GetTalim.Api.Controller;

[Route("api/courserequirments")]
[ApiController]
public class CourseRequirmentsController : ControllerBase
{
    private readonly ICourseRequirmentService _service;
    private readonly int maxRequirments = 30;

    public CourseRequirmentsController(ICourseRequirmentService service)
    {
        this._service = service;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
        => Ok(await _service.GetAllAsync(new PaginationParams(page,maxRequirments)));
    
    [HttpGet("{requirmentId}")]
    public async Task<IActionResult> GetByIdAsync(long requirmentId)
        =>Ok(await _service.GetByIdAsync(requirmentId));

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] CourseRequirmentCreateDto dto)
        =>Ok(await _service.CreateAsync(dto));

    [HttpDelete("{requirmentId}")]
    public async Task<IActionResult> DeleteAsync(long requirmentId)
        => Ok(await _service.DeleteAsync(requirmentId));
}
