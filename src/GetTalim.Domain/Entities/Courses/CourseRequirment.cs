namespace GetTalim.Domain.Entities.Courses;

public class CourseRequirment : Auditable
{
    public string Requirment { get; set; } = string.Empty;
    public long CourseId { get; set; }

}
