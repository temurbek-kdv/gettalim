﻿using Microsoft.AspNetCore.Http;

namespace GetTalim.Service.Dtos.Media;

public class AvatarCreateDto
{
    public IFormFile Avatar { get; set; } = default!;
}
