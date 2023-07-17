namespace GetTalim.Domain.Exceptions.Admins;

public class AdminNotFoundException : NotFoundException
{
    public AdminNotFoundException()
    {
        this.TitleMessage = "Admin Not Found";
    }
}
