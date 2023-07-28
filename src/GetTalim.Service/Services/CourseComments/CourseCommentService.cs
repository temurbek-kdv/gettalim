using GetTalim.DataAccess.Interfaces.CourseComments;
using GetTalim.DataAccess.Utils;
using GetTalim.Domain.Entities.Courses;
using GetTalim.Domain.Exceptions.Courses;
using GetTalim.Service.Common.Helpers;
using GetTalim.Service.Dtos.CourseComments;
using GetTalim.Service.Interfaces.CourseComments;
using GetTalim.Service.Interfaces.Students;

namespace GetTalim.Service.Services.CourseComments;

public class CourseCommentService : ICourseCommentService
{
    private readonly ICourseCommentsRepository _repository;
    private readonly IIdentityService _service;

    public CourseCommentService(ICourseCommentsRepository repository, IIdentityService service)
    {
        this._repository = repository;
        this._service = service;
    }
    public async Task<bool> CreateAsync(CourseCommentCreateDto dto)
    {
        CourseComment courseComment = new CourseComment();

        courseComment.Comment = dto.Comment;
        courseComment.StudentId = _service.UserId;
        courseComment.CourseId = dto.CourseId;

        courseComment.CreatedAt = courseComment.UpdatedAt = TimeHelper.GetDateTime();

        var dbResult = await _repository.CreateAsync(courseComment);
        return dbResult > 0;
    }

    public async Task<bool> DeleteAsync(long courseCommentId)
    {
        var courseComment = await _repository.GetByIdAsync(courseCommentId);
        if (courseComment is null) throw new CourseCommentNotFoundException();

        var dbResult = await _repository.DeleteAsync(courseCommentId);
        return dbResult > 0;


    }

    public async Task<IList<CourseComment>> GetAllAsync(PaginationParams @params)
    {
        var courseComment = await _repository.GetAllAsync(@params);

        /*
            Pagination
         */
        return courseComment;
    }

    public async Task<CourseComment> GetByIdAsync(long courseCommentId)
    {
        var courseComment = await _repository.GetByIdAsync(courseCommentId);
        if (courseComment is null) throw new CourseCommentNotFoundException();
        else return courseComment;

    }

    public Task<bool> UpdateAsync(long courseCommentId, CourseCommentCreateDto dto)
    {
        throw new NotImplementedException();
    }
    public Task<long> CountAsync()
    {
        throw new NotImplementedException();
    }

}
