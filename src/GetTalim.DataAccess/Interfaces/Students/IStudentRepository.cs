using GetTalim.DataAccess.Common.Interfaces;
using GetTalim.DataAccess.ViewModels;
using GetTalim.Domain.Entities.Students;

namespace GetTalim.DataAccess.Interfaces.Students;

public interface IStudentRepository: IRepository<Student, StudentViewModel>, IGetAll<StudentViewModel>,
    ISearchAble<StudentViewModel>
{
    public Task<Student?> GetByEmailAsync(string email);
}
