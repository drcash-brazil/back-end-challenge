using AutoMapper;
using DrCashChallenge.Api.ViewModels;
using DrCashChallenge.Business.Models;

namespace DrCashChallenge.Api.Configurations
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookViewModel>().ReverseMap();
            CreateMap<Author, AuthorViewModel>().ReverseMap();
            CreateMap<Genre, GenreViewModel>().ReverseMap();
        }
    }
}
