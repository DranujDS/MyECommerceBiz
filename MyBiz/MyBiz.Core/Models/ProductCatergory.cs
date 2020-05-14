using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBiz.Core.Models
{
  public class ProductCatergory
  {
    public string Id { get; set; }
    public string Category { get; set; }

    public ProductCatergory()
    {
      this.Id = Guid.NewGuid().ToString();
    }
  }
}
