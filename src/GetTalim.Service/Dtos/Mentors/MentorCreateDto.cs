using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace GetTalim.Service.Dtos.Mentors;

public class MentorCreateDto
{
    [MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [MaxLength(50)]
    public string LastName { get; set; } = string.Empty;

    public IFormFile Image{ get; set; } = default!;
    public string Description { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Stack { get; set; } = string.Empty;

}
