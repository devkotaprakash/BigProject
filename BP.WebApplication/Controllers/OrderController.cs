using AutoMapper;
using BigProject.BP.DAL.Entites;

using BP.DAL.Repository;
using BP.WebApplication.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BP.WebApplication.Controllers
{
    [Route("api/[Controller]")]
    public class OrderController:Controller
    {
        private readonly IRepository repository;
        private readonly ILogger<OrderController> logger;
        private readonly IMapper mapper;

        public OrderController(IRepository repository,ILogger<OrderController> logger,IMapper mapper)
        {
            this.repository = repository;
            this.logger = logger;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(mapper.Map<IEnumerable<Order>, IEnumerable<OrderViewModel>>(repository.GetAllOrders()));
            }
            catch (Exception ex)
            {

                logger.LogError($"Failed to get orders");
                return BadRequest("Failed to get orders");
            }
        }
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
          var order=repository.GetOrderById(id);
                if (order != null) return Ok(mapper.Map<Order,OrderViewModel>(order));
                else return NotFound();
            }
            catch (Exception ex)
            {
                logger.LogError($"Failed to get orders:{ex}");
                return BadRequest("Failed to get orders");
            }
        }
        [HttpPost("Add")]
        public IActionResult Post([FromBody]OrderViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newOrder = mapper.Map<OrderViewModel, Order>(model);
                    if (newOrder.OrderDate == DateTime.MinValue) newOrder.OrderDate = DateTime.Now;
                    repository.AddEntity(newOrder);
                    if (repository.SaveAll()) { }
                        return Created($"/api/order/{newOrder.Id}", mapper.Map<Order,OrderViewModel>(newOrder));
                }
                else
                {
                    return BadRequest(ModelState);
                }

            }
            catch (Exception ex)
            {

                logger.LogError($"Failed to save new order:{ex}");
                return BadRequest("Failed to save new order");
            }
            return BadRequest("Failed to save the new order");
        }
        [HttpPut("Update")]
        public IActionResult Update([FromBody]Order model)
        {
            try
            {
                repository.UpdateEntity(model);
                if (repository.SaveAll())
                    return Created($"/api/order/{model.Id}", model);


            }
            catch (Exception ex)
            {

                logger.LogError($"Failed to update order:{ex}");
                return BadRequest("Failed to update order");
            }
            return BadRequest("Failed to update the order");
        }
        [HttpDelete("Delete")]
        public IActionResult Delete([FromBody]Order model)
        {
            try
            {
                repository.DeleteEntity(model);
                if (repository.SaveAll())
                    return Created($"/api/order",model);


            }
            catch (Exception ex)
            {

                logger.LogError($"Failed to delete order:{ex}");
                return BadRequest("Failed to delete order");
            }
            return BadRequest("Failed to delete the order");
        }

    }
}
