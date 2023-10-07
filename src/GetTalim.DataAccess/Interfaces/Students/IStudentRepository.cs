using GetTalim.DataAccess.Utils;
using GetTalim.DataAccess.ViewModels;
using GetTalim.Domain.Entities.Students;

namespace GetTalim.DataAccess.Interfaces.Students;

public interface IStudentRepository : IRepository<Student, Student>
{
    public Task<Student?> GetByEmailAsync(string email);
    public Task<IList<StudentViewModel>> GetAllStudentsAsync(PaginationParams @params);
    public Task<IList<StudentViewModel>> SearchStudentNameAsync(string name, PaginationParams @params);
    public Task<IList<StudentViewModel>> SearchStudentMailAsync(string mail, PaginationParams @params);
}
