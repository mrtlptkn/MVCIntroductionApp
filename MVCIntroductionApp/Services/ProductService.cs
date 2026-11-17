using MVCIntroductionApp.Models;

namespace MVCIntroductionApp.Services
{
  public class ProductService
  {

    public List<ProductDto> GetProducts()
    {
      return new List<ProductDto>
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
    }

  }
}
