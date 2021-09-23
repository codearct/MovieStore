using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    [SecuredOperation("admin")]
    public class CustomerManager : ICustomerService
    {
        private readonly IUserDal _userDal;
        IOrderService _ordersService;
        private readonly IMapper _mapper;

        public CustomerManager(IUserDal userDal, IMapper mapper, IOrderService ordersService)
        {
            _userDal = userDal;
            _mapper = mapper;
            _ordersService = ordersService;
        }

        public IDataResult<List<CustomerViewModel>> GetAllCustomers()
        {
            var customers = _userDal.GetAllUsersByClaim(2);

            if (customers.Count == 0)
            {
                return new ErrorDataResult<List<CustomerViewModel>>(Messages.NotExistCustomer);
            }

            List<CustomerViewModel> customerVMs = new List<CustomerViewModel>();

            foreach (var customer in customers)
            {                
                var orders = _ordersService.GetAllOrdersByCustomerId(customer.Id).Data;
                var customerVM = _mapper.Map<User,CustomerViewModel>(customer);
                _mapper.Map<List<Order>,CustomerViewModel>(orders, customerVM);
                customerVMs.Add(customerVM);
            }
                   
            return new SuccessDataResult<List<CustomerViewModel>>(customerVMs);
        }

        public IDataResult<CustomerViewModel> GetCustomerById(int id)
        {
            var customer = _userDal.GetUserById(id);

            if (customer is null)
            {
                return new ErrorDataResult<CustomerViewModel>(Messages.NotExistCustomer);
            }

            var orders = _ordersService.GetAllOrdersByCustomerId(id).Data;

            var customerVM = _mapper.Map<User, CustomerViewModel>(customer);
            _mapper.Map<List<Order>, CustomerViewModel>(orders, customerVM);

            return new SuccessDataResult<CustomerViewModel>(customerVM);
        }
    }
}
