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
           
            public class BookController : ControllerBase
            {
                        private readonly IBookRepository _book;
                        private readonly ILogger<BookController> _logger;

                        public BookController(ILogger<BookController> logger,IBookRepository book)
                        {
                                    _book=book;
                                    _logger = logger;
                        }
                        [HttpGet]
                        [Route("/books/{page}/{limit}")]
                        [Authorize(Roles = "user")]
                        public async Task<ResponseView> Books(int page,int limit)
                        {
                            return await _book.Books(page,limit);
                        }
                        [HttpGet]
                        [Route("/books/{search}/{page}/{limit}")]
                        [Authorize(Roles = "user")]
                        public async Task<ResponseView> Books(string search,int page,int limit)
                        {
                            return await _book.SearchBooks(search,page,limit);
                        }
                        [HttpPost]
                        [Route("/addBook")]
                        [Authorize(Roles = "user")]
                        public async Task<Response> AddBook([FromBody] Books obj)
                        {
                           return  await _book.AddBook(obj);
                        }
                        [HttpPut]
                         [Route("/updateBook")]
                        [Authorize(Roles = "user")]
                        public async Task<Response> UpdateBook([FromBody] Books obj)
                        {
                          return await _book.update(obj);
                        }
                        [HttpDelete]
                         [Route("/deleteBook/{id}")]
                        [Authorize(Roles = "user")]
                        public async Task<Response> DeleteBook(string id)
                        {
                          return await _book.delete(id);
                        }

            }
}