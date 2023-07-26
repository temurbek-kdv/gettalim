namespace GetTalim.Service.Dtos.StudentsAuth;

public class StudentVerifyDto
{
    public string Email { get; set; } = string.Empty;
    public int Code { get; set; }
}
