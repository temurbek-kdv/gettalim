
using GetTalim.DataAccess.ViewModels;
using GetTalim.Domain.Entities.Courses;

namespace GetTalim.DataAccess.Interfaces.CourseViewModels;

public interface ICourseViewModelRepository : IRepository<CourseBenefit, Course>
{
    public Task<IList<Course?>> GetCourseViewByIdAsync(long id);
    public Task<IList<CourseBenefit?>> GetCourseBenefitsByIdAsync(long id);
}
