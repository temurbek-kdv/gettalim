using GetTalim.DataAccess.ViewModels;

namespace GetTalim.DataAccess.Interfaces.CourseViewModels;

public interface ICourseViewModelRepository
{
    public Task<IList<CourseViewModel?>> GetCourseViewByIdAsync(long id);
}
