using GetTalim.DataAccess.Interfaces.CourseModuls;
using GetTalim.DataAccess.Interfaces.Videos;
using GetTalim.DataAccess.Utils;
using GetTalim.DataAccess.ViewModels;
using GetTalim.Domain.Entities.Courses;
using GetTalim.Domain.Entities.Videos;
using GetTalim.Domain.Exceptions.Courses;
using GetTalim.Service.Common.Helpers;
using GetTalim.Service.Dtos.CourseModuls;
using GetTalim.Service.Interfaces.CourseModuls;

namespace GetTalim.Service.Services.CourseModuls;

public class CourseModulService : ICourseModulService
{
    private readonly ICourseModulRepository _repository;
    private readonly IVideoRepository _videoRepository;

    public CourseModulService(ICourseModulRepository repository, IVideoRepository videoRepository)
    {
        this._repository = repository;
        _videoRepository = videoRepository;
    }
    public async Task<bool> CreateAsync(CourseModulCreateDto dto)
    {
        CourseModul modul = new CourseModul();
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

    public async Task<IList<ModulwithVideosViewModel>> GetModulVideosAsync(long courseId)
    {
        List<ModulwithVideosViewModel> listModul = new List<ModulwithVideosViewModel>();


        var modules = await _repository.GetByCourseIdAsync(courseId);
            ModulwithVideosViewModel modulwithVideosViewModel = new ModulwithVideosViewModel();
        foreach (var modul in modules)
        {
            modulwithVideosViewModel.Name = modul.Name;
            modulwithVideosViewModel.CourseId = modul.CourseId;
            modulwithVideosViewModel.UpdatedAt = modul.UpdatedAt;
            modulwithVideosViewModel.CreatedAt = modul.CreatedAt;
            modulwithVideosViewModel.Id = modul.Id;
            var videos = await _videoRepository.GetVideoByModuleIdAsync(modul.Id);
            if (videos is not  null) 
                modulwithVideosViewModel.Videos.AddRange(videos);
            listModul.Add(modulwithVideosViewModel);
        }

        return listModul;
    }

    public async Task<IList<ModulVideosWithoutPathViewModel>> GetModulVideosCommonAsync(long courseId)
    {
        List<ModulVideosWithoutPathViewModel> listModul = new List<ModulVideosWithoutPathViewModel>();
        var modules = await _repository.GetByCourseIdAsync(courseId);
        
        ModulVideosWithoutPathViewModel modulwithVideosViewModel = new ModulVideosWithoutPathViewModel();

        foreach (var modul in modules)
        {
            modulwithVideosViewModel.Name = modul.Name;
            modulwithVideosViewModel.CourseId = modul.CourseId;
            modulwithVideosViewModel.UpdatedAt = modul.UpdatedAt;
            modulwithVideosViewModel.CreatedAt = modul.CreatedAt;
            modulwithVideosViewModel.Id = modul.Id;
            var videos = await _videoRepository.GetVideoForCommonAsync(modul.Id);
            if (videos is not null)
                modulwithVideosViewModel.videos.AddRange(videos);
            listModul.Add(modulwithVideosViewModel);
        }

        return listModul;
    }
}
