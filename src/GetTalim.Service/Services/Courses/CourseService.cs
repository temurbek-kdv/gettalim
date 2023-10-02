using GetTalim.DataAccess.Interfaces.Courses;
using GetTalim.DataAccess.Utils;
using GetTalim.Domain.Entities.Courses;
using GetTalim.Domain.Exceptions.Courses;
using GetTalim.Service.Common.Helpers;
using GetTalim.Service.Dtos.Courses;
using GetTalim.Service.Interfaces.Common;
using GetTalim.Service.Interfaces.Courses;

namespace GetTalim.Service.Services.Courses;

public class CourseService : ICourseService
{
    private readonly ICourseRepository _repository;
    private readonly IPaginatorService _paginator;
    private readonly IFileService _fileService;

    public CourseService(ICourseRepository courseRepository,
        IFileService fileService, IPaginatorService paginator)
    {
        this._fileService = fileService;
        this._repository = courseRepository;
        _paginator = paginator;
    }


    public async Task<bool> CreateAsync(CourseCreateDto dto)
    {
        string imagepath = await _fileService.UploadImageAsync(dto.Image);

        Course course = new Course();

        course.Name = dto.Name;
        course.Description = dto.Description;
        course.Information = dto.Information;
        course.Price = dto.Price;
        course.DiscountPrice = dto.DiscountPrice;
        course.ImagePath = imagepath;
        course.CategoryId = dto.CategoryId;
        course.MentorId = dto.MentorId;
        course.Level = dto.Level.ToString();
        course.Lessons = dto.Lessons;
        course.Language = dto.Language.ToString();
        course.Hours = dto.Hourse;
        course.CreatedAt = course.UpdatedAt = TimeHelper.GetDateTime();

        var dbResult = await _repository.CreateAsync(course);
        return dbResult > 0;

    }
    public async Task<Course> GetByIdAsync(long courseId)
    {
        var courses = await _repository.GetByIdAsync(courseId);
        if (courses is null) throw new CourseNotFoundException();
        else return courses;
    }

    public async Task<bool> DeleteAsync(long courseId)
    {
        var course = await _repository.GetByIdAsync(courseId);
        if (course is null) throw new CourseNotFoundException();
        else
        {
            await _fileService.DeleteImageAsync(course.ImagePath);
            var result = await _repository.DeleteAsync(courseId);
            return result > 0;
        }

    }

    public async Task<IList<Course>> GetAllAsync(PaginationParams @params)
    {
        var courses = await _repository.GetAllAsync(@params);
        var count = await _repository.CountAsync();
        _paginator.Paginate(count, @params);
        
        return courses;
    }



    public async Task<bool> UpdateAsync(long courseId, CourseUpdateDto dto)
    {
        var course = await _repository.GetByIdAsync(courseId);
        if (course is null) throw new CourseNotFoundException();

        course.Name = dto.Name;
        course.Description = dto.Description;
        course.Information = dto.Information;
        course.Price = dto.Price;
        course.DiscountPrice = dto.DiscountPrice;
        course.CategoryId = dto.CategoryId;
        course.MentorId = dto.MentorId;
        course.Level = dto.Level.ToString();
        course.Lessons = dto.Lessons;
        course.Language = dto.Language.ToString();
        course.Hours = dto.Hourse;
        course.UpdatedAt = TimeHelper.GetDateTime();

        if (dto.Image is not null)
        {
            await _fileService.DeleteImageAsync(course.ImagePath);
            course.ImagePath = await _fileService.UploadImageAsync(dto.Image);
        }

        var dbResult = await _repository.UpdateAsync(courseId, course);
        return dbResult > 0;

    }
    public async Task<long> CountAsync() => await _repository.CountAsync();

}
