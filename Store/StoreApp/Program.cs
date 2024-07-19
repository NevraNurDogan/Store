using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using StoreApp.Models;

var builder = WebApplication.CreateBuilder(args);// web uygulaması inşaa edici

builder.Services.AddControllersWithViews();//hem controller'ların (denetleyiciler) hem de view'ların (görünümler) kullanılabilmesi için gereken altyapıyı sağlar
builder.Services.AddDbContext<RepositoryContext>(options =>{
    options.UseSqlite(builder.Configuration.GetConnectionString("sqlconnection"));
});

var app = builder.Build();

app.UseStaticFiles();
app.UseHttpsRedirection();// metodu, HTTP isteklerini HTTPS'ye yönlendirmek için kullanılır. 
app.UseRouting();// Routing middleware'ini etkinleştirir ve gelen istekleri doğru controller ve action method'larına yönlendirir.

app.MapControllerRoute(//URL yönlendirme (routing) kurallarını tanımlamak için kullanılır.
    "default",
    "{controller=Home}/{action=Index}/{id?}");
app.Run();
