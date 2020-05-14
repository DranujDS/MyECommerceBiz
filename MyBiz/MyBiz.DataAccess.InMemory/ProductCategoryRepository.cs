using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using MyBiz.Core.Models;

namespace MyBiz.DataAccess.InMemory
{
  public class ProductCategoryRepository
  {
    public const string sCacheTag = "categories";

    ObjectCache cache = MemoryCache.Default;
    List<ProductCatergory> categories;

    public ProductCategoryRepository()
    {
      categories = cache[sCacheTag] as List<ProductCatergory>;

      if( categories == null )
      {
        categories = new List<ProductCatergory>();
      }
    }

    public void Commit()
    {
      cache[sCacheTag] = categories;
    }

    public void Insert( ProductCatergory category )
    {
      categories.Add( category );
    }

    public void Update( ProductCatergory category )
    {
      ProductCatergory categoryToUpdate = categories.Find( c => c.Id == category.Id );

      if( categoryToUpdate != null )
      {
        categoryToUpdate = category;
      } else
      {
        throw new Exception( "Category not found!" );
      }
    }

    public ProductCatergory Find( string Id )
    {
      ProductCatergory category = categories.Find( c => c.Id == Id );

      if( category != null )
      {
        return category;
      } else
      {
        throw new Exception( "Category not found!" );
      }
    }

    public IQueryable<ProductCatergory> Collection()
    {
      return categories.AsQueryable();
    }

    public void Delete( string Id )
    {
      ProductCatergory categoryToDelete = categories.Find( c => c.Id == Id );

      if( categoryToDelete != null )
      {
        categories.Remove( categoryToDelete);
      } else
      {
        throw new Exception( "Category not found!" );
      }
    }
  }
}
