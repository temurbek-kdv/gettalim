namespace GetTalim.Domain.Entities.Videos;

public class VideoWithoutPath : Auditable
{
    public string Name { get; set; } = string.Empty;
    public double Length { get; set; }
    public long CourseModulId { get; set; }
}
