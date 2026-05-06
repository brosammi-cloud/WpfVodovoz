using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfVodovoz.Models;

namespace WpfVodovoz.Data.Servise
{
    public class OrderService
    {
        private readonly IRepository<Order> Repo;

        public OrderService(IRepository<Order> repo)
        {
            Repo = repo;
        }

        public IList<Order> GetAllEmployees()
            => Repo.GetAll();

        public void AddOrder(Order order)
        {
            Repo.Add(order);
        }
        public void DeleteOrder(Order order)
        {
            Repo.Delete(order);
        }
        public void UpdateOrder(Order order)
        {
            Repo.Update(order);
        }
    }
}
