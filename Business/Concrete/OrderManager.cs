using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.ViewModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OrderManager:IOrderService
    {
        IOrderDal _orderDal;
        IMovieService _movieService;
        IHttpContextAccessor _httpContextAccessor;
        IMapper _mapper;

        public OrderManager(IOrderDal orderDal, IMovieService movieService, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _orderDal = orderDal;
            _movieService = movieService;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }

        [SecuredOperation("customer")]
        public IResult BuyMovie(int id)
        {
            var movie = _movieService.Get(id).Data;

            if (movie is null || movie.IsActive==false)
            {
                return new ErrorDataResult<Movie>(Messages.NotExistMovie);
            }

            int customerId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

            Order order = new Order
            {
                UserId = customerId,
                MovieId = movie.Id,
                PurchaseDate = DateTime.Now,
                MoviePrice = movie.Price
            };
            _orderDal.Add(order);

            return new SuccessResult(Messages.AddedOrder);

        }

        [SecuredOperation("admin")]
        public IDataResult<List<OrderViewModel>> GetAllOrders()
        {
            var orders = _orderDal.GetAllOrders();
            if (orders.Count==0)
            {
                return new ErrorDataResult<List<OrderViewModel>>(Messages.NotExistOrder);
            }

            List<OrderViewModel> orderVMs = _mapper.Map<List<OrderViewModel>>(orders);

            return new SuccessDataResult<List<OrderViewModel>>(orderVMs);
        }

        [SecuredOperation("customer")]
        public IDataResult<List<OrderByCustomerViewModel>> GetAllOrdersByCustomer()
        {
            int customerId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var orders = _orderDal.GetAllOrdersByCustomer(customerId);

            if (orders.Count==0)
            {
                return new ErrorDataResult<List<OrderByCustomerViewModel>>(Messages.NotExistOrder);
            }

            List<OrderByCustomerViewModel> orderVMs = _mapper.Map<List<OrderByCustomerViewModel>>(orders);

            return new SuccessDataResult<List<OrderByCustomerViewModel>>(orderVMs);
        }
        public IDataResult<List<Order>> GetAllOrdersByCustomerId(int customerId)
        {

            var orders = _orderDal.GetAllOrdersByCustomer(customerId);

            if (orders.Count == 0)
            {
                return new ErrorDataResult<List<Order>>(Messages.NotExistOrder);
            }

            return new SuccessDataResult<List<Order>>(orders);
        }
    }
}
