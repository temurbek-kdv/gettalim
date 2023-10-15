using GetTalim.DataAccess.Interfaces.CourseModuls;
using GetTalim.DataAccess.Interfaces.Videos;
using GetTalim.DataAccess.Utils;
using GetTalim.Domain.Entities.Videos;
using GetTalim.Domain.Exceptions.Courses;
using GetTalim.Domain.Exceptions.Videos;
using GetTalim.Service.Common.Helpers;
using GetTalim.Service.Dtos.Videos;
using GetTalim.Service.Interfaces.Videos;

namespace GetTalim.Service.Services.Videos;

public class VideoService : IVideoService
{
    private readonly IVideoRepository _repository;
    private readonly ICourseModulRepository _modulRepository;

    public VideoService(IVideoRepository repository, ICourseModulRepository modulRepository)
    {
        _repository = repository;
        _modulRepository = modulRepository;
    }
  

    public async Task<bool> CreateAsync(VideoCreateDto dto)
    {
        Video video = new Video();
        video.Name = dto.Name;
        video.CourseModulId = dto.CourseModulId;
        video.Length = dto.Length;
        video.VideoPath = dto.VideoPath;
        video.CourseModulId = dto.CourseModulId;
        video.CreatedAt = video.UpdatedAt = TimeHelper.GetDateTime();

        var dbResult = await _repository.CreateAsync(video);
        return dbResult > 0;
    }
    public async Task<Video> GetByIdAsync(long videoId)
    {
        var video = await _repository.GetByIdAsync(videoId);
        if (video is null) throw new VideoNotFoundException();
        else return video;
    }

    public async Task<bool> DeleteAsync(long videoId)
    {
        var video = await _repository.GetByIdAsync(videoId);
        if (video is null) throw new VideoNotFoundException();
        var result = await _repository.DeleteAsync(videoId);
        return result > 0;
    }


    public async Task<IList<Video>> GetAllAsync(PaginationParams @params)
    {
        var videos = await _repository.GetAllAsync(@params);

        return videos;
    }

    public async Task<bool> UpdateAsync(long videoId, VideoUpdateDto dto)
    {
        var video = await _repository.GetByIdAsync(videoId);
        if (video is null) throw new VideoNotFoundException();

        video.Length = dto.Length;
        video.VideoPath = dto.VideoPath;
        video.CourseModulId = dto.CourseModulId;
        video.UpdatedAt = TimeHelper.GetDateTime();
        video.Name = dto.Name;
        var dbResult = await _repository.UpdateAsync(videoId, video);
        return dbResult > 0;
    }
    public Task<long> CountAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<IList<Video>> GetVideoByModuleIdAsync(long moduleId)
    {
        var modul = await _modulRepository.GetByIdAsync(moduleId);
        if (modul is null) throw new CourseModuleNotFoundException();

        var videos = await _repository.GetVideoByModuleIdAsync(moduleId);
        return videos;
    }
}
