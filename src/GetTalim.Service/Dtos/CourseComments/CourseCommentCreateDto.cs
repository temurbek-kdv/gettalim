namespace GetTalim.Service.Dtos.CourseComments;

public class CourseCommentCreateDto
{
    public string Comment { get; set; } = string.Empty;
    public long CourseId { get; set; }
    public long StudentId { get; set; } 
}
