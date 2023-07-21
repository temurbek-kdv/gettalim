using GetTalim.DataAccess.Utils;
using GetTalim.Domain.Entities.Courses;
using GetTalim.Service.Dtos.Courses;

namespace GetTalim.Service.Interfaces.Courses;

public interface ICourseService
{
    public Task<bool> CreateAsync(CourseCreateDto dto);

    public Task<bool> DeleteAsync(long courseId);

    public Task<long> CountAsync();

    public Task<IList<Course>> GetAllAsync(PaginationParams @params);

    public Task<Course> GetByIdAsync(long courseId);

    public Task<bool> UpdateAsync(long courseId, CourseUpdateDto dto);
}
