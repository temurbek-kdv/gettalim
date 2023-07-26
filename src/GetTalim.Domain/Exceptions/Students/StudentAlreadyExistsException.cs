namespace GetTalim.Domain.Exceptions.Students;

public class StudentAlreadyExistsException : AlreadyExistsExcaption
{
    public StudentAlreadyExistsException()
    {
        this.TitleMessage = "Student already exits";
    }
    public StudentAlreadyExistsException(string email)
    {
        this.TitleMessage = "This email is already exits";
    }
}
