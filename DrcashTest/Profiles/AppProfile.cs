using AutoMapper;
using DrcashTest.Models;
using DrcashTest.Models.Dtos;

namespace DrcashTest.Profiles
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

      CreateMap<Users, UserCreateDto>().ReverseMap();
      CreateMap<Users, UserReadDto>().ReverseMap();
      CreateMap<Users, UserUpdateDto>().ReverseMap();
      CreateMap<Users, LoginUserDto>().ReverseMap();

    }
  }
}