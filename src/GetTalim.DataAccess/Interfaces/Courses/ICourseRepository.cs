using GetTalim.DataAccess.Common.Interfaces;
using GetTalim.Domain.Entities.Courses;
using GetTalim.Domain.Entities.Students;

namespace GetTalim.DataAccess.Interfaces.Courses;

public interface ICourseRepository : IRepository<Course, Course>, IGetAll<Course>, ISearchAble<Course>
{

}
