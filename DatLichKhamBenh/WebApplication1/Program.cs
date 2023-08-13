using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Services;
using WebApplication1.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSession();
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<KhoaService, KhoaServiceImpl>();
builder.Services.AddScoped<BacsiService, BacsiServiceImpl>();
builder.Services.AddScoped<LichKhamService, LichKhamServiceImpl>();
builder.Services.AddScoped<BennhanService, BennhanServiceImpl>();
builder.Services.AddScoped<UserService, UserServiceImpl>();
builder.Services.AddDbContext<DatabaseContext>(
    option => option.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

/*// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}*/
var app = builder.Build();
app.UseSession();

app.UseMiddleware<RoleMiddleware>();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action}");

app.Run();
