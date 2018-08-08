using System.Collections.Generic;
using BigProject.BP.DAL.Entites;

namespace BP.DAL.Repository
{
    public interface IRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductByCategory(string category);
        IEnumerable<Order> GetAllOrders();
        Order GetOrderById(int id);
        void AddEntity(object model);
        bool SaveAll();
        void UpdateEntity(object model);
        void DeleteEntity(object model);
    }
}