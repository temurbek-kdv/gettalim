using GetTalim.DataAccess.Common.Interfaces;
using GetTalim.Domain.Entities.Students;

namespace GetTalim.DataAccess.Interfaces.Students;

public interface IStudentRepository:IRepository<Student , Student>, IGetAll<Student>
{

}
