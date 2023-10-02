using GetTalim.DataAccess.Utils;

namespace GetTalim.Service.Interfaces.Common;

public interface IPaginatorService
{
    public void Paginate(long itemsCount, PaginationParams @params);
}
