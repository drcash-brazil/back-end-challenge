using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
                        [Route("/sales/{search}/{page}/{limit}")]
                        [Authorize(Roles = "user")]
                        public async Task<ResponseView> Sales(string search,int page,int limit)
                        {
                            return await _movement.Sales(search,page,limit);
                        }

                        [HttpGet]
                        [Route("/deposits/{search}/{page}/{limit}")]
                        [Authorize(Roles = "user")]
                        public async Task<ResponseView> Deposits(string search, int page,int limit)
                        {
                            return await _movement.Deposits(search,page,limit);
                        }
                        [HttpGet]
                        [Route("/movements/{search}/{page}/{limit}")]
                        [Authorize(Roles = "user")]
                        public async Task<ResponseView> Movements(string search,int page,int limit)
                        {
                            return await _movement.Movements(search,page,limit);
                        }
                        [HttpPost]
                        [Route("/addSale")]
                        [Authorize(Roles = "user")]
                        public async Task<Response> AddMovement([FromBody] Movement obj)
                        {
                           return await _movement.AddSale(obj);
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