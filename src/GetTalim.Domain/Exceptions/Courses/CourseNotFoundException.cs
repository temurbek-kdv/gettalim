namespace GetTalim.Domain.Exceptions.Courses;

public class CourseNotFoundException : NotFoundException
{
    public CourseNotFoundException()
    {
        this.TitleMessage = "Course not found";
    }
}
