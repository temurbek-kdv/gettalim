namespace GetTalim.Domain.Entities.Categoires;

public class Category : Auditable
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

}
