using GetTalim.DataAccess.Interfaces.CourseComments;
using GetTalim.DataAccess.Interfaces.CourseRequierments;
using GetTalim.DataAccess.Utils;
using GetTalim.Domain.Entities.Courses;
using GetTalim.Domain.Exceptions.Courses;
using GetTalim.Service.Common.Helpers;
using GetTalim.Service.Dtos.CourseRequirments;
using GetTalim.Service.Interfaces.CourseRequirments;

namespace GetTalim.Service.Services.CourseRequirments;

public class CourseRequirmentService : ICourseRequirmentService
{
    private readonly ICourseRequiermentRepository _repository;

    public CourseRequirmentService(ICourseRequiermentRepository repository)
    {
         this._repository = repository;
    }
    public async Task<bool> CreateAsync(CourseRequirmentCreateDto dto)
    {
        CourseRequirment courseRequirment = new CourseRequirment();
        courseRequirment.Requirment = dto.Requirment;
        courseRequirment.CourseId = dto.CourseId;
        courseRequirment.CreatedAt = courseRequirment.UpdatedAt = TimeHelper.GetDateTime();

        var dbResult = await _repository.CreateAsync(courseRequirment);
        return dbResult > 0;
        
    }

    public async Task<bool> DeleteAsync(long Id)
    {
        var courseRequirment = await _repository.GetByIdAsync(Id);
        if (courseRequirment is null) throw new CourseRequirmentsNotFoundException();

        var dbResult = await _repository.DeleteAsync(Id);
        return dbResult > 0;
    }

    public async Task<IList<CourseRequirment>> GetAllAsync(PaginationParams @params)
    {
        var courseRequirment = await _repository.GetAllAsync(@params);

        /*
            Pagination
         */
        return courseRequirment;
    }

    public async Task<CourseRequirment> GetByIdAsync(long Id)
    {
        var courseRequirment = await _repository.GetByIdAsync(Id);
        if (courseRequirment is null) throw new CourseCommentNotFoundException();
        else return courseRequirment;
    }

 
}
