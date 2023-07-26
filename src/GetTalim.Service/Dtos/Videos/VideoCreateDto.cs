namespace GetTalim.Service.Dtos.Videos;

public class VideoCreateDto
{
    public string Name { get; set; } = string.Empty;
    public string VideoPath { get; set; } = string.Empty;
    public double Length { get; set; }
    public long CourseModulId { get; set; }
}
