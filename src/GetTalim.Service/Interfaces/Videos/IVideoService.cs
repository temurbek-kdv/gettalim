using GetTalim.DataAccess.Utils;
using GetTalim.Domain.Entities.Videos;
using GetTalim.Service.Dtos.Videos;

namespace GetTalim.Service.Interfaces.Videos;

public interface IVideoService
{
    public Task<bool> CreateAsync(VideoCreateDto dto);
    public Task<bool> DeleteAsync(long videoId);
    public Task<long> CountAsync();
    public Task<IList<Video>> GetAllAsync(PaginationParams @params);
    public Task<Video> GetByIdAsync(long videoId);
    public Task<bool> UpdateAsync(long videoId, VideoUpdateDto dto);
}
