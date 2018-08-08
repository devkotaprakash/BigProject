using BigProject.BP.DAL.Entites;
using BP.DAL.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BP.WebApplication.Controllers
{
    [Route("api/[Controller]")]
    public class ProductController : Controller
    {
        private readonly IRepository repository;
        private readonly ILogger<ProductController> logger;

        public ProductController(IRepository repository, ILogger<ProductController> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok( repository.GetAllProducts());

            }
            catch (Exception ex)
            {
                logger.LogError($"Failed to get products:{ex}");
                return BadRequest("Failed to get products");
              
            }

        }
    }
}
