﻿using MyBiz.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBiz.Core.ViewModels
{
  public class ProductListViewModel
  {
    public IEnumerable<Product> Products { get; set; }
    public IEnumerable<ProductCategory> ProductCategories { get; set; }
  }
}
