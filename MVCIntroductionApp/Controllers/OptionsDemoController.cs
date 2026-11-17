using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MVCIntroductionApp.Settings;

namespace MVCIntroductionApp.Controllers
{
    public class OptionsDemoController : Controller
    {
        private readonly SiteSettings _singletonSettings;
        private readonly SiteSettings _snapshotSettings;

    // IOptions<SiteSettings> options ilk açılış değeri
    // IOptionsSnapshot<SiteSettings> snapshot uygulama çalışırken config dosyalarındaki yapılan değişikliklerin güncel hali.
    public OptionsDemoController(IOptions<SiteSettings> options, IOptionsSnapshot<SiteSettings> snapshot)
        {
            // IOptions<T>: uygulama başlarken okunur ve bir kez oluşturulur (singleton).
            // appsettings.json sonradan değişse bile değer güncellenmez.
            _singletonSettings = options.Value;

            // IOptionsSnapshot<T>: her HTTP isteğinde yeniden hesaplanır.
            // Dosya değiştiğinde (ve yeniden yüklendiğinde) bir sonraki istekte yeni değeri görürsünüz.
            _snapshotSettings = snapshot.Value;
        }

        public IActionResult Index()
        {
            ViewBag.IOptionsSiteName = _singletonSettings.SiteName;
            return View(_snapshotSettings);
        }
    }
}
