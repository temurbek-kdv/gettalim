using GetTalim.DataAccess.Common.Interfaces;
using GetTalim.DataAccess.Utils;
using GetTalim.Domain.Entities.Categoires;
using GetTalim.Domain.Entities.Courses;

namespace GetTalim.DataAccess.Interfaces.Categories;

public interface ICategoryRepository:IRepository<Category,Category>, IGetAll<Category>
{
}
