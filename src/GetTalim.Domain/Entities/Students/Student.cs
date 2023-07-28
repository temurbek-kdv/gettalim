using System.ComponentModel.DataAnnotations;

namespace GetTalim.Domain.Entities.Students;

public class Student : Human
{
    public bool IsMale { get; set; }
    public string Email { get; set; } = string.Empty;
    public bool IsEmailConfirmed { get; set; }

    [MaxLength(20)]
    public string PhoneNumber { get; set; } = string.Empty;
    public string ImagePath { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string Salt { get; set; } = string.Empty;
    public string IdentityRole { get; set; } = "Student";
}
