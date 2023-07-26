using GetTalim.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace GetTalim.DataAccess.ViewModels;

public class StudentViewModel : Auditable
{
    [MaxLength(30)]
    public string FirstName { get; set; } = string.Empty;

    [MaxLength(30)]
    public string LastName { get; set; } = string.Empty;
    public bool IsMale { get; set; } = false;
    public string Email { get; set; } = string.Empty;
    public bool IsEmailConfirmed { get; set; }

    [MaxLength(20)]
    public string PhoneNumber { get; set; } = string.Empty;
    public string ImagePath { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string Salt { get; set; } = string.Empty;
}
