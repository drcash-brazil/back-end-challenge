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
           
            public class GenreController : ControllerBase
            {
                        private readonly IGenreRepository _genre;
                        private readonly ILogger<GenreController> _logger;

                        public GenreController(ILogger<GenreController> logger,IGenreRepository genre)
                        {
                          _genre=genre;
                                    _logger = logger;
                        }
                        [HttpGet]
                        [Route("/generous/{page}/{limit}")]
                        [Authorize(Roles = "user")]
                        public async Task<ResponseView> Generous(int page,int limit)
                        {
                            return await _genre.get(page,limit);
                        }
                        [HttpGet]
                         [Route("/generous/{search}/{page}/{limit}")]
                        [Authorize(Roles = "user")]
                        public async Task<ResponseView> Generous(string search,int page,int limit)
                        {
                            return await _genre.search(search,page,limit);
                        }
                        [HttpPost]
                         [Route("/addGenre")]
                        [Authorize(Roles = "user")]
                        public async Task<Response> AddGenerous([FromBody] Generous obj)
                        {
                           return await _genre.add(obj);
                        }
                        [HttpPut]
                         [Route("/updateGenre")]
                        [Authorize(Roles = "user")]
                        public async Task<Response> UpdateGenerous(string id ,[FromBody] Generous obj)
                        {
                            return await _genre.update(obj);
                        }
                        [HttpDelete]
                        [Route("/deleteGenre/{id}")]
                        [Authorize(Roles = "user")]
                        public async Task<Response> DeleteGenerous(string id)
                        {
                            return await _genre.delete(id);
                        }

            }

}