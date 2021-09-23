using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfOrderDal : EfEntityRepositoryBase<Order, MovieStoreDbContext>, IOrderDal
    {
        public List<Order> GetAllOrders()
        {
            using (MovieStoreDbContext context=new MovieStoreDbContext())
            {
                var orders = context.Orders
                    .Include(o => o.Movie)
                        .ThenInclude(m => m.Genre)
                    .Include(o=>o.User)
                    .OrderBy(o => o.Id)
                    .ToList();

                return orders;
                        
            }
        }

        public List<Order> GetAllOrdersByCustomer(int userId)
        {
            using (MovieStoreDbContext context = new MovieStoreDbContext())
            {
                var orders = context.Orders
                    .Where(o=>o.UserId==userId)
                    .Include(o => o.Movie)
                        .ThenInclude(m=>m.Genre)
                    .Include(o => o.User)
                    .OrderBy(o => o.Id)
                    .ToList();

                return orders;

            }
        }

        public Order GetOrderById(int id)
        {
            using (MovieStoreDbContext context = new MovieStoreDbContext())
            {
                var order = context.Orders
                    .Include(o => o.Movie)
                        .ThenInclude(m => m.Genre)
                    .Include(o => o.User)
                    .SingleOrDefault(o => o.Id == id);

                return order;

            }
        }
    }
}
