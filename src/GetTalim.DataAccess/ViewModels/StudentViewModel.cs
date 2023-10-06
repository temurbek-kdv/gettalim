using GetTalim.Domain.Entities;

namespace GetTalim.DataAccess.ViewModels;

public class StudentViewModel : Auditable
{   
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public bool IsMale { get; set; } = false;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string ImagePath { get; set; } = string.Empty;

}
