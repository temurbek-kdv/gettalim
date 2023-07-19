using Microsoft.AspNetCore.Http;

namespace GetTalim.Service.Dtos.Media;

public class ImageCreateDto
{
    public IFormFile File { get; set; } = default!;
}
