using GetTalim.DataAccess.Utils;

namespace GetTalim.DataAccess.Interfaces;

public interface ISearchAble<TModel>
{
    public Task<(int ItemsCount, IList<TModel>)> SearchAsync(string search, PaginationParams @params);
}
