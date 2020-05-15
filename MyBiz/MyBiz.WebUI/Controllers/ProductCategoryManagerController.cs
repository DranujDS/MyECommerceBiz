using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBiz.Core.Contracts;
using MyBiz.Core.Models;
using MyBiz.DataAccess.InMemory;

namespace MyBiz.WebUI.Controllers
{
  public class ProductCategoryManagerController : Controller
  {
    IRepository<ProductCatergory> context;

    public ProductCategoryManagerController( IRepository<ProductCatergory> context )
    {
      this.context = context;
    }
    // GET: ProductCategoryManager
    public ActionResult Index()
    {
      List<ProductCatergory> productCategories = context.Collection().ToList();
      return View( productCategories );
    }

    public ActionResult Create()
    {
      ProductCatergory productCategory = new ProductCatergory();

      return View( productCategory );
    }

    [HttpPost]
    public ActionResult Create( ProductCatergory productCatergory )
    {
      if( !ModelState.IsValid )
      {
        return View( productCatergory );
      } 
      else
      {
        context.Insert( productCatergory );
        context.Commit();

        return RedirectToAction( "Index" );
      }
    }

    public ActionResult Edit( string Id )
    {
      ProductCatergory productCatergory = context.Find( Id );
      if( productCatergory == null )
      {
        return HttpNotFound();
      } else
      {
        return View( productCatergory );
      }
    }

    [HttpPost]
    public ActionResult Edit( ProductCatergory productCatergory, string Id )
    {
      ProductCatergory productCatergoryToEdit = context.Find( Id );
      if( productCatergoryToEdit == null )
      {
        return HttpNotFound();
      } else
      {
        if( !ModelState.IsValid )
        {
          return View( productCatergoryToEdit );
        } 
        else
        {
          productCatergoryToEdit.Category = productCatergory.Category;

          context.Commit();

          return RedirectToAction( "Index" );
        }
      }
    }

    public ActionResult Delete( string Id )
    {
      ProductCatergory productCatergoryToDelete = context.Find( Id );
      if( productCatergoryToDelete == null )
      {
        return HttpNotFound();
      } else
      {
        return View( productCatergoryToDelete );
      }
    }

    [HttpPost]
    [ActionName( "Delete" )]
    public ActionResult ConfirmDelete( string Id )
    {
      ProductCatergory productCatergoryToDelete = context.Find( Id );
      if( productCatergoryToDelete == null )
      {
        return HttpNotFound();
      } 
      else
      {
        context.Delete( Id );
        context.Commit();
        return RedirectToAction( "Index" );
      }
    }
  }
}