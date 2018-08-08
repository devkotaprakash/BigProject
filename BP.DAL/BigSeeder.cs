using BigProject.BP.DAL.Entites;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BP.DAL
{
    public class BigSeeder
    {
        private readonly BigContext ctx;
        private readonly IHostingEnvironment hosting;

        public BigSeeder(BigContext ctx, IHostingEnvironment hosting )
        {
            this.ctx = ctx;
            this.hosting = hosting;
        }
        public void Seed()
        {
            ctx.Database.EnsureCreated();
            if (!ctx.Products.Any())
            {
                //need to create the sample data
                var filepath = Path.Combine(hosting.ContentRootPath+"\\art.json");
                var json = File.ReadAllText(filepath);
                var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);
                ctx.Products.AddRange(products);
                var order = new Order()
                {
                    OrderDate = DateTime.Now,
                    OrderNumber = "12345",
                    Items = new List<OrderItem>()
                    {
                        new OrderItem()
                        {
                            Product=products.First(),
                            Quantity=5,
                            UnitPrice=products.First().Price
                        }
                    }
                };
                ctx.Orders.Add(order);
                ctx.SaveChanges();

            }
        }
    }
}
