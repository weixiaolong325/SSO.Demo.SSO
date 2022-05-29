using SSO.Demo.SSO.Util;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.AddMemoryCache();
builder.Services.AddSingleton<IJWTService, JWTHSService>(); //对称加密
//builder.Services.AddSingleton<IJWTService, JWTRSService>(); //非对称加密
builder.Services.AddSingleton<Cachelper>();
builder.Services.Configure<AppSettingOptions>(builder.Configuration.GetSection("AppSetting"));


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

app.Run();
