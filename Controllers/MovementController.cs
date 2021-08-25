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
                        [Route("/sales/{page}/{limit}")]
                        [Authorize(Roles = "user")]
                        public async Task<ResponseView> Sales(int page,int limit)
                        {
                            return await _movement.Sales(page,limit);
                        }
                        [HttpGet]
                        [Route("/searchSales/{search}/{page}/{limit}")]
                        [Authorize(Roles = "user")]
                        public async Task<ResponseView> Sales(string search,int page,int limit)
                        {
                            return await _movement.SearchSales(search,page,limit);
                        }
                        [HttpGet]
                        [Route("/deposits/{page}/{limit}")]
                        [Authorize(Roles = "user")]
                        public async Task<ResponseView> Deposits(int page,int limit)
                        {
                            return await _movement.Deposits(page,limit);
                        }
                        [HttpGet]
                        [Route("/searchDeposits/{search}/{page}/{limit}")]
                        [Authorize(Roles = "user")]
                        public async Task<ResponseView> Deposits(string search,int page,int limit)
                        {
                            return await _movement.SearchDeposits(search,page,limit);
                        }
                                                [HttpGet]
                        [Route("/movements/{page}/{limit}")]
                        [Authorize(Roles = "user")]
                        public async Task<ResponseView> Movements(int page,int limit)
                        {
                            return await _movement.get(page,limit);
                        }
                        [HttpGet]
                        [Route("/searchMovements/{search}/{page}/{limit}")]
                        [Authorize(Roles = "user")]
                        public async Task<ResponseView> Movements(string search,int page,int limit)
                        {
                            return await _movement.search(search,page,limit);
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