using Microsoft.AspNetCore.Mvc;
using MVCIntroductionApp.Models;

namespace MVCIntroductionApp.Controllers
{
  // Controller isimlendirmesi MVC de tekildir. Api de çoğul isimler kullanılır
  // MVC Route /Product/Index -> API Routes -> api/v1/products
  public class ProductController : Controller
  {
    [HttpGet]
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


    [HttpGet]
    public IActionResult Create()
    {
      return View();
    }

    // Formdan ne göndereceğim bilgisi ProductDto dto
    // /Product/Create

    [HttpPost]
    public IActionResult Create(ProductDto dto)
    {

      // Eğer formdan bir veri gönderiyorsa -> Verinin doğruluğunu sunu taraflı kontrol etmemiz sağlar.
      if (ModelState.IsValid)
      {
        Console.Write("Veri tabanına gönder.");
        ViewBag.Message = "Kayıt Başarılı";
        return View();
      }

      ViewBag.Message = "Form bilgileri yanlış";

      return View();
    }


  }
}
