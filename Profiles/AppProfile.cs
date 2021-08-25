using AutoMapper;
using back_end_challenge.Dtos;
using back_end_challenge.Models;

namespace back_end_challenge.Profiles
{
  public class AppProfile : Profile
  {
    public AppProfile()
    {
      CreateMap<Books, BooksReadDto>().ReverseMap();
      CreateMap<Books, BooksDto>().ReverseMap();

      CreateMap<Category, CategoryDTO>().ReverseMap();
      CreateMap<Category, CategoryReadDto>().ReverseMap();

      CreateMap<Authors, AuthorDto>().ReverseMap();
      CreateMap<Authors, AuthorReadDto>().ReverseMap();
    }
  }
}