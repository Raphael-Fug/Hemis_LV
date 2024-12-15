using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using C500Hemis.Controllers.NH;

var builder = WebApplication.CreateBuilder(args);

// Cấu hình DbContext cho SQL Server
builder.Services.AddDbContext<C500Hemis.Models.HemisContext>(options =>
    options.UseSqlServer("Server=tcp:c500sv.database.windows.net,1433;Database=dbHemisC500;User Id=c500;Password=@Abc1234")
);

// Cấu hình localization để hỗ trợ tiếng Việt
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[] { new CultureInfo("vi-VN") };
    options.DefaultRequestCulture = new RequestCulture("vi-VN");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

// Thêm các dịch vụ vào container
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient<C500Hemis.API.ApiServices>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Cấu hình pipeline HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

// Kích hoạt localization
app.UseRequestLocalization();

app.UseRouting();

app.UseAuthorization();

// Thiết lập route mặc định
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

// Ánh xạ các API controller
app.MapControllers(); // Thay thế dòng này cho MapApiServicesEndpoints

app.Run();
