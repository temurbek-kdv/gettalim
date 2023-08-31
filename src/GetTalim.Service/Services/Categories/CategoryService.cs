using AutoMapper;
using GetTalim.DataAccess.Interfaces.Categories;
using GetTalim.DataAccess.Utils;
using GetTalim.Domain.Entities.Categoires;
using GetTalim.Domain.Exceptions.Categories;
using GetTalim.Service.Common.Helpers;
using GetTalim.Service.Dtos.Categories;
using GetTalim.Service.Interfaces.Categories;

namespace GetTalim.Service.Services.Categories;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _repository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository repository, IMapper mapper)
    {
        this._repository = repository;
        this._mapper = mapper;
    }

    public async Task<long> CountAsync() => await _repository.CountAsync();

    public async Task<bool> CreateAsync(CategoryCreateDto dto)
    {
        Category category = _mapper.Map<Category>(dto);
        category.CreatedAt = TimeHelper.GetDateTime();
        category.UpdatedAt = TimeHelper.GetDateTime();
        

        var result = await _repository.CreateAsync(category);
        return result > 0;
    }



    public async Task<bool> DeleteAsync(long categoryId)
    {
        var category = await _repository.GetByIdAsync(categoryId);
        if (category is null) throw new CategoryNotFoundException();

        var dbResult = await _repository.DeleteAsync(categoryId);
        return dbResult > 0;
    }



    public async Task<IList<Category>> GetAllAsync(PaginationParams @params)
    {
        var categories = await _repository.GetAllAsync(@params);
        return categories;
    }

    public async Task<Category> GetByIdAsync(long categoryId)
    {
        var category = await _repository.GetByIdAsync(categoryId);
        if (category is null) throw new CategoryNotFoundException();
        else return category;
    }

    public async Task<bool> UpdateAsync(long categoryId, CategoryUpdateDto dto)
    {

        var category = await _repository.GetByIdAsync(categoryId);
        if (category is null) throw new CategoryNotFoundException();

        category.Name = dto.Name;
        category.Description = dto.Description;

        category.UpdatedAt = TimeHelper.GetDateTime();
        var dbResult = await _repository.UpdateAsync(categoryId, category);

        return dbResult > 0;

    }


}

