using GetTalim.DataAccess.Utils;
using GetTalim.Service.Dtos.CourseBenefits;
using GetTalim.Service.Interfaces.CourseBenefits;
using Microsoft.AspNetCore.Mvc;

namespace GetTalim.Api.Controller;

[Route("api/coursebenefits")]
[ApiController]
public class CourseBenefitsController : ControllerBase
{
    private readonly ICourseBenefitService _service;
    private readonly int maxbenefit = 20;
    public CourseBenefitsController(ICourseBenefitService service)
    {
        this._service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
        => Ok(await _service.GetAllAsync(new PaginationParams(page, maxbenefit)));


    [HttpGet("coursebenefitId")]
    public async Task<IActionResult> GetByIdAsync(long coursebenefitId)
        => Ok(await _service.GetByIdAsync(coursebenefitId));

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] CourseBenefitCreateDto dto)
        =>Ok(await _service.CreateAsync(dto));

    [HttpDelete("{coursebenefitId}")]
    public async Task <IActionResult> DeleteAsync(long coursebenefitId)
        =>Ok( await _service.DeleteAsync(coursebenefitId));
}
