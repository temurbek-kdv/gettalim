using GetTalim.DataAccess.Utils;
using GetTalim.Service.Dtos.Mentors;
using GetTalim.Service.Interfaces.Mentors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace GetTalim.Api.Controller;

[Route("api/mentors")]
[ApiController]
public class MentorsController : ControllerBase
{
    private readonly IMentorService _service;
    private readonly int maxPageSize = 30;

    public MentorsController(IMentorService service)
    {
        this._service =service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
        => Ok(await _service.GetAllAsync(new PaginationParams(page, maxPageSize)));

    [HttpGet("{mentorId}")]
    public async Task<IActionResult> GetByIdAsync(long mentorId)
        =>Ok(await _service.GetByIdAsync(mentorId));

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateAsync([FromForm] MentorCreateDto dto)
        =>Ok(await _service.CreateAsync(dto));

    [HttpPut("{mentorId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateAsync(long mentorId, [FromForm] MentorUpdateDto dto)
        => Ok(await _service.UpdateAsync(mentorId,dto));

    [HttpDelete("{mentorId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteAsync(long mentorId)
        => Ok(await _service.DeleteAsync(mentorId));

}
