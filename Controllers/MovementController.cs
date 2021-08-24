using System.Threading.Tasks;
using BackEnd.Interface;
using BackEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BackEnd.Controllers
{
    public class MovementController: ControllerBase
            {
                        private readonly IMovementRepository _movement;
                        private readonly ILogger<MovementController> _logger;

                        public MovementController(ILogger<MovementController> logger,IMovementRepository movement)
                        {
                          _movement=movement;
                           _logger = logger;
                        }
                        [HttpGet]
                        [Route("/sales/{page}/{limit}")]
                        [Authorize(Roles = "user")]
                        public async Task<ResponseView> Movements(int page,int limit)
                        {
                            return await _movement.get(page,limit);
                        }
                        [HttpGet]
                        [Route("/searchSales/{search}/{page}/{limit}")]
                        [Authorize(Roles = "user")]
                        public async Task<ResponseView> Movements(string search,int page,int limit)
                        {
                            return await _movement.search(search,page,limit);
                        }
                        [HttpPost]
                        [Route("/addSales")]
                        [Authorize(Roles = "user")]
                        public async Task<Response> AddMovement([FromBody] Movement obj)
                        {
                           return await _movement.add(obj);
                        }

                        [HttpDelete]
                        [Route("/deleteSale/{id}")]
                        [Authorize(Roles = "user")]
                        public async Task<Response> DeleteMovement(string id)
                        {
                            return await _movement.delete(id);
                        }

            }

}