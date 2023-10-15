using GetTalim.DataAccess.Interfaces.CourseComments;
using GetTalim.DataAccess.Utils;
using GetTalim.DataAccess.ViewModels;
using GetTalim.Domain.Entities.Courses;
using GetTalim.Domain.Exceptions.Courses;
using GetTalim.Service.Common.Helpers;
using GetTalim.Service.Dtos.CourseComments;
using GetTalim.Service.Interfaces.Common;
using GetTalim.Service.Interfaces.CourseComments;
using GetTalim.Service.Interfaces.Students;

namespace GetTalim.Service.Services.CourseComments;

public class CourseCommentService : ICourseCommentService
{
    private readonly ICourseCommentsRepository _repository;
    private readonly IIdentityService _identityService;
    private readonly IPaginatorService _paginator;

    public CourseCommentService(ICourseCommentsRepository repository, IIdentityService service,
                                IPaginatorService paginator)
    {
        _repository = repository;
        _identityService = service;
        _paginator = paginator;
    }
    public async Task<bool> CreateAsync(CourseCommentCreateDto dto)
    {
        CourseComment courseComment = new CourseComment();

        courseComment.Comment = dto.Comment;
        courseComment.StudentId = _identityService.UserId;
        courseComment.CourseId = dto.CourseId;

        courseComment.CreatedAt = courseComment.UpdatedAt = TimeHelper.GetDateTime();

        var dbResult = await _repository.CreateAsync(courseComment);
        return dbResult > 0;
    }

    public async Task<bool> DeleteAsync(long courseCommentId)
    {
        var courseComment = await _repository.GetByIdAsync(courseCommentId);
        if (courseComment is null) throw new CourseCommentNotFoundException();
        
        if(courseComment.StudentId != _identityService.UserId)
            throw new UnauthorizedAccessException();
        
        var dbResult = await _repository.DeleteAsync(courseCommentId);
        return dbResult > 0;
    }


    public async Task<IList<CourseCommentViewModel>> GetCourseCommentsAsync(long id, PaginationParams @params)
    {
        var courseComment = await _repository.GetCourseComments(id, @params);
        if (courseComment.Count == 0) throw new CourseCommentNotFoundException();

        var count = await _repository.CountCourseCommentsAsync(id);
        _paginator.Paginate(count, @params);
        
        return courseComment;

    }

    public async Task<IList<CourseComment>> GetAllAsync(PaginationParams @params)
    {
        var courseComment = await _repository.GetAllAsync(@params);

        var count = await _repository.CountAsync();
        _paginator.Paginate(count, @params);
        
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

    public async Task<bool> DeleteAdminAsync(long courseCommentId)
    {
        var courseComment = await _repository.GetByIdAsync(courseCommentId);
        if (courseComment is null) throw new CourseCommentNotFoundException();

        var dbResult = await _repository.DeleteAsync(courseCommentId);
        return dbResult > 0;
    }
}
