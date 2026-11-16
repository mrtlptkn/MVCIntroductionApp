using Microsoft.AspNetCore.Mvc;
using MVCIntroductionApp.Models;

namespace MVCIntroductionApp.Controllers
{
  // Controller isimlendirmesi MVC de tekildir. Api de çoğul isimler kullanılır
  // MVC Route /Product/Index -> API Routes -> api/v1/products
  public class ProductController : Controller
  {
    public IActionResult Index()
    {

      WrapperVM vm = new WrapperVM();
      vm.Products = new List<ProductDto> { 
        new ProductDto() { Id = 1, Name = "Ürün1", Price = 15.55M },
        new ProductDto() { Id = 2, Name = "Ürün2", Price = 115.55M },

      };
      vm.Categories = new List<CategoryDto>
      {
        new CategoryDto() { Id = 1, Name = "Kategori 1" },
        new CategoryDto() {Id = 2, Name = "Kategori 2"}
      };

      return View(vm);
    }
  }
}
