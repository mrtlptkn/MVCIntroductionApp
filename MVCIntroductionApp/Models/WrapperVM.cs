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

    [Required(ErrorMessage ="Ürün ismi boş geçilemez")]
    [StringLength(50, ErrorMessage = "50 karakteri geçemez")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Fiyat boş geçilemez")]
    [Range(0,1000, ErrorMessage ="Fiyat 0 dan küçük 1000 den büyük olamaz")]
    public decimal? Price { get; set; }

    [Required(ErrorMessage ="Kategori Seçimleri zorunludur")]
    public int? CategoryId { get; set; }

  }

  public class WrapperVM
  {
    public List<ProductDto> Products { get; set; } = new();
    public List<CategoryDto> Categories { get; set; } = new();
  }
}
