﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBiz.Core.Models;
using MyBiz.Core.ViewModels;
using MyBiz.DataAccess.InMemory;

namespace MyBiz.WebUI.Controllers
{
  public class ProductManagerController : Controller
  {
    InMemoryRepository<Product> context;
    InMemoryRepository<ProductCatergory> productCategories;
      
    public ProductManagerController()
    {
      context = new InMemoryRepository<Product>();
      productCategories = new InMemoryRepository<ProductCatergory>();
    }
    // GET: ProductManager
    public ActionResult Index()
    {
      List<Product> products = context.Collection().ToList();
      return View( products );
    }

    public ActionResult Create()
    {
      ProductManagerViewModel productManagerViewModel = new ProductManagerViewModel();
      productManagerViewModel.Product = new Product();
      productManagerViewModel.ProductCategories = productCategories.Collection();

      return View( productManagerViewModel );
    }

    [HttpPost]
    public ActionResult Create(Product product)
    {
      if (!ModelState.IsValid)
      {
        return View(product);
      }
      else
      {
        context.Insert( product );
        context.Commit();

      return RedirectToAction( "Index" );
      }
    }

    public ActionResult Edit(string Id)
    {
      Product product = context.Find( Id );
      if (product == null)
      {
        return HttpNotFound();
      }
      else
      {
        ProductManagerViewModel productManagerViewModel = new ProductManagerViewModel();
        productManagerViewModel.Product = product;
        productManagerViewModel.ProductCategories = productCategories.Collection();
        return View( productManagerViewModel );
      }
    }

    [HttpPost]
    public ActionResult Edit(Product product, string Id)
    {
      Product productToEdit = context.Find( Id );
      if(productToEdit == null)
      {
        return HttpNotFound();
      }
      else
      {
        if (!ModelState.IsValid)
        {
          return View( productToEdit );
        }
        else
        {
          productToEdit.Category = product.Category;
          productToEdit.Description = product.Description;
          productToEdit.Image = product.Image;
          productToEdit.Name = product.Name;
          productToEdit.Price = product.Price;

          context.Commit();

          return RedirectToAction( "Index" );
        }
      }
    }

    public ActionResult Delete( string Id )
    {
      Product productToDelete = context.Find( Id );
      if( productToDelete == null )
      {
        return HttpNotFound();
      } else
      {
        return View( productToDelete );
      }
    }

    [HttpPost]
    [ActionName("Delete")]
    public ActionResult ConfirmDelete( string Id )
    {
      Product productToDelete = context.Find( Id );
      if( productToDelete == null )
      {
        return HttpNotFound();
      } else
      {
        context.Delete( Id );
        context.Commit();
        return RedirectToAction( "Index" );
      }
    }
  }
}