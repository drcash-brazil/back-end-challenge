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
      // CreateMap<BooksDto, Books>();
      CreateMap<Books, BooksDto>().ReverseMap();

      CreateMap<Category, CategoryReadDto>().ReverseMap();
      CreateMap<Category, CategoryDTO>().ReverseMap();

      CreateMap<Authors, AuthorDto>().ReverseMap();
      CreateMap<Authors, AuthorReadDto>().ReverseMap();
    }
  }
}