using GetTalim.DataAccess.Utils;
using GetTalim.Service.Dtos.CourseComments;
using GetTalim.Service.Dtos.Payment;
using GetTalim.Service.Dtos.Student;
using GetTalim.Service.Interfaces.Common;
using GetTalim.Service.Interfaces.CourseComments;
using GetTalim.Service.Interfaces.Payments;
using GetTalim.Service.Interfaces.Students;
using GetTalim.Service.Validators.Dtos.Students;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GetTalim.Api.Controller;

[Route("api/admin")]
[ApiController]
public class AdminController : ControllerBase
{
    private readonly ICourseCommentService _commentService;
    private readonly IStudentService _studentService;
    private readonly IPaymentService _paymentService;
    private readonly IPaginatorService _paginator;
    private readonly int maxPageSize = 20;

    public AdminController(ICourseCommentService commentService, IStudentService studentService, 
                            IPaymentService paymentService, IPaginatorService paginator)
    {
        _commentService = commentService;
        _studentService = studentService;
        _paymentService = paymentService;
        _paginator = paginator;
    }

    [HttpGet("payment")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAllPaymentsAsync([FromQuery] int page = 1)
    {
        return Ok(await _paymentService.GetAllAsync(new PaginationParams(page, maxPageSize)));
    }
    
    
    [HttpPost("payment")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreatePaymentAsync([FromBody] PaymentCreateDto dto)
    {
        return Ok(await _paymentService.CreateAsync(dto));
    }


    [HttpPut("payment")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdatePaymentAsync([FromBody] PaymentUpdateDto dto)
    {
        return Ok(await _paymentService.UpdateAsync(dto));
    }

    [HttpDelete("payment/{paymentId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeletePaymentAsync(long paymentId)
    {
        return Ok(await _paymentService.DeleteAsync(paymentId));
    }


    [HttpDelete("course-comment/{courseId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteCommentAsync(long courseId)
    {
       return Ok(await _commentService.DeleteAdminAsync(courseId));
    }

    
    [HttpPut("student/{studentId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateStudentAsync(long studentId, [FromForm] StudentUpdateDto dto)
    {
        var validator = new StudentUpdateValidator();
        var result = validator.Validate(dto);

        if (result.IsValid) return Ok(await _studentService.UpdateAsync(studentId, dto));
        else return BadRequest(result);
    }


    [HttpDelete("student/{studentId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteStudentAsync(long studentId)
        => Ok(await _studentService.DeleteAsync(studentId));

}
