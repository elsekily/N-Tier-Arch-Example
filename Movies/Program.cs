using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Movies.Application;
using Movies.Controllers.API;
using Movies.DataAccess;
using Movies.DataAccess.Identity;
using Movies.DataAccess.Persistence;
using Movies.Helpers;
using System.Data;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddAuthorization(config =>
//{
//    config.AddPolicy(Roles.Admin, Policies.Policy(Roles.Admin));
//});

//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//})
//    .AddJwtBearer(opt =>
//    {
//        opt.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuer = false,
//            ValidateAudience = false,
//            ValidateLifetime = true,
//            ValidateIssuerSigningKey = true,
//            IssuerSigningKey =
//            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
//        };
//        opt.Events = new JwtBearerEvents
//        {
//            OnChallenge = context =>
//            {
//                context.HandleResponse();
//                context.Response.StatusCode = 401;
//                context.Response.ContentType = "application/json";
//                var result = JsonConvert.SerializeObject(new { error = "Unauthorized" });
//                return context.Response.WriteAsync(result);
//            }
//        };
//    });
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


await AutomatedMigration.MigrateAsync(app.Services);

app.Run();
