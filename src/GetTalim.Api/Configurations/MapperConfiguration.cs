using AutoMapper;
using GetTalim.Domain.Entities.Categoires;
using GetTalim.Domain.Entities.Mentors;
using GetTalim.Service.Dtos.Categories;
using GetTalim.Service.Dtos.Mentors;

namespace GetTalim.Api.Configurations;

public class MapperConfiguration : Profile
{
    public MapperConfiguration()
    {
        CreateMap<CategoryCreateDto, Category>().ReverseMap();
        CreateMap<CategoryUpdateDto, Category>().ReverseMap();
        CreateMap<MentorCreateDto, Mentor>().ReverseMap();
        CreateMap<MentorUpdateDto, Mentor>().ReverseMap();
    }
}
