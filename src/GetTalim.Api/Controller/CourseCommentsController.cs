using GetTalim.DataAccess.Utils;
using GetTalim.Service.Dtos.CourseComments;
using GetTalim.Service.Interfaces.CourseComments;
using GetTalim.Service.Validators.Dtos.CourseComments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace GetTalim.Api.Controller;

[Route("api/coursecomments")]
[ApiController]
public class CourseCommentsController : ControllerBase
{
    private readonly ICourseCommentService _service;
    private readonly int maxComment = 10;
    public CourseCommentsController(ICourseCommentService service)
    {
        this._service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
        => Ok(await _service.GetAllAsync(new PaginationParams(page, maxComment)));

    [HttpGet("{commentId}")]
    public async Task<IActionResult> GetByIdAsync(long commentId)
        =>Ok(await _service.GetByIdAsync(commentId));

    [HttpPost]
    [Authorize(Roles = "Student")]
    public async Task<IActionResult> CreateAsync([FromForm] CourseCommentCreateDto dto)
    {
        var courseCommentValidator = new CourseCommentCreateValidator();
        var result = courseCommentValidator.Validate(dto);
        if(result.IsValid) return  Ok(await _service.CreateAsync(dto));
        else return BadRequest(result.Errors);
    }
   
    [HttpDelete("{commentId}")]
    [Authorize(Roles = "Student")]
    public async Task<IActionResult> DeleteAsync(long commentId)
        =>Ok(await _service.DeleteAsync(commentId));


}
