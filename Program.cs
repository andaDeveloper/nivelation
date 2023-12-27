using Microsoft.EntityFrameworkCore;
using PruebaNivelacion.Controllers;
using PruebaNivelacion.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

//config database string connection
builder.Services.AddDbContext<BookContext>(
    options =>
        //options.UseSqlServer(builder.Configuration["BooksConnection_ConnectionString"])
    );

builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache(); 
builder.Services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromMinutes(10);
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
        }
    );

builder.Configuration.AddEnvironmentVariables();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<BookContext>();
    context.Database.Migrate();
    context.Database.EnsureCreated();
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    //config user secrets
    builder.Configuration.AddUserSecrets<BookController>();

}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
