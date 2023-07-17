namespace GetTalim.Domain.Exceptions.Courses;

public class CourseModuleNotFoundException : NotFoundException
{
    public CourseModuleNotFoundException()
    {
        this.TitleMessage = "Course modul not found";
    }
}
