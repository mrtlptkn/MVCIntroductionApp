using Microsoft.AspNetCore.Mvc;
using MVCIntroductionApp.Models;

namespace MVCIntroductionApp.ViewComponents
{
    // ASP.NET MVC 5'teki [ChildActionOnly] + Html.RenderAction yapısının ASP.NET Core karşılığı.
    // Bu sınıf HTTP ile doğrudan çağrılamaz; yalnızca view içinde Component.InvokeAsync("Menu") ile render edilir.
    // Sınıf adındaki "ViewComponent" eki çağrıda kullanılmaz: "Menu".
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Menü verisi burada üretilir (ileride servis/veritabanından da gelebilir).
            var items = new List<MenuItemVM>
            {
                new("Home", "Home", "Index"),
                new("Privacy", "Home", "Privacy"),
                new("Ürünler", "Product", "Index"),
                new("DI", "DI", "Index"),
                new("Options", "OptionsDemo", "Index")
            };

            // Views/Shared/Components/Menu/MenuPartialView.cshtml dosyasını partial view olarak döndürür.
            return View("MenuPartialView", items);
        }
    }
}
