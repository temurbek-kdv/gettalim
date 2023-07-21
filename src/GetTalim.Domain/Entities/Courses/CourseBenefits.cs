namespace GetTalim.Domain.Entities.Courses;

public class CourseBenefits : Auditable
{
    public string Name { get; set; } = string.Empty;
    public long CourseId { get; set; }

}
