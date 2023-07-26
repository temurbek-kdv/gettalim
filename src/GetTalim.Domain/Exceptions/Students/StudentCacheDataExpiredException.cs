namespace GetTalim.Domain.Exceptions.Students;

public class StudentCacheDataExpiredException : ExpiredException
{
    public StudentCacheDataExpiredException()
    {
        this.TitleMessage = "Student data expired!";
    }
}
