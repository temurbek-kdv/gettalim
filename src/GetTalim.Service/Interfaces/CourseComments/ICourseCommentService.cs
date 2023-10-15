using GetTalim.DataAccess.Utils;
using GetTalim.DataAccess.ViewModels;
using GetTalim.Domain.Entities.Courses;
using GetTalim.Service.Dtos.CourseComments;

namespace GetTalim.Service.Interfaces.CourseComments;

public interface ICourseCommentService
{
    public Task<bool> CreateAsync(CourseCommentCreateDto dto);
    public Task<CourseComment> GetByIdAsync(long courseCommentId);
    public Task<bool> DeleteAsync(long courseCommentId);
    public Task<bool> DeleteAdminAsync(long courseCommentId);
    public Task<IList<CourseComment>> GetAllAsync(PaginationParams @params);
    public Task<bool> UpdateAsync(long courseCommentId, CourseCommentCreateDto dto);
    public Task<long> CountAsync();
    public Task<IList<CourseCommentViewModel>> GetCourseCommentsAsync(long id, PaginationParams @params);
}
