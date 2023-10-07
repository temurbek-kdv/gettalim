using GetTalim.DataAccess.Interfaces.Students;
using GetTalim.DataAccess.Utils;
using GetTalim.DataAccess.ViewModels;
using GetTalim.Service.Interfaces.Admin;
using GetTalim.Service.Interfaces.Common;

namespace GetTalim.Service.Services.Admin;

public class StudentAdminService : IStudentAdminService
{
    private readonly IPaginatorService _paginator;
    private readonly IStudentRepository _studentRepository;

    public StudentAdminService(IPaginatorService paginator, IStudentRepository studentRepository)
    {
        _paginator = paginator;
        _studentRepository = studentRepository;
    }
    public async Task<IList<StudentViewModel>> GetAllStudentsAsync(PaginationParams @params)
    {
        var students = await _studentRepository.GetAllStudentsAsync(@params);
        var count = await _studentRepository.CountAsync();

        _paginator.Paginate(count, @params);

        return students;
    }
}
