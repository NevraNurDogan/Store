using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contracts;
using Services;
using Services.Contracts;
using StoreApp.Models;

var builder = WebApplication.CreateBuilder(args); // web uygulaması inşaa edici

builder.Services.AddControllersWithViews(); // hem controller'ların (denetleyiciler) hem de view'ların (görünümler) kullanılabilmesi için gereken altyapıyı sağlar
builder.Services.AddRazorPages();//controller olmadan view yapısı oluşturmak için 

builder.Services.AddDbContext<RepositoryContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("sqlconnection"),
    b => b.MigrationsAssembly("StoreApp"));
});
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.Cookie.Name="StoreApp.Session";
    options.IdleTimeout = TimeSpan.FromSeconds(10);
});
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>(); // IoC yapıdaki kayıtların tanımı yapılıyor. 

builder.Services.AddScoped<IServiceManager, ServiceManager>(); // IoC yapıdaki kayıtların tanımı yapılıyor. 
builder.Services.AddScoped<IProductService, ProductManager>(); // Configrasyon adımı
builder.Services.AddScoped<ICategoryService, CategoryManager>();

builder.Services.AddScoped<Cart>(c=> SessionCart.GetCart(c));

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

app.UseStaticFiles();
app.UseSession ();

app.UseHttpsRedirection(); // metodu, HTTP isteklerini HTTPS'ye yönlendirmek için kullanılır. 
app.UseRouting(); // Routing middleware'ini etkinleştirir ve gelen istekleri doğru controller ve action method'larına yönlendirir.

app.UseAuthorization(); // Authorization middleware'ini etkinleştirir

// Üst düzey rota kayıtları
app.MapAreaControllerRoute(
    name: "Admin",
    areaName: "Admin",
    pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);
app.MapRazorPages();

app.MapControllers();

app.Run();
