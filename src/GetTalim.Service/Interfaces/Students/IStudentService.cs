using GetTalim.DataAccess.Utils;
using GetTalim.Domain.Entities.Categoires;
using GetTalim.Service.Dtos.Categories;

namespace GetTalim.Service.Interfaces.Students;
public interface IStudentService
{
    //public Task<bool> CreateAsync(StudentCreateDto dto);
    public Task<bool> DeleteAsync(long StudentId);
    public Task<long> CountAsync();
    public Task<IList<Category>> GetAllAsync(PaginationParams @params);
    public Task<Category> GetByIdAsync(long StudentId);
    //public Task<bool> UpdateAsync(long categoryId, StudentCreateDto dto);
}
