using GetTalim.DataAccess.Utils;
using GetTalim.Service.Dtos.CourseRequirments;
using GetTalim.Service.Interfaces.CourseRequirments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

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
    [AllowAnonymous]
    public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
        => Ok(await _service.GetAllAsync(new PaginationParams(page, maxRequirments)));

    [HttpGet("{requirmentId}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetByIdAsync(long requirmentId)
        => Ok(await _service.GetByIdAsync(requirmentId));

    [HttpGet("course/{courseId}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetCourseRequirmentsAsync(long courseId)
        => Ok(await _service.GetCourseRequirmentsAsync(courseId));

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateAsync([FromForm] CourseRequirmentCreateDto dto)
        =>Ok(await _service.CreateAsync(dto));

    [HttpDelete("{requirmentId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteAsync(long requirmentId)
        => Ok(await _service.DeleteAsync(requirmentId));

}
