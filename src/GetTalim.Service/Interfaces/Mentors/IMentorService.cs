using GetTalim.DataAccess.Utils;
using GetTalim.Domain.Entities.Mentors;
using GetTalim.Service.Dtos.Mentors;

namespace GetTalim.Service.Interfaces.Mentors;

public interface  IMentorService
{
    public Task<bool> CreateAsync(MentorCreateDto dto);
    public Task<bool> DeleteAsync(long mentorId);
    public Task<long> CountAllAsync();
    public Task<IList<Mentor>> GetAllAsync(PaginationParams @params);
    public Task<Mentor> GetByIdAsync (long mentorId);
    public Task<bool> UpdateAsync(long mentorId, MentorUpdateDto dto);
}
