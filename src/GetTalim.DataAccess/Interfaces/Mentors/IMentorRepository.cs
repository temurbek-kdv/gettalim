using GetTalim.DataAccess.Common.Interfaces;
using GetTalim.Domain.Entities.Courses;
using GetTalim.Domain.Entities.Mentors;

namespace GetTalim.DataAccess.Interfaces.Mentors;

public interface IMentorRepository: IRepository<Mentor, Mentor>, IGetAll<Mentor>
{
    public Task<IList<Course>> GetMentorsCourses(long mentorId);
}
