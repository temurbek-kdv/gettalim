namespace GetTalim.Domain.Exceptions.Courses;

public class CourseCommentNotFoundException : NotFoundException
{
    public CourseCommentNotFoundException()
    {
        this.TitleMessage = "Course comment not found";
    }
}
