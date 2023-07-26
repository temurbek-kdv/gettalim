using GetTalim.Service.Dtos.Students;
using GetTalim.Service.Dtos.StudentsAuth;

namespace GetTalim.Service.Interfaces.Students;
public interface IAuthStudentService
{
    public Task<(bool Result, int CashedMinutes)> RegisterAsync(StudentRegisterDto registerDto);
    public Task<(bool Result, int CashedVerificationMinutes)> SendCodeForRegisterAsync(string mail);
    public Task<(bool Result, string Token)> VerifyRegisterAsync(string mail, int code);
    public Task<(bool Result, string Token)> LoginAsync(StudentLoginDto loginDto);
}
