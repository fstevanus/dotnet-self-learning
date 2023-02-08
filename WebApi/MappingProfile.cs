using AutoMapper;
using Learning.Entities.Dtos;
using Learning.Entities.Models;

namespace Learning.WebApi;

public class MappingProfile : Profile
{
  public MappingProfile()
  {
    CreateMap<Blog, BlogResponseDto>();
    CreateMap<BlogRequestDto, Blog>();
    CreateMap<BlogRequestDto, Blog>().ReverseMap();
  }
}