using GetTalim.Domain.Entities;
using GetTalim.Domain.Entities.Videos;

namespace GetTalim.DataAccess.ViewModels;

public class ModulwithVideosViewModel : Auditable
{
    public string Name { get; set; } = string.Empty;
    public long CourseId { get; set; }
    public List<Video>? Videos { get; set; } = new List<Video>();
}
