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
            public class GenreController : ControllerBase
            {
                        private readonly IGenreRepository _genre;
                        private readonly ILogger<GenreController> _logger;

                        public GenreController(ILogger<GenreController> logger,IGenreRepository genre)
                        {
                          _genre=genre;
                                    _logger = logger;
                        }
                        [HttpGet("{page}/{limit}")]
                        [Authorize(Roles = "user")]
                        public async Task<ResponseView> get(int page,int limit)
                        {
                            return await _genre.get(page,limit);
                        }
                        [HttpGet("{search}/{page}/{limit}")]
                        [Authorize(Roles = "user")]
                        public async Task<ResponseView> get(string search,int page,int limit)
                        {
                            return await _genre.search(search,page,limit);
                        }
                        [HttpPost]
                        [Authorize(Roles = "user")]
                        public async Task<Response> add([FromBody] Generous obj)
                        {
                           return await _genre.add(obj);
                        }
                        [HttpPut("{id}")]
                        [Authorize(Roles = "user")]
                        public async Task<Response> update(string id ,[FromBody] Generous obj)
                        {
                            return await _genre.update(obj);
                        }
                        [HttpDelete("{id}")]
                        [Authorize(Roles = "user")]
                        public async Task<Response> delete(string id)
                        {
                            return await _genre.delete(id);
                        }

            }
}