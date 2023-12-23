using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.Dtos.ReportDto;

namespace DataAccess.Concrete.EntityFramework;

public class EfProductOrderDal : EfEntityRepositoryBase<ProductOrder, AlalimContext>, IProductOrderDal
{

    public IQueryable<ReportDto> GetProductOrderForReport()
    {
        var context = new AlalimContext();

        var query = from productOrder in context.ProductOrders
                    join order in context.Orders on productOrder.OrderID equals order.OrderId
                    join product in context.Products on productOrder.ProductID equals product.ProductId
                    join category in context.Categories on product.CategoryId equals category.Id
                    join color in context.Colors on product.ColorId equals color.Id
                    join user in context.Users on order.UserId equals user.Id
                    join role in context.Roles on user.RoleId equals role.Id
                    join address in context.Addresses on user.Id equals address.UserId
                    join city in context.Cities on address.CityId equals city.CityId


                    select new ReportDto()
                    {
                        ShowCase = product.ShowCase ? "Trend" : "Not Trend",
                        ProductName = product.ProductName,
                        CategoryName = category.Name,
                        CityName = city.Name,
                        ColorName = color.Name,
                        ImageUrl = product.ImageUrl,
                        OrderedAtDate = order.OrderedAt,
                        Price = product.Price,
                        RoleName = role.Name,
                        Shipped = order.Shipped.Value ? "Shipped" : "In Progress",
                        UserName = $"{user.FirstName} {user.LastName}",
                        UserId = user.Id,
                        RoleId = role.Id,

                    };

        query = query.OrderByDescending(x => x.ProductName);

        return query;
    }

}