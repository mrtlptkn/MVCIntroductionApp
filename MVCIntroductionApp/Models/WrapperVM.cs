using System.ComponentModel.DataAnnotations;

namespace MVCIntroductionApp.Models
{

  // MVC için VMler içinde kullanılacak olan nesnelere DTo deriz.
  // API için Request ve Response döndürlecek nesleri DTO yaparız.
  // API de viewModel kavramı yok sadece DTO ve Entity var.

  public class CategoryDto
  {
    public int Id { get; set; }
    public string Name { get; set; }

  }

  public class ProductDto
  {
    public int? Id { get; set; }
    public string? Name { get; set; }
    public decimal? Price { get; set; }

  }

  public class WrapperVM
  {
    public List<ProductDto> Products { get; set; } = new();
    public List<CategoryDto> Categories { get; set; } = new();
  }
}
