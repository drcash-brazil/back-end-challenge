using AutoMapper;
using DrCash.Teste.Api.ViewModel;
using DrCash.Teste.Application.Interfaces;
using DrCash.Teste.Domain.Entities;
using DrCash.Teste.Infra.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DrCash.Teste.Api.Controllers
{

    [Route("api/livros")]
        public class LivroController : MainController
        {
            private readonly ILivroRepository _livroRepository;
            private readonly ILivroService _livroService;
            private readonly IMapper _mapper;

            public LivroController(ILivroRepository livroRepository,
                                          IMapper mapper,
                                          ILivroService livroService,
                                          INotificador notificador) : base(notificador)
            {
                _livroRepository = livroRepository;
                _mapper = mapper;
                _livroService = livroService;
            }

            [HttpGet]
            public async Task<IEnumerable<LivroViewModel>> ObterTodos()
            {
                return _mapper.Map<IEnumerable<LivroViewModel>>(await _livroRepository.ObterTodos());
            }

            [HttpGet("{id:guid}")]
            public async Task<ActionResult<LivroViewModel>> ObterPorId(Guid id)
            {
                var livro = await ObterLivro(id);

                if (livro == null) return NotFound();

                return livro;
            }

            [HttpPost]
            public async Task<ActionResult<LivroViewModel>> Adicionar(LivroViewModel livroViewModel)
            {
                if (!ModelState.IsValid) return CustomResponse(ModelState);

                await _livroService.Adicionar(_mapper.Map<Livro>(livroViewModel));

                return CustomResponse(livroViewModel);
            }

            [HttpPut("{id:guid}")]
            public async Task<ActionResult<LivroViewModel>> Atualizar(Guid id, LivroViewModel livroViewModel)
            {
                if (id != livroViewModel.Id)
                {
                    NotificarErro("O id informado não é o mesmo que foi passado na query");
                    return CustomResponse(livroViewModel);
                }

                if (!ModelState.IsValid) return CustomResponse(ModelState);

                await _livroService.Atualizar(_mapper.Map<Livro>(livroViewModel));

                return CustomResponse(livroViewModel);
            }

            [HttpDelete("{id:guid}")]
            public async Task<ActionResult<LivroViewModel>> Excluir(Guid id)
            {
                var livroViewModel = await ObterLivro(id);

                if (livroViewModel == null) return NotFound();

                await _livroService.Remover(id);

                return CustomResponse(livroViewModel);
            }

            public async Task<LivroViewModel> ObterLivro(Guid id)
            {
                return _mapper.Map<LivroViewModel>(await _livroRepository.ObterPorId(id));
            }
        }
    }
