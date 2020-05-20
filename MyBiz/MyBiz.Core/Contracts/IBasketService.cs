using MyBiz.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MyBiz.Core.Contracts
{
  public interface IBasketService
  {
    void AddtoBasket( HttpContextBase httpContext, string productId );
    void RemovefromBasket( HttpContextBase httpContext, string itemId );
    List<BasketItemViewModel> GetBasketItems( HttpContextBase httpContext );
    BasketSummaryViewModel GetBasketSummary( HttpContextBase httpContext );
    void ClearBasket( HttpContextBase httpContext );
  }
}
