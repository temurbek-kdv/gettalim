using GetTalim.Service.Interfaces.CourseViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GetTalim.Api.Controller;

[Route("api/[controller]")]
[ApiController]
public class CourseViewModelController : ControllerBase
{
    private readonly ICourseViewModelService _service;

    public CourseViewModelController(ICourseViewModelService service)
    {
        this._service = service;
    }
    [HttpGet("{viewId}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetCourseViewByIdAsync(long viewId)
        => Ok(await _service.GetGetCourseViewByIdAsync(viewId));
}
