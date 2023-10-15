using GetTalim.DataAccess.Common.Interfaces;
using GetTalim.DataAccess.Utils;
using GetTalim.DataAccess.ViewModels;
using GetTalim.Domain.Entities.Courses;

namespace GetTalim.DataAccess.Interfaces.CourseComments;

public interface ICourseCommentsRepository : IRepository<CourseComment, CourseComment>, IGetAll<CourseComment>
{
    public Task<IList<CourseCommentViewModel>> GetCourseComments(long Id, PaginationParams @params);
    public Task<long> CountCourseCommentsAsync(long courseId);
}
