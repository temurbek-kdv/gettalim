namespace GetTalim.Domain.Exceptions.Courses;

public class CourseRequirmentsNotFoundException : NotFoundException
{
    public CourseRequirmentsNotFoundException()
    {
        this.TitleMessage = "Course requirment not found";
    }
}
