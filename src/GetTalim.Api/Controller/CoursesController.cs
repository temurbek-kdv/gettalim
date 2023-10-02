using GetTalim.DataAccess.Utils;
using GetTalim.Service.Dtos.Courses;
using GetTalim.Service.Interfaces.Common;
using GetTalim.Service.Interfaces.Courses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GetTalim.Api.Controller;

[Route("api/courses")]
[ApiController]
public class CoursesController : ControllerBase
{
    private readonly ICourseService _service;
    
    private readonly int maxPageSize = 20;

    public CoursesController(ICourseService courseService)
    {
        _service = courseService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
        => Ok(await _service.GetAllAsync(new PaginationParams(page, maxPageSize)));


    [HttpGet("{courseId}")]
    public async Task<IActionResult> GetByIdAsync(long courseId)
        => Ok(await _service.GetByIdAsync(courseId));


    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateAsync([FromForm] CourseCreateDto dto)
        => Ok(await _service.CreateAsync(dto));


    [HttpPut("{courseId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateAsync(long courseId, [FromForm] CourseUpdateDto dto)
        => Ok(await _service.UpdateAsync(courseId, dto));


    [HttpDelete("{courseId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteAsync(long courseId)
        => Ok(await _service.DeleteAsync(courseId));

}
