using GetTalim.Service.Dtos.Students;
using GetTalim.Service.Dtos.StudentsAuth;
using GetTalim.Service.Interfaces.Students;
using GetTalim.Service.Validators.Dtos.Students;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GetTalim.Api.Controller;

[Route("api/StudentAuth")]
[ApiController]
public class StudentAuthController : ControllerBase
{
    private readonly IAuthStudentService _authService;

    public StudentAuthController(IAuthStudentService auth)
    {
        this._authService  = auth;
    }


    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<IActionResult> RegisterAsync([FromForm] StudentRegisterDto registerDto)
    {
        var validator = new StudentRegisterValidator();
        var result = validator.Validate(registerDto);
        if (result.IsValid)
        {
            var serviceResult = await _authService.RegisterAsync(registerDto);
            return Ok(new { serviceResult.Result, serviceResult.CashedMinutes });
        }
        else return BadRequest(result.Errors);
    }


    [HttpPost("register/send-code")]
    [AllowAnonymous]
    public async Task<IActionResult> SendCodeRegisterAsync(string mail)
    {
       var serviceResult = await _authService.SendCodeForRegisterAsync(mail);
        return Ok(new { serviceResult.Result, serviceResult.CashedVerificationMinutes });
    }
    

    [HttpPost("register/verify")]
    [AllowAnonymous]
    public async Task<IActionResult> VerifyRegisterAsync([FromBody] StudentVerifyDto verifyDto )
    {
        var servisResult = await _authService.VerifyRegisterAsync(verifyDto.Email, verifyDto.Code);
        return Ok(new { servisResult.Result, servisResult.Token });
    }


    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> LoginAsync([FromBody] StudentLoginDto logindto)
    {
        var validator = new StudentLoginValidator();
        var valResult = validator.Validate(logindto);
        if (valResult.IsValid == false) return BadRequest(valResult.Errors);

        var serviceResult = await _authService.LoginAsync(logindto);
        return Ok(new { serviceResult.Result, serviceResult.Token });
    }
}
