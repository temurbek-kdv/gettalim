using GetTalim.DataAccess.Utils;
using GetTalim.DataAccess.ViewModels;

namespace GetTalim.Service.Interfaces.Admin;

public interface IStudentAdminService
{
    public Task<IList<StudentViewModel>> GetAllStudentsAsync(PaginationParams @params);
}
