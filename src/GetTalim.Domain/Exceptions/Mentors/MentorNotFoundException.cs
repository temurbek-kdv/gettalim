namespace GetTalim.Domain.Exceptions.Mentors;

public class MentorNotFoundException : NotFoundException
{
    public MentorNotFoundException()
    {
        this.TitleMessage = "Mentor not found";
    }
}
