using Movies.Application;
using Movies.DataAccess;
using Movies.DataAccess.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDataAccess(builder.Configuration).AddApplication();

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
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

app.MapControllerRoute(
name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


await AutomatedMigration.MigrateAsync(app.Services);

app.Run();
