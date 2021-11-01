using Core.Utilities.Results;
using Entities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<CustomerViewModel>> GetAllCustomers();
        IDataResult<CustomerViewModel> GetCustomerById(int id);
    }
}
