namespace GetTalim.Service.Dtos.CourseRequirments;

public class CourseRequirmentCreateDto
{
    public string Requirment { get; set; } = string.Empty;
    public long CourseId { get; set; }
}
