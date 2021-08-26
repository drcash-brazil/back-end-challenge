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
      CreateMap<Books, BookCreateDto>().ReverseMap();
      CreateMap<Books, BookUpdateDto>().ReverseMap();

      CreateMap<Category, CategoryReadDto>().ReverseMap();
      CreateMap<Category, CategoryCreateDto>().ReverseMap();
      CreateMap<Category, CategoryUpdateDto>().ReverseMap();

      CreateMap<Authors, AuthorReadDto>().ReverseMap();
      CreateMap<Authors, AuthorCreateDto>().ReverseMap();
      CreateMap<Authors, AuthorUpdateDto>().ReverseMap();
    }
  }
}