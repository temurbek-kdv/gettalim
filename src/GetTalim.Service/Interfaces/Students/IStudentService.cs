using GetTalim.DataAccess.Utils;
using GetTalim.DataAccess.ViewModels;
using GetTalim.Service.Dtos.Student;

namespace GetTalim.Service.Interfaces.Students;

public interface IStudentService
{
    public Task<bool> UpdateAsync(long studentId, StudentUpdateDto updateDto);
    public Task<bool> DeleteAsync(long studentId);
    public Task<IList<StudentViewModel>> SearchStudentNameAsync(string name, PaginationParams @params);
    public Task<IList<StudentViewModel>> SearchStudentMailAsync(string mail, PaginationParams @params);
}
