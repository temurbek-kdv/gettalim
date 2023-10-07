using Microsoft.AspNetCore.Http;

namespace GetTalim.Service.Dtos.Student;

public class StudentUpdateDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public bool IsMale { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;
    public IFormFile? ImagePath {  get; set; } 
}
