using GetTalim.DataAccess.Common.Interfaces;
using GetTalim.Domain.Entities.Courses;

namespace GetTalim.DataAccess.Interfaces.CourseBenefits;

public interface ICourseBenefitRepository : IRepository<CourseBenefit, CourseBenefit>, IGetAll<CourseBenefit>
{
    public Task<IList<CourseBenefit>> GetCourcseBenefitsAsync(long id);
}
