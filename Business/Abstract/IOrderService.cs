﻿using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract;

public interface IOrderService
{
    IDataResult<List<Order>> GetAll();

    IQueryable<Order> GetOrdersWithDetail();

    Order? FindByConditionWithAsNoTracking(int orderId, bool trackChanges);

    void Complete(int  orderId);

    void SaveOrder(Order order);

    int NumberOfInProcess();
}
