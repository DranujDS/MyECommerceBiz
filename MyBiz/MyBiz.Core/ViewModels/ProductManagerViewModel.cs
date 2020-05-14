﻿using MyBiz.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBiz.Core.ViewModels
{
  public class ProductManagerViewModel
  {
    public Product Product { get; set; }
    public IEnumerable<ProductCatergory> ProductCategories { get; set; }
  }
}