using Microsoft.EntityFrameworkCore;
using PruebaNivelacion.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BookContext>(
    options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("BooksConnection"))
    );

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
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
