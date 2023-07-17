namespace GetTalim.Domain.Entities.Courses;

public class CourseComment : Auditable
{
    public string Comment { get; set; } = string.Empty;
    public long StudentId { get; set; }
    public long CourseId { get; set; }

}
