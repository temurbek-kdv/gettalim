using GetTalim.DataAccess.Interfaces.CourseModuls;
using GetTalim.DataAccess.Interfaces.Courses;
using GetTalim.DataAccess.Utils;
using GetTalim.Domain.Entities.Courses;
using GetTalim.Domain.Exceptions.Courses;
using GetTalim.Service.Common.Helpers;
using GetTalim.Service.Dtos.CourseModuls;
using GetTalim.Service.Interfaces.CourseModuls;

namespace GetTalim.Service.Services.CourseModuls;

public class CourseModulService : ICourseModulService
{
    private readonly ICourseModulRepository _repository;

    public CourseModulService(ICourseModulRepository repository)
    {
        this._repository = repository;
    }
    public async Task<bool> CreateAsync(CourseModulCreateDto dto)
    {
        CourseModul modul  = new CourseModul();
        modul.Name = dto.Name;
        modul.CourseId = dto.CourseId;

        modul.CreatedAt = modul.UpdatedAt = TimeHelper.GetDateTime();
        var dbResult = await _repository.CreateAsync(modul);
        return dbResult > 0;
    }
    public async Task<CourseModul> GetByIdAsync(long modulId)
    {
        var modul = await _repository.GetByIdAsync(modulId);
        if (modul is null) throw new CourseModuleNotFoundException();
        else return modul;
    }

    public async Task<bool> DeleteAsync(long modulId)
    {
        var modul = await _repository.GetByIdAsync(modulId);
        if (modul is null) throw new CourseModuleNotFoundException();

        var dbResult = await _repository.DeleteAsync(modulId);
        return dbResult > 0;
    }

    public async Task<IList<CourseModul>> GetAllAsync(PaginationParams @params)
    {
        var moduls = await _repository.GetAllAsync(@params);
        return moduls;
    }


    public async Task<bool> UpdateAsync(long modulId, CourseModulUpdateDto dto)
    {
        var modul = await _repository.GetByIdAsync(modulId);
        if (modul is null) throw new CourseModuleNotFoundException();

        modul.Name = dto.Name;
        modul.CourseId = dto.CourseId;

        var dbResult = await _repository.UpdateAsync(modulId, modul);
        return dbResult > 0;
    }
}
