using GetTalim.DataAccess.Common.Interfaces;
using GetTalim.DataAccess.Utils;
using GetTalim.Domain.Entities.Courses;

namespace GetTalim.DataAccess.Interfaces.Courses;

public interface ICourseRepository : IRepository<Course, Course>, IGetAll<Course>, ISearchAble<Course>
{
    Task<long> CountCourseByCategory(long categoryId);
    Task<List<Course>> GetCoursesByCategory(long categoryId, PaginationParams @params);
    Task<long> CountSearchedCoursesNameAsync(string name);
    Task<List<Course>> GetSearchedCoursesNameAsync(string name, PaginationParams @params);
}
