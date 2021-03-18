using AutoMapper;
using DrCash.Teste.Api.ViewModel;
using DrCash.Teste.Domain.Entities;

namespace DrCash.Teste.Api.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Livro, LivroViewModel>().ReverseMap();
            CreateMap<Autor, AutorViewModel>().ReverseMap();
            CreateMap<Genero, GeneroViewModel>().ReverseMap();
        }
    }
}
