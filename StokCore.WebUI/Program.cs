using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Session;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using StokCore.DataAccessLayer;
using StokCore.WebUI.Resources;
using System.Globalization;

namespace StokCore.WebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            
            builder.Services.AddControllersWithViews();
            builder.Services.AddMvc();
            builder.Services.AddSingleton<LanguageService>();

            builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
            builder.Services.Configure<RequestLocalizationOptions>(
                option =>
                {
                    var supportCultere = new List<CultureInfo> {
                        new CultureInfo("tr-TR"),
                        new CultureInfo("en-US"),
                    };
                    option.DefaultRequestCulture = new RequestCulture(culture: "tr-TR", uiCulture: "tr-TR");
                    option.SupportedCultures = supportCultere;
                    option.SupportedUICultures = supportCultere;

                    option.RequestCultureProviders.Insert(0, new QueryStringRequestCultureProvider());
                });

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/User/Login"; // Giriþ yapma sayfasý
                    options.LogoutPath = "/User/Logout"; // Çýkýþ yapma sayfasý
                    options.AccessDeniedPath = "/User/AccessDenied"; // Eriþim reddedildi sayfasý
                });

            builder.Services.AddSession(); // Session servisini ekledik

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            // Dil ayarlarý tamamen kaldýrýldý
            app.UseRouting();

            app.UseSession(); // Session middleware'i aktif ettik

            app.UseAuthentication();
            app.UseAuthorization();

            var loca = app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(loca.Value);

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Category}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
