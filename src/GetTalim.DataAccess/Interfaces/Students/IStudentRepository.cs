using GetTalim.DataAccess.Common.Interfaces;
using GetTalim.DataAccess.ViewModels;
using GetTalim.Domain.Entities.Students;

namespace GetTalim.DataAccess.Interfaces.Students;

public interface IStudentRepository : IRepository<Student, Student>
{
    public Task<Student?> GetByEmailAsync(string email);
}
