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
//�ԳƼ���
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            //Audience,Issuer,clientSecret��ֵҪ��sso��һ��

            //JWT��һЩĬ�ϵ����ԣ����Ǹ���Ȩʱ�Ϳ���ɸѡ��
            ValidateIssuer = true,//�Ƿ���֤Issuer
            ValidateAudience = true,//�Ƿ���֤Audience
            ValidateLifetime = true,//�Ƿ���֤ʧЧʱ��
            ValidateIssuerSigningKey = true,//�Ƿ���֤client secret
            ValidIssuer = builder.Configuration["SSOSetting:issuer"],//
            ValidAudience = builder.Configuration["SSOSetting:audience"],//Issuer���������ǰ��ǩ��jwt������һ��
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["SSOSetting:clientSecret"]))//client secret
        };
    });

#region �ǶԳƼ���-��Ȩ
//var rsa = RSA.Create();
//byte[] publickey = Convert.FromBase64String(AppSetting.PublicKey); //��Կ��ȥ��begin...  end ...
////rsa.ImportPkcs8PublicKey ��һ����չ��������Դ��RSAExtensions��
//rsa.ImportPkcs8PublicKey(publickey);
//var key = new RsaSecurityKey(rsa);
//var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.RsaPKCS1);//˽Կ����pkcs1��pkcs8֮�֣���Կû��

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer(options =>
//    {
//        options.TokenValidationParameters = new TokenValidationParameters
//        {
//            //Audience,Issuer,clientSecret��ֵҪ��sso��һ��

//            //JWT��һЩĬ�ϵ����ԣ����Ǹ���Ȩʱ�Ϳ���ɸѡ��
//            ValidateIssuer = true,//�Ƿ���֤Issuer
//            ValidateAudience = true,//�Ƿ���֤Audience
//            ValidateLifetime = true,//�Ƿ���֤ʧЧʱ��
//            ValidateIssuerSigningKey = true,//�Ƿ���֤client secret
//            ValidIssuer = builder.Configuration["SSOSetting:issuer"],//
//            ValidAudience = builder.Configuration["SSOSetting:audience"],//Issuer���������ǰ��ǩ��jwt������һ��
//            IssuerSigningKey = signingCredentials.Key
//        };
//    });

#endregion

var app = builder.Build();
ServiceLocator.Instance = app.Services;// ServiceLocator.Instance = app.Services; //�����ֶ���ȡDI����
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
app.UseAuthentication();//�����
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();