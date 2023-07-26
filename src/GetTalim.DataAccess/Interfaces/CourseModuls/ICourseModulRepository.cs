using GetTalim.DataAccess.Common.Interfaces;
using GetTalim.Domain.Entities.Courses;

namespace GetTalim.DataAccess.Interfaces.CourseModuls;

public interface ICourseModulRepository : IRepository<CourseModul,CourseModul>, IGetAll<CourseModul>
{
}
