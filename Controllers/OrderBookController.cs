using System.Threading.Tasks;
using BackEnd.Interface;
using BackEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BackEnd.Controllers
{

                [ApiController]
           
            public class OrderBookController : ControllerBase
            {
                        private readonly IOrderBookRepository _order;
                        private readonly ILogger<OrderBookController> _logger;

                        public OrderBookController(ILogger<OrderBookController> logger,IOrderBookRepository order)
                        {
                          _order=order;
                                    _logger = logger;
                        }
                        [HttpGet]
                        [Route("/orderBooks/{page}/{limit}")]
                        [Authorize(Roles = "user")]
                        public async Task<ResponseView> OrderBooks(int page,int limit)
                        {
                            return await _order.get(page,limit);
                        }
                        [HttpGet]
                        [Route("/orderBooks/{search}/{page}/{limit}")]
                        [Authorize(Roles = "user")]
                        public async Task<ResponseView> OrderBooks(string search,int page,int limit)
                        {
                            return await _order.search(search,page,limit);
                        }
                        [HttpPost]
                        [Route("/addOrderBook")]
                        [Authorize(Roles = "user")]
                        public async Task<Response> AddOrderBook([FromBody] OrderBooks obj)
                        {
                           return await _order.AddOrderBook(obj);
                        }
                        [HttpPut]
                        [Route("/orderProcess/{id}")]
                        [Authorize(Roles = "user")]
                        public async Task<Response> OrderProcess(string id)
                        {
                            return await _order.OrderBookProcess(id);
                        }
                        [HttpDelete]
                        [Route("/canceledOrder/{id}")]
                        [Authorize(Roles = "user")]
                        public async Task<Response> CanceledOrder(string id)
                        {
                            return await _order.CanceledOrder(id);
                        }

            }

}