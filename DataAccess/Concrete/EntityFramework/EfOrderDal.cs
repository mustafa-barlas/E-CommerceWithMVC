using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework;

public class EfOrderDal : EfEntityRepositoryBase<Order, AlalimContext>, IOrderDal
{


    public IQueryable<Order> GetOrders(int? userId = null)
    {
        IList<Order> orders = new List<Order>();

        using (var _context = new AlalimContext())
        {
            orders = _context.Orders
                .Include(x => x.User)
                .ThenInclude(x => x.Role)
                .Include(x => x.Address)
                .ThenInclude(x => x.City)
                .Include(x => x.ProductOrders)
                .ThenInclude(x => x.Product)
                .ThenInclude(x => x.Category)
                .Include(x => x.ProductOrders)
                .ThenInclude(x => x.Product)
                .ThenInclude(x => x.Color)
                .OrderBy(x => x.Shipped)
                .ThenByDescending(x => x.OrderId).ToList();
        }


        return orders.Where(x => x.UserId.Equals(userId)).AsQueryable();
    }

    public IQueryable<Order> GetOrders()
    {
        IList<Order> orders = new List<Order>();

        using (var _context = new AlalimContext())
        {
            orders = _context.Orders
                .Include(x => x.User)
                .ThenInclude(x => x.Role)
                .Include(x => x.Address)
                .ThenInclude(x => x.City)
                .Include(x => x.ProductOrders)
                .ThenInclude(x => x.Product)
                .ThenInclude(x => x.Category)
                .Include(x => x.ProductOrders)
                .ThenInclude(x => x.Product)
                .ThenInclude(x => x.Color)
                .OrderBy(x => x.Shipped)
                .ThenByDescending(x => x.OrderId).ToList();
        }


        return orders.AsQueryable();
    }

    public void Complete(int orderId)
    {

        using (var _context = new AlalimContext())
        {
            var order = _context.Orders.First(x => x.OrderId == orderId);
            if (order is null)
            {
                throw new Exception("Order Could Not Found");
            }

            order.Shipped = true;
            _context.SaveChanges();
        }
    }

    public void Cancel(int orderId)
    {
        using (var _context = new AlalimContext())
        {
            var order = _context.Orders.First(x => x.OrderId == orderId);
            if (order is null)
            {
                throw new Exception("Order Could Not Found");
            }

            order.Cancel = false;
            _context.SaveChanges();
        }
    }

    public void SaveOrder(Order order)
    {
        using (var _context = new AlalimContext())
        {
            _context.AttachRange(order.ProductOrders.Select(x => x.Product));

            if (order.OrderId == 0)
            {

                _context.Orders.Add(order);
            }
            _context.SaveChanges();
        }
    }

    public int NumberOfInProcess
    {
        get
        {
            using (var _context = new AlalimContext())
            {
                return _context.Orders.Count(x => x.Shipped.Equals(false));
            }
        }
    }
}