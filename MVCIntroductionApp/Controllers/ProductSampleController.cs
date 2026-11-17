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
    [HttpGet]
    public IActionResult ProductListPartialView(string? search)
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

      // Html Döndürür. 
      return PartialView("PartialViews/ProductListPartialView", products);
    }
  }
}
