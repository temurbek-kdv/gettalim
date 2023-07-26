using GetTalim.DataAccess.Common.Interfaces;
using GetTalim.Domain.Entities.Videos;

namespace GetTalim.DataAccess.Interfaces.Videos;

public interface IVideoRepository : IRepository<Video, Video>, IGetAll<Video>
{

}
