using Core.Utilities.Results;
using Entities.Concrete;
using Entities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOrderService
    {
        IResult BuyMovie(int id);
        IDataResult<List<OrderViewModel>> GetAllOrders();
        IDataResult<List<OrderByCustomerViewModel>> GetAllOrdersByCustomer();
        IDataResult<List<Order>> GetAllOrdersByCustomerId(int customerId);
    }
}
