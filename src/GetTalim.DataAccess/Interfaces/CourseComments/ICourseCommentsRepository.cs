using GetTalim.DataAccess.Common.Interfaces;
using GetTalim.DataAccess.Utils;
using GetTalim.Domain.Entities.Courses;

namespace GetTalim.DataAccess.Interfaces.CourseComments;

public interface ICourseCommentsRepository : IRepository<CourseComment, CourseComment>, IGetAll<CourseComment>
{
    public Task<IList<CourseComment>> GetCourseComments(long Id, PaginationParams @params);
    public Task<long> CountCourseCommentsAsync(long courseId);
}
