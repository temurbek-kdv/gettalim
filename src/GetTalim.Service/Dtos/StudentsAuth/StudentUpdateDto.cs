using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace GetTalim.Service.Dtos.StudentsAuth;

public class StudentUpdateDto
{
    public bool IsMale { get; set; }

    [MaxLength(20)]
    public string PhoneNumber { get; set; } = string.Empty;
    public IFormFile? Image { get; set; }
  
}
