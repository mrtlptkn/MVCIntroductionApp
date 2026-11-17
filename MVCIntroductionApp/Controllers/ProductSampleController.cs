using Microsoft.AspNetCore.Mvc;
using MVCIntroductionApp.Models;
using MVCIntroductionApp.Services;

namespace MVCIntroductionApp.Controllers
{
  public class ProductSampleController : Controller
  {
    private readonly ProductService _productService;

    public ProductSampleController(ProductService productService)
    {
      _productService = productService;
    }

    // /ProductSample/Index?search=ürün
    // Arama işlemi sunucu tarafında yapılır; sonuç View'a filtrelenmiş liste olarak gönderilir.
    [HttpGet]
    public IActionResult Index(string? search)
    {
      var allProducts = _productService.GetProducts();
      var products = allProducts;

      if (!string.IsNullOrWhiteSpace(search))
      {
        var term = search.Trim();
        products = allProducts
          .Where(p => p.Name != null && p.Name.Contains(term, StringComparison.OrdinalIgnoreCase))
          .ToList();
      }

      ViewData["Title"] = "Ürünler";
      ViewData["Search"] = search ?? string.Empty;
      ViewData["TotalCount"] = allProducts.Count;

      return View(products);
    }

    // ürünlerimizi filtreledik ve filtelenmiş halini ekranda göstermek istiyoruz
    // Search işlemini JS ile başlatıp filtelenmiş görseli JS ile hesaplamak yerine bunu mvc bırakıp, hesaplanmış html JS ile ekrana basarak ekranı güncelleyebiliriz.
    public IActionResult MenuPartialView()
    {

      var items = new List<ProductDto>
      {
        new ProductDto() { Id = 1, Name = "Ürün1", Price = 15.55M },
        new ProductDto() { Id = 2, Name = "Ürün2", Price = 115.55M },
             new ProductDto() { Id = 1, Name = "Ürün4", Price = 55.55M },
        new ProductDto() { Id = 2, Name = "Ürün3", Price = 48.55M },
               new ProductDto() { Id = 1, Name = "Ürün5", Price = 38.55M },
        new ProductDto() { Id = 2, Name = "Ürün6", Price = 18.55M },
               new ProductDto() { Id = 1, Name = "Ürün7", Price = 18.55M },
        new ProductDto() { Id = 2, Name = "Ürün10", Price = 119.55M },
               new ProductDto() { Id = 1, Name = "Ürün8", Price = 15.55M },
        new ProductDto() { Id = 2, Name = "Ürün9", Price = 115.55M },
               new ProductDto() { Id = 1, Name = "Ürün11", Price = 13.55M },
        new ProductDto() { Id = 2, Name = "Ürün12", Price = 112.55M }
      };

      return PartialView("MenuPartialView", items);
    }
  }
}
