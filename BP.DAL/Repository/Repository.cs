using BigProject.BP.DAL.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BP.DAL.Repository
{
   public  class Repository : IRepository
    {
        private readonly BigContext context;

        public Repository(BigContext context)
        {
            this.context = context;
        }

        public void AddEntity(object model)
        {
            context.Add(model);
        }
        public void UpdateEntity(object model)
        {
            context.Update(model);
        }
        public IEnumerable<Order> GetAllOrders()
        {
            return context.Orders
                .Include(o=>o.Items)
                .ThenInclude(i=>i.Product)
                .ToList();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return context.Products.OrderBy(x=>x.Title).ToList();
        }

        public Order GetOrderById(int id)
        {
            return context.Orders
                 .Include(o => o.Items)
                 .ThenInclude(i => i.Product).Where(o=>o.Id==id)
                 .FirstOrDefault();
        }

        public IEnumerable<Product> GetProductByCategory(string category)
        {
            return context.Products.Where(x => x.Category == category).ToList();
        }

        public bool SaveAll()
        {
            context.SaveChanges();
            return true;
        }

        public void DeleteEntity(object model)
        {
            context.Remove(model);
        }
    }
}
