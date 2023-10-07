using GetTalim.DataAccess.Utils;
using GetTalim.Service.Dtos.Student;
using GetTalim.Service.Interfaces.Admin;
using GetTalim.Service.Interfaces.Students;
using GetTalim.Service.Validators.Dtos.Students;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GetTalim.Api.Controller;

[Route("api/students")]
[ApiController]
public class StudentsController : ControllerBase
{
    private readonly IIdentityService _identity;
    private readonly IStudentService _studentService;
    private readonly IStudentAdminService _studentAdminService;
    private readonly int maxPageSize = 20;

    public StudentsController(IIdentityService identity, IStudentService studentService,
                              IStudentAdminService studentAdminService)
    {
        _identity = identity;
        _studentService = studentService;
        _studentAdminService = studentAdminService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllStudentAsync([FromQuery] int page = 1)
    {
        var result = await _studentAdminService.GetAllStudentsAsync(new PaginationParams(page, maxPageSize));
        
        return Ok(result);
    }

    //[HttpGet("{studentId}")]

    [HttpPut]
    [Authorize(Roles = "Student")]
    public async Task<IActionResult> UpdateStudentAsync([FromForm] StudentUpdateDto dto)
    {
        var validator = new StudentUpdateValidator();
        var result = validator.Validate(dto);
        var studentId = _identity.UserId;

        if (result.IsValid) return Ok(await _studentService.UpdateAsync(studentId, dto));
        else return BadRequest(result);
    }

    [HttpGet("search-full-name/{name}")]
    public async Task<IActionResult> SearchStudentNameAsync(string name, [FromQuery] int page = 1)
    {
        var result = await _studentService.SearchStudentNameAsync(name, new PaginationParams(page, maxPageSize));

        return Ok(result);
    }

    
    [HttpGet("search-email/{email}")]
    public async Task<IActionResult> SearchStudentMailAsync(string email, [FromQuery] int page = 1)
    {
        var result = await _studentService.SearchStudentMailAsync(email, new PaginationParams(page, maxPageSize));

        return Ok(result);
    }

}
