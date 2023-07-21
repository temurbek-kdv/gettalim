using GetTalim.DataAccess.Common.Interfaces;
using GetTalim.Domain.Entities.Courses;

namespace GetTalim.DataAccess.Interfaces.CourseRequierments;

public interface ICourseRequiermentRepository : IRepository<CourseRequirment, CourseRequirment>, IGetAll<CourseRequirment>
{
}
