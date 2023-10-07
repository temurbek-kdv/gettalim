using GetTalim.DataAccess.Interfaces.Students;
using GetTalim.DataAccess.Utils;
using GetTalim.DataAccess.ViewModels;
using GetTalim.Domain.Entities.Students;
using GetTalim.Domain.Exceptions.Students;
using GetTalim.Service.Common.Helpers;
using GetTalim.Service.Dtos.Student;
using GetTalim.Service.Interfaces.Common;
using GetTalim.Service.Interfaces.Students;
using System.Xml.Linq;

namespace GetTalim.Service.Services.Students;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;
    private readonly IFileService _fileService;
    private readonly IPaginatorService _paginator;

    public StudentService(IStudentRepository studentRepository, IFileService fileService,
                           IPaginatorService paginator)
    {
        _studentRepository = studentRepository;
        _fileService = fileService;
        _paginator = paginator;
    }

    public async Task<bool> DeleteAsync(long studentId)
    {
        var student = await _studentRepository.GetByIdAsync(studentId);
        if(student is null) throw new StudentNotFoundException();

        var result = await _studentRepository.DeleteAsync(studentId);

        return result > 0;
    }

    public async Task<IList<StudentViewModel>> SearchStudentMailAsync(string mail, PaginationParams @params)
    {
        if (mail.Contains("'"))
        {
            mail = mail.Replace("'", "''");
        }

        var students = await _studentRepository.SearchStudentMailAsync(mail, @params);
        var count = students.Count();

        _paginator.Paginate(count, @params);

        return students;
    }

    public async Task<IList<StudentViewModel>> SearchStudentNameAsync(string name, PaginationParams @params)
    {
        if (name.Contains("'"))
        {
            name = name.Replace("'", "''");
        }

        var students = await _studentRepository.SearchStudentNameAsync(name, @params);
        var count = students.Count();

        _paginator.Paginate(count, @params);
        
        return students;
    }
    

    public async Task<bool> UpdateAsync(long studentId, StudentUpdateDto updateDto)
    {
        var student = await _studentRepository.GetByIdAsync(studentId);
        if (student is null) throw new StudentNotFoundException();
        
        Student entity = new Student();
        entity.FirstName = updateDto.FirstName;
        entity.LastName = updateDto.LastName;
        entity.PhoneNumber = updateDto.PhoneNumber;
        entity.UpdatedAt = TimeHelper.GetDateTime();
        
        if(updateDto.ImagePath is not null)
        {
            if(student.ImagePath.Length != 0)
            {
                await _fileService.DeleteAvatarAsync(student.ImagePath);
            }
            entity.ImagePath = await _fileService.UploadAvatarAsync(updateDto.ImagePath);
        }
        
        var dbResult = await _studentRepository.UpdateAsync(studentId, entity);

        return dbResult > 0;
    }
}
