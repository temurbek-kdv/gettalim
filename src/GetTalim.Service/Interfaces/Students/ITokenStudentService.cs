using GetTalim.Domain.Entities.Students;

namespace GetTalim.Service.Interfaces.Students;

public interface ITokenStudentService
{
    public string GenerateToken(Student student);
}
