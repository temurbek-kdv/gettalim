﻿using GetTalim.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace GetTalim.Service.Dtos.Courses;

public class CourseUpdateDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Information { get; set; } = string.Empty;
    public int Lessons { get; set; }
    public string Level { get; set; } = string.Empty;
    public string Language { get; set; } = string.Empty;
    public double Hourse { get; set; }
    public IFormFile? Image { get; set; } = default!;
    public double Price { get; set; }
    public double DiscountPrice { get; set; }
    public long MentorId { get; set; }
    public long CategoryId { get; set; }
}