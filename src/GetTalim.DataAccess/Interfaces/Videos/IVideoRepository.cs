using GetTalim.DataAccess.Common.Interfaces;
using GetTalim.Domain.Entities.Videos;

namespace GetTalim.DataAccess.Interfaces.Videos;

public interface IVideoRepository : IRepository<Video, Video>, IGetAll<Video>
{
    public Task<IList<Video>> GetVideoByModuleIdAsync(long moduleId);
    public Task<IList<VideoWithoutPath>> GetVideoForCommonAsync(long moduleId);
}
