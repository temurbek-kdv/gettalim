using GetTalim.DataAccess.Utils;
using GetTalim.Service.Dtos.Pagination;
using GetTalim.Service.Interfaces.Common;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace GetTalim.Service.Services.Common;

public class PaginatorService : IPaginatorService
{
    private readonly IHttpContextAccessor _accessor;

    public PaginatorService(IHttpContextAccessor httpContextAccessor)
    {
        _accessor = httpContextAccessor;
    }
    public void Paginate(long itemsCount, PaginationParams @params)
    {
        PaginationMetaData paginationMetaData = new PaginationMetaData();
        paginationMetaData.CurrentPage = @params.PageNumber;
        paginationMetaData.TotalItems = (int)itemsCount;
        paginationMetaData.PageSize = @params.PageSize;

        paginationMetaData.TotalPages = (int)Math.Ceiling((double)itemsCount / @params.PageSize);
        paginationMetaData.HasPrevious = paginationMetaData.CurrentPage > 1;
        paginationMetaData.HasNext = paginationMetaData.CurrentPage < paginationMetaData.TotalPages;

        string jsonContent = JsonConvert.SerializeObject(paginationMetaData);
        _accessor.HttpContext.Response.Headers.Add("X-Pagination", jsonContent);
    }
}
