using AutoMapper;
using GetTalim.DataAccess.Interfaces.Mentors;
using GetTalim.DataAccess.Utils;
using GetTalim.Domain.Entities.Mentors;
using GetTalim.Domain.Exceptions.Mentors;
using GetTalim.Service.Common.Helpers;
using GetTalim.Service.Dtos.Mentors;
using GetTalim.Service.Interfaces.Common;
using GetTalim.Service.Interfaces.Mentors;

namespace GetTalim.Service.Services.Mentors;

public class MentorService : IMentorService
{
    private readonly IMentorRepository _repository;
    private readonly IFileService _fileservice;
    private readonly IMapper _mapper;

    public MentorService(IMentorRepository repository, 
        IFileService fileService,
        IMapper mapper)
    {
        this._repository = repository;
        this._fileservice = fileService;
        this._mapper = mapper;
    }

    public async Task<bool> CreateAsync(MentorCreateDto dto)
    {
        Mentor mentor = _mapper.Map<Mentor>(dto);
        mentor.ImagePath = await _fileservice.UploadAvatarAsync(dto.Image);
        mentor.CreatedAt = mentor.UpdatedAt = TimeHelper.GetDateTime();
        var  dbResult = await _repository.CreateAsync(mentor);
        return dbResult > 0;
    }

    public async Task<Mentor> GetByIdAsync(long mentorId)
    {
        var mentor =  await _repository.GetByIdAsync(mentorId);
        if (mentor is null) throw new MentorNotFoundException();
        else return mentor;
    }
    public async Task<bool> DeleteAsync(long mentorId)
    {
        var mentor = await _repository.GetByIdAsync(mentorId);
        if (mentor is null) throw new MentorNotFoundException();
        else
        {
            await _fileservice.DeleteAvatarAsync(mentor.ImagePath);
            var result = await _repository.DeleteAsync(mentorId);
            return result > 0;
        }
    }

    public async Task<IList<Mentor>> GetAllAsync(PaginationParams @params)
    {
        var mentors = await _repository.GetAllAsync(@params);
        return mentors;
    }


    public async Task<bool> UpdateAsync(long mentorId, MentorUpdateDto dto)
    {
        var mentor = await _repository.GetByIdAsync(mentorId);
        if (mentor is null) throw new MentorNotFoundException();
        

        mentor.FirstName = dto.FirstName;
        mentor.LastName = dto.LastName;
        mentor.Email = dto.Email;
        mentor.Description = dto.Description;
        mentor.CreatedAt = mentor.UpdatedAt = TimeHelper.GetDateTime();
        if(dto.Image is not null)
        {
            await _fileservice.DeleteAvatarAsync(mentor.ImagePath);
            mentor.ImagePath = await _fileservice.UploadAvatarAsync(dto.Image);
        }
        var dbResult = await _repository.UpdateAsync(mentorId,mentor);
        return dbResult > 0;
    }
    
    public Task<long> CountAllAsync()
    {
        throw new NotImplementedException();
    }


}
