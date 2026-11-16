namespace MVCIntroductionApp.Services
{
  // her bir çağırmada (Dependecy Injection ile) yep yeni bir instance
  public class TransientService // Sping Boot Prototype
  {
    public readonly Guid guid;

    public TransientService()
    {
      guid = Guid.NewGuid();
    }

  }

  // Uygulamanın istek attığı servisler boyunca istek bitene kadar aynı guid
  public class ScopedService // request
  {
    public readonly Guid guid;

    public ScopedService()
    {
      guid = Guid.NewGuid();
    }
  }

  // Singleton Uygulama genelelinde uygulama çalıştığı süre boyunca tek instance aynı guid
  public class SingletonService
  {
    public readonly Guid guid;

    public SingletonService()
    {
      guid = Guid.NewGuid();
    }
  }
}
