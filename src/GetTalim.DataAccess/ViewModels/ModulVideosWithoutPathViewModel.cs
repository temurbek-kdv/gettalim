using GetTalim.Domain.Entities;
using GetTalim.Domain.Entities.Videos;

namespace GetTalim.DataAccess.ViewModels;

public class ModulVideosWithoutPathViewModel : Auditable
{
    public string Name { get; set; } = string.Empty;
    public long CourseId { get; set; }
    public List<VideoWithoutPath>? videos { get; set; } = new List<VideoWithoutPath>();
}
