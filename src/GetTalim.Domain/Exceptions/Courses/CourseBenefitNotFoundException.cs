namespace GetTalim.Domain.Exceptions.Courses;

public class CourseBenefitNotFoundException :NotFoundException
{
    public CourseBenefitNotFoundException()
    {
        this.TitleMessage = "Course benefit not found exception";
    }
}
