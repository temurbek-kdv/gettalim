using GetTalim.DataAccess.Utils;
using GetTalim.Service.Dtos.Videos;
using GetTalim.Service.Interfaces.Videos;
using Microsoft.AspNetCore.Mvc;

namespace GetTalim.Api.Controller;

[Route("api/videos")]
[ApiController]
public class VideosController : ControllerBase
{
    private readonly IVideoService _service;
    private readonly int maxPage = 30;

    public VideosController(IVideoService service)
    {
        this._service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
        => Ok(await _service.GetAllAsync(new PaginationParams(page, maxPage)));

    [HttpGet("{videoId}")]
    public async Task<IActionResult> GetByIdAsync(long videoId)
        => Ok(await _service.GetByIdAsync(videoId));

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] VideoCreateDto dto)
        => Ok(await _service.CreateAsync(dto));

    [HttpDelete("{videoId}")]
    public async Task<IActionResult> DeleteAsync(long  videoId)
        => Ok(await _service.DeleteAsync(videoId));

    [HttpPut("{videoId}")]
    public async Task<IActionResult> UpdateAsync(long videoId, [FromForm] VideoUpdateDto dto)
        => Ok(await _service.UpdateAsync(videoId, dto));




}
