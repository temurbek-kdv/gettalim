using GetTalim.DataAccess.Utils;
using GetTalim.Domain.Entities.Courses;
using GetTalim.Service.Dtos.CourseBenefits;

namespace GetTalim.Service.Interfaces.CourseBenefits;

public interface ICourseBenefitService
{
    public Task<bool> CreateAsync(CourseBenefitCreateDto dto);
    public Task<bool> DeleteAsync(long Id);
    public Task<long> CountAsync();
    public Task<IList<CourseBenefit>> GetAllAsync(PaginationParams @params);
    public Task<CourseBenefit> GetByIdAsync(long Id);
    public Task<bool> UpdateAsync(long Id, CourseBenefitCreateDto dto);
}
