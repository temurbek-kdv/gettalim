namespace GetTalim.Domain.Exceptions.Students;

public class StudentNotFoundException : NotFoundException
{
    public StudentNotFoundException()
    {
        this.TitleMessage = "Student not found";
    }
}
