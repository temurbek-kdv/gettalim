using GetTalim.DataAccess.Interfaces.CourseBenefits;
using GetTalim.DataAccess.Utils;
using GetTalim.Domain.Entities.Courses;
using GetTalim.Domain.Exceptions.Courses;
using GetTalim.Service.Common.Helpers;
using GetTalim.Service.Dtos.CourseBenefits;
using GetTalim.Service.Interfaces.CourseBenefits;

namespace GetTalim.Service.Services.CourseBenefits;

public class CourseBenefitService : ICourseBenefitService
{
    private readonly ICourseBenefitRepository _repository;

    public CourseBenefitService(ICourseBenefitRepository repository)
    {
        this._repository = repository;
    }

    public async Task<bool> CreateAsync(CourseBenefitCreateDto dto)
    {
        CourseBenefit benefit = new CourseBenefit();
        benefit.Name = dto.Name;
        benefit.CourseId = dto.CourseId;
        benefit.CreatedAt = benefit.UpdatedAt = TimeHelper.GetDateTime();

        var result = await _repository.CreateAsync(benefit);
        return result > 0;
    }

    public async Task<bool> DeleteAsync(long Id)
    {
        var benefit = await _repository.GetByIdAsync(Id);
        if (benefit is null) throw new CourseBenefitNotFoundException();

        var result = await _repository.DeleteAsync(Id);
        return result > 0;
    }

    public async Task<IList<CourseBenefit>> GetAllAsync(PaginationParams @params)
    {
        var benefits = await _repository.GetAllAsync(@params);
        if (benefits is null) throw new CourseBenefitNotFoundException();

        return benefits;
    }

    public async Task<CourseBenefit> GetByIdAsync(long Id)
    {
        var benefit = await _repository.GetByIdAsync(Id);
        if (benefit is null) throw new CourseBenefitNotFoundException();

        return benefit;
    }

    public Task<bool> UpdateAsync(long Id, CourseBenefitCreateDto dto)
    {
        throw new NotImplementedException();
    }
    public Task<long> CountAsync()
    {
        throw new NotImplementedException();
    }
}
