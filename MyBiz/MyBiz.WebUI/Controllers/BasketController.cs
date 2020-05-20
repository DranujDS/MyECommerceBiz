﻿using MyBiz.Core.Contracts;
using MyBiz.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBiz.WebUI.Controllers
{
  public class BasketController : Controller
  {
    IBasketService basketService;
    IOrderService orderService;
    
    public BasketController(IBasketService basketService, IOrderService orderService)
    {
      this.basketService = basketService;
      this.orderService = orderService;
    }

    // GET: Basket
    public ActionResult Index()
    {
      var model = basketService.GetBasketItems( this.HttpContext );
      return View( model );
    }

    public ActionResult AddToBasket(string Id)
    {
      basketService.AddtoBasket( this.HttpContext, Id );

      return RedirectToAction("Index");
    }

    public ActionResult RemoveFromBasket(string Id)
    {
      basketService.RemovefromBasket( this.HttpContext, Id );

      return RedirectToAction( "Index" );
    }

    public PartialViewResult BasketSummary()
    {
      var basketSummary = basketService.GetBasketSummary( this.HttpContext );

      return PartialView( basketSummary );
    }

    public ActionResult Checkout()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Checkout(Order order)
    {
      var basketItems = basketService.GetBasketItems( this.HttpContext );
      order.OrderStatus = "Order Created";

      //process Payment

      order.OrderStatus = "Payment Processed";
      orderService.CreateOrder( order, basketItems );
      basketService.ClearBasket(this.HttpContext);

      return RedirectToAction( "Thankyou", new { OrderId = order.Id} );
    }

    public ActionResult Thankyou(string OrderId)
    {
      ViewBag.OrderId = OrderId;

      return View();
    }
  }
}