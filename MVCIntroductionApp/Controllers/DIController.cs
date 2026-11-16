using Microsoft.AspNetCore.Mvc;
using MVCIntroductionApp.Services;

namespace MVCIntroductionApp.Controllers
{
  public class DIController : Controller
  {
    private readonly TransientService _t1;
    private readonly TransientService _t2;
    private readonly SingletonService _sg1;
    private readonly SingletonService _sg2;
    private readonly ScopedService _s1;
    private readonly ScopedService _s2;

    public DIController(TransientService t1, TransientService t2, ScopedService s1, ScopedService s2, SingletonService sg1, SingletonService sg2) { 
    
      _t1 = t1;
      _t2 = t2;
      _s1 = s1;
      _s2 = s2;
      _sg1 = sg1;
      _sg2 = sg2;

    }

    public IActionResult Index()
    {

      Tuple<Guid,Guid,Guid,Guid,Guid,Guid> model =  Tuple.Create(_t1.guid, _t2.guid, _s1.guid, _s2.guid, _sg1.guid, _sg2.guid);

      // istediğimiz kadar viewBag ile sayfaya veri gönderebiliriz
      // Çok falza kullanamak bir antipattenr yatarır. O yüzden büyük nesneleri Tupple ile yada normal Wrapper Class kullanarak gönderin. 
      ViewBag.ModelSize = 6;


      return View(model);
    }
  }
}
