using System.ComponentModel.DataAnnotations;

namespace GetTalim.Domain.Entities.Admins;

public class Admin : Human
{
    [MaxLength(20)]
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string Salt { get; set; } = string.Empty;

}
