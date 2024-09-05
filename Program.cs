using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;

namespace OpenID
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //builder.Services.AddAuthentication(options =>
            //{
            //    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
            //})
            //.AddCookie()
            //.AddGoogle(options =>
            //{
            //    options.ClientId = "1052113717841-e7qh55aqsmvpcr928nu7f59i2earp3vr.apps.googleusercontent.com";
            //    options.ClientSecret = "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";
            //});
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
            .AddCookie()
            .AddOpenIdConnect(options =>
            {
                options.Authority = "https://accounts.google.com";
                options.ClientId = "1052113717841-e7qh55aqsmvpcr928nu7f59i2earp3vr.apps.googleusercontent.com";
                options.ClientSecret = "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";
                options.CallbackPath = "/signin-google";
                options.Scope.Add("openid");
                options.Scope.Add("profile");
                options.ResponseType = "code";
                options.SkipUnrecognizedRequests = true;
            });
            builder.Services.AddControllersWithViews();

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

            app.Run();
        }
    }
}
