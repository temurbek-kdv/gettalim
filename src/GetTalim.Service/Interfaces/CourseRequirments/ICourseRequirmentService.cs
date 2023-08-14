using GetTalim.DataAccess.Utils;
using GetTalim.Domain.Entities.Courses;
using GetTalim.Service.Dtos.CourseRequirments;

namespace GetTalim.Service.Interfaces.CourseRequirments;

public interface ICourseRequirmentService
{
    public Task<bool> CreateAsync(CourseRequirmentCreateDto dto);
    public Task<bool> DeleteAsync(long Id);
    public Task<IList<CourseRequirment>> GetAllAsync(PaginationParams @params);
    public Task<CourseRequirment> GetByIdAsync(long Id);
    public Task<IList<CourseRequirment>> GetCourseRequirmentsAsync(long Id);
}
