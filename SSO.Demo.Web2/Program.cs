using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using RSAExtensions;
using SSO.Demo.Web2.Models;
using SSO.Demo.Web2.Utils;
using System.Security.Cryptography;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.AddSingleton<Cachelper>();
builder.Services.Configure<AppOptions>(builder.Configuration.GetSection("AppOptions"));
//对称加密
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            //Audience,Issuer,clientSecret的值要和sso的一致

            //JWT有一些默认的属性，就是给鉴权时就可以筛选了
            ValidateIssuer = true,//是否验证Issuer
            ValidateAudience = true,//是否验证Audience
            ValidateLifetime = true,//是否验证失效时间
            ValidateIssuerSigningKey = true,//是否验证client secret
            ValidIssuer = builder.Configuration["SSOSetting:issuer"],//
            ValidAudience = builder.Configuration["SSOSetting:audience"],//Issuer，这两项和前面签发jwt的设置一致
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["SSOSetting:clientSecret"]))//client secret
        };
    });

#region 非对称加密-鉴权
//var rsa = RSA.Create();
//byte[] publickey = Convert.FromBase64String(AppSetting.PublicKey); //公钥，去掉begin...  end ...
////rsa.ImportPkcs8PublicKey 是一个扩展方法，来源于RSAExtensions包
//rsa.ImportPkcs8PublicKey(publickey);
//var key = new RsaSecurityKey(rsa);
//var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.RsaPKCS1);//私钥才有pkcs1和pkcs8之分，公钥没有

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer(options =>
//    {
//        options.TokenValidationParameters = new TokenValidationParameters
//        {
//            //Audience,Issuer,clientSecret的值要和sso的一致

//            //JWT有一些默认的属性，就是给鉴权时就可以筛选了
//            ValidateIssuer = true,//是否验证Issuer
//            ValidateAudience = true,//是否验证Audience
//            ValidateLifetime = true,//是否验证失效时间
//            ValidateIssuerSigningKey = true,//是否验证client secret
//            ValidIssuer = builder.Configuration["SSOSetting:issuer"],//
//            ValidAudience = builder.Configuration["SSOSetting:audience"],//Issuer，这两项和前面签发jwt的设置一致
//            IssuerSigningKey = signingCredentials.Key
//        };
//    });

#endregion

var app = builder.Build();
ServiceLocator.Instance = app.Services;// ServiceLocator.Instance = app.Services; //用于手动获取DI对象
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
app.UseAuthentication();//加这个
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
