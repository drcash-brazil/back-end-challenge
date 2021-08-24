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
            [Route("[controller]")]
            public class AuthorController : ControllerBase
            {
                        private readonly IAuthorRepository _author;
                        private readonly ILogger<AuthorController> _logger;
                        public AuthorController(ILogger<AuthorController> logger,IAuthorRepository author)
                        {
                                    _logger = logger;
                                    _author=author;
                        }
                        [HttpGet("{page}/{limit}")]
                        [Authorize(Roles = "user")]
                        public async Task<ResponseView> get(int page,int limit)
                        {
                            return await _author.Authors(page,limit);
                        }
                        [HttpGet("{search}/{page}/{limit}")]
                        [Authorize(Roles = "user")]
                        public async Task<ResponseView> get(string search,int page,int limit)
                        {
                            return await _author.SearchAuthors(search,page,limit);
                        }
                        [HttpPost]
                        [Authorize(Roles = "user")]
                        public async Task<Response> add([FromBody] Authors models)
                        {
                           return await _author.add(models);
                        }
                        [HttpPut]
                        [Authorize(Roles = "user")]
                        public async Task<Response> update([FromBody] Authors obj)
                        {
                           return await _author.update(obj);
                        }
                        [HttpDelete("{id}")]
                        [Authorize(Roles = "user")]
                        public async Task<Response> delete(string id)
                        {
                          return await _author.delete(id);
                        }
            }
}