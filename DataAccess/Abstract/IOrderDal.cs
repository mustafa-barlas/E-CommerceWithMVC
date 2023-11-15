using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract;

public interface IOrderDal : IEntityRepository<Order>
{
    IQueryable<Order> GetOrders();

    void SaveOrder(Order order);

    int NumberOfInProcess { get; }

    public void Complete(int orderId);
}