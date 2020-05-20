﻿using MyBiz.Core.Models;
using MyBiz.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBiz.Core.Contracts
{
  public interface IOrderService
  {
    void CreateOrder( Order baseOrder, List<BasketItemViewModel> basketItems );
  }
}
