using GetTalim.DataAccess.Common.Interfaces;
using GetTalim.Domain.Entities.Categoires;

namespace GetTalim.DataAccess.Interfaces.Categories;

public interface ICategoryRepository:IRepository<Category,Category>, IGetAll<Category>
{

}
