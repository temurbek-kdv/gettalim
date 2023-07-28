using GetTalim.DataAccess.Utils;
using GetTalim.Service.Dtos.CourseModuls;
using GetTalim.Service.Interfaces.CourseModuls;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace GetTalim.Api.Controller;

[Route("api/[controller]")]
[ApiController]
public class CourseModulsController : ControllerBase
{
    private readonly ICourseModulService _service;
    private readonly int maxPage = 30;

    public CourseModulsController(ICourseModulService service)
    {
        this._service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
        => Ok(await _service.GetAllAsync(new PaginationParams(page, maxPage)));
    
    [HttpGet("{modulId}")]
    public async Task<IActionResult> GetByIdAsync(long modulId)
        => Ok(await _service.GetByIdAsync(modulId));

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateAsync([FromForm] CourseModulCreateDto dto)
        => Ok(await _service.CreateAsync(dto));

    [HttpPut("{modulId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateAsync(long modulId, [FromForm] CourseModulUpdateDto dto)
        => Ok(await _service.UpdateAsync(modulId, dto));

    [HttpDelete("{modulId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteAsync(long modulId)
        => Ok(await _service.DeleteAsync(modulId));
}
