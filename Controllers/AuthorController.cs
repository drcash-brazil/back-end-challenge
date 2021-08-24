using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd.Interface;
using BackEnd.Models;
using BackEnd.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace BackEnd.Controllers
{
            [ApiController]
           
            public class AuthorController : ControllerBase
            {
                        private readonly IAuthorRepository _author;
                        private readonly ILogger<AuthorController> _logger;
                        public AuthorController(ILogger<AuthorController> logger,IAuthorRepository author)
                        {
                                    _logger = logger;
                                    _author=author;
                        }
                        [HttpGet]
                        [Route("/authors/{page}/{limit}")]
                        [Authorize(Roles = "user")]
                        public async Task<ResponseView> Authors(int page,int limit)
                        {
                            return await _author.Authors(page,limit);
                        }
                        [HttpGet]
                        [Route("/authors/{search}/{page}/{limit}")]
                        [Authorize(Roles = "user")]
                        public async Task<ResponseView> Authors(string search,int page,int limit)
                        {
                            return await _author.SearchAuthors(search,page,limit);
                        }
                        [HttpPost]
                        [Route("/addAuthor")]
                        [Authorize(Roles = "user")]
                        public async Task<Response> AddAuthor([FromBody] Authors models)
                        {
                           return await _author.add(models);
                        }
                        [HttpPut]
                        [Route("/updateAuthor")]
                        [Authorize(Roles = "user")]
                        public async Task<Response> UpdateAuthor([FromBody] Authors obj)
                        {
                           return await _author.update(obj);
                        }
                        [HttpDelete]
                        [Route("/deleteAuthor/{id}")]
                        [Authorize(Roles = "user")]
                        public async Task<Response> DeleteAuthor(string id)
                        {
                          return await _author.delete(id);
                        }
            }
}