using AutoMapper;
using back_end_challenge.Dtos;
using back_end_challenge.Models;

namespace back_end_challenge.Profiles
{
  public class AppProfile : Profile
  {
    public AppProfile()
    {
      CreateMap<Books, BooksReadDto>();
      CreateMap<BooksDto, Books>();
      CreateMap<Books, BooksDto>();
    }
  }
}