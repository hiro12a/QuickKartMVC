using Microsoft.EntityFrameworkCore;
using QuickKartDataAccessLayer.Models;
using QuickKartMVC.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// HTTP Context
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();


builder.Services.AddControllersWithViews();
builder.Services.AddMvc();
builder.Services.AddAutoMapper(x => x.AddProfile(new QuickKartMapper()));
builder.Services.AddDbContext<QuickKartContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("QuickKartCon")));

var app = builder.Build();
app.UseSession();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();

    /*
    builder.Services.AddMvc();
    builder.Services.AddAutoMapper(x => x.AddProfile(new QuickKartMapper()));
    var connection = builder.Configuration.GetConnectionString("QuickkartCon");
    builder.Services.AddDbContext<QuickKartContext>(options => options.UseSqlServer(connection));*/
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Login}/{id?}");

app.Run();
