using GetTalim.DataAccess.Interfaces.CourseViewModels;
using GetTalim.DataAccess.Repositories.CourseViewModels;
using GetTalim.DataAccess.ViewModels;
using GetTalim.Domain.Exceptions.Courses;
using GetTalim.Service.Interfaces.CourseViewModels;

namespace GetTalim.Service.Services.CourseViewModels;

public class CourseViewModelService : ICourseViewModelService
{
    private readonly ICourseViewModelRepository _repository;

    public CourseViewModelService(ICourseViewModelRepository repository)
    {
        this._repository = repository;
    }
    public async Task<IList<CourseViewModel>> GetGetCourseViewByIdAsync(long Id)
    {
       var view = await _repository.GetCourseViewByIdAsync(Id);
        if (view is null) throw new CourseNotFoundException();
        
        return view;
    }
}
