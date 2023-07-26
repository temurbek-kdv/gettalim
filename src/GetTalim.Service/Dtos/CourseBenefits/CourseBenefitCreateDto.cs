namespace GetTalim.Service.Dtos.CourseBenefits;

public class CourseBenefitCreateDto
{
    public string Name { get; set; } = string.Empty;
    public long CourseId { get; set; }
}
