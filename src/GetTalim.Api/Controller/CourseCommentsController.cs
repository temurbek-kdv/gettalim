using GetTalim.DataAccess.Utils;
using GetTalim.Service.Dtos.CourseComments;
using GetTalim.Service.Interfaces.CourseComments;
using GetTalim.Service.Validators.Dtos.CourseComments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GetTalim.Api.Controller;

[Route("api/course-comments")]
[ApiController]
public class CourseCommentsController : ControllerBase
{
    private readonly ICourseCommentService _service;
    private readonly int maxPageSize = 10;
    public CourseCommentsController(ICourseCommentService service)
    {
        this._service = service;
    }


    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
        => Ok(await _service.GetAllAsync(new PaginationParams(page, maxPageSize)));


    [HttpGet("{commentId}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetByIdAsync(long commentId)
        => Ok(await _service.GetByIdAsync(commentId));


    [HttpGet("course/{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetCourseCommentsAsync(long id, [FromQuery] int page = 1)
        => Ok(await _service.GetCourseCommentsAsync(id, new PaginationParams(page, maxPageSize)));


    [HttpPost]
    [Authorize(Roles = "Student")]
    public async Task<IActionResult> CreateAsync([FromForm] CourseCommentCreateDto dto)
    {
        var courseCommentValidator = new CourseCommentCreateValidator();
        var result = courseCommentValidator.Validate(dto);
        if (result.IsValid) return Ok(await _service.CreateAsync(dto));
        else return BadRequest(result.Errors);
    }


    [HttpDelete("{commentId}")]
    [Authorize(Roles = "Student")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteAsync(long commentId)
        => Ok(await _service.DeleteAsync(commentId));


}
