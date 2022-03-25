using System.Linq;
using AutoMapper;
using BookStoreCrudWebApi.Models.Dtos;
using BookStoreCrudWebApi.Models.Entidades;

namespace BookStoreCrudWebApi.Helpers
{
    public class BookStoreProfile : Profile
    {
        public BookStoreProfile()
        {
            CreateMap<Autor, AutorDetalhesDto>().ReverseMap();
            CreateMap<Autor, AutorDto>().ReverseMap();
            
            CreateMap<Genero, GeneroDto>().ReverseMap();
            CreateMap<Livro, LivroDetalhesDto>()
                .ForMember(x => x.Titulo, y => { y.MapFrom(o => o.Titulo); })
                .ForMember(x => x.QuantidadeCopias, y => { y.MapFrom(o => o.QuantidadeCopias); })
                .ForMember(x => x.Autores, y => { y.MapFrom(o => o.LivroAutores.Select(x=>x.Autor)); })
                .ForMember(x=>x.Genero, y=>{y.MapFrom(o=>o.GeneroLivro.Select(x=>x.Genero));});
            
            CreateMap<LivroCadastrarDto, Livro>().ReverseMap();
            CreateMap<LivroAtualizarDto, Livro>().ReverseMap();
            CreateMap<GeneroCadastrarDto, Genero>().ReverseMap();
            CreateMap<GeneroAtualizarDto, Genero>().ReverseMap();
            CreateMap<AutorCadastrarDto, Autor>().ReverseMap();
            CreateMap<LivroAutorCadastrar, Livro>().ReverseMap();
            CreateMap<AutoresLivrosCadastrarDto, AutoresLivros>().ReverseMap();
        }
    }
}