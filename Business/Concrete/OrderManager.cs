using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class OrderManager : IOrderService
{
    private readonly IOrderDal _orderDal;

    public OrderManager(IOrderDal orderDal)
    {
        _orderDal = orderDal;
    }


    public IDataResult<List<Order>> GetAll()
    {
        return new SuccessDataResult<List<Order>>(_orderDal.GetAll());
    }

    public IQueryable<Order> GetOrdersWithDetail(int? userId = null)
    {
        return _orderDal.GetOrders(userId);
    }

    public IQueryable<Order> GetOrdersWithDetail()
    {
        return _orderDal.GetOrders();
    }

    public Order? FindByConditionWithAsNoTracking(int orderId, bool trackChanges)
    {
        return _orderDal.FindByConditionAndAsNoTracking(x => x.OrderId.Equals(orderId), trackChanges);
    }



    public void Complete(int orderId)
    {
        _orderDal.Complete(orderId);


    }

    public void Cancel(int orderId)
    {
        _orderDal.Cancel(orderId);
    }

    public void SaveOrder(Order order)
    {
        _orderDal.SaveOrder(order);
    }

    public int NumberOfInProcess()
    {
        return _orderDal.NumberOfInProcess;
    }


}

