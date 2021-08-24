using AutoMapper;
using back_end_challenge.Dtos;
using back_end_challenge.Models;

namespace back_end_challenge.Profiles
{
  public class BooksProfile : Profile
  {
    public BooksProfile()
    {
      CreateMap<Books, BooksReadDto>();
    }
  }
}