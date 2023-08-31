
using GetTalim.DataAccess.ViewModels;

namespace GetTalim.Service.Interfaces.CourseViewModels;

public interface ICourseViewModelService
{
    public Task<CourseViewModel> GetCourcseBenefitsAsync(long Id);

}
