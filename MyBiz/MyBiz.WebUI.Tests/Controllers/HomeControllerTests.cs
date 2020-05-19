using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyBiz.Core.Contracts;
using MyBiz.Core.Models;
using MyBiz.Core.ViewModels;
using MyBiz.WebUI.Controllers;

namespace MyBiz.WebUI.Tests.Controllers
{
  [TestClass]
  public class HomeControllerTests
  {
    [TestMethod]
    public void IndexPageDoesReturnProducts()
    {
      IRepository<Product> productContext = new Mocks.MockContext<Product>();
      IRepository<ProductCategory> productCategoryContext = new Mocks.MockContext<ProductCategory>();

      productContext.Insert( new Product() );

      HomeController controller = new HomeController( productContext, productCategoryContext );

      var result = controller.Index() as ViewResult;
      var viewModel = (ProductListViewModel) result.ViewData.Model;

      Assert.AreEqual( 1, viewModel.Products.Count() );
    }
  }
}
