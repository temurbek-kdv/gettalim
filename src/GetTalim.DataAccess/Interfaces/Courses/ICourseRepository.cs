using GetTalim.DataAccess.Common.Interfaces;
using GetTalim.DataAccess.Utils;
using GetTalim.Domain.Entities.Courses;

namespace GetTalim.DataAccess.Interfaces.Courses;

public interface ICourseRepository : IRepository<Course, Course>, IGetAll<Course>, ISearchAble<Course>
{
    Task<List<Course>> GetCoursesByCategory(long categoryId, PaginationParams @params);
    Task<long> CountCourseByCategory(long categoryId);
}
