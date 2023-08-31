using Dapper;
using GetTalim.DataAccess.Interfaces.CourseViewModels;
using GetTalim.DataAccess.ViewModels;
using GetTalim.Domain.Entities.Courses;

namespace GetTalim.DataAccess.Repositories.CourseViewModels;

public class CourseViewModelRepository : BaseRepository, ICourseViewModelRepository
{
    public Task<long> CountAsync()
    {
        throw new NotImplementedException();
    }

    public Task<int> CreateAsync(CourseBenefit entity)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<Course?> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IList<CourseBenefit?>> GetCourseBenefitsByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IList<Course?>> GetCourseViewByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdateAsync(long id, CourseBenefit entity)
    {
        throw new NotImplementedException();
    }
}
