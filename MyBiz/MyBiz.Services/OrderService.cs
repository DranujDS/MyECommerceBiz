﻿using MyBiz.Core.Contracts;
using MyBiz.Core.Models;
using MyBiz.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBiz.Services
{
  public class OrderService : IOrderService
  {
    IRepository<Order> orderContext;
    public OrderService(IRepository<Order> OrderContext)
    {
      this.orderContext = OrderContext;
    }

    public void CreateOrder( Order baseOrder, List<BasketItemViewModel> basketItems )
    {
      foreach(var item in basketItems)
      {
        baseOrder.OrderItems.Add( new OrderItem() {
          ProductId = item.Id,
          Image = item.Image,
          Price = item.Price,
          Quantity = item.Quantity
        } );
      }

      orderContext.Insert( baseOrder );
      orderContext.Commit();
    }
  }
}
