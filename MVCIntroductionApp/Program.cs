using MVCIntroductionApp.Settings;
using MVCIntroductionApp;
using MVCIntroductionApp.Middlewares;
using MVCIntroductionApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<RequestLoggingMiddleware>();

// Uygulamada bir konfigürasyon varsa builder.Services.Configure ile IoC tanýmlarýný yaparýz.
builder.Services.Configure<SiteSettings>(builder.Configuration.GetSection(SiteSettings.SectionName));

// Servis Register iþlemi
// DI için yazmamýz þart.
builder.Services.AddTransient<TransientService>();
builder.Services.AddScoped<ScopedService>();
builder.Services.AddSingleton<SingletonService>();
builder.Services.AddScoped<ProductService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Custom Middleware Built-in Middleware altýna MapController üstüne yazmalýyýz.
// Use Middlewareler her request otomatik çalýþan ara kodlar. 
app.Use(async (context, next) =>
{
  // RequestDelegate -> Bir sonraki middleware çalýþtýrmak için kullanýlan delegate
  // HttpContext -> istek ile alakalý request, response ve user gibi bilgileri taþýyan istek nesnesi
  Console.WriteLine("Request");

  if(context.Request.Method == "GET")
  {
    Console.WriteLine("Method Get");
  }

  if (context.User.IsInRole("Admin"))
  {
    Console.WriteLine("Admin Rolü Var");
  }

  await next();

  Console.WriteLine("Response");

  if(context.Response.StatusCode == 200)
  {
    Console.WriteLine("Ýstek baþarýlý");
  }

});


//app.UseMiddleware<RequestLoggingMiddleware>();
app.UseRequestLogging();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

// Customer Middleware buraya yazýlýrsa çalýþmaz