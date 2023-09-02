namespace GetTalim.Domain.Entities.Mentors;

public class Mentor : Human
{

    public string ImagePath { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Stack { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

}
