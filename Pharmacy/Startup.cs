using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Pharmacy.BL.Interfaces;
using Pharmacy.BL.Services;
using Pharmacy.Core.Models;
using Pharmacy.Entity;
using System;
using System.Text;

namespace Pharmacy
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<Entity.PharmacyContext>(opt => opt.UseSqlServer(connection));

            services.AddIdentity<User, IdentityRole<int>>()
                .AddEntityFrameworkStores<Entity.PharmacyContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserService, UserService>();

            //Token settings
            var tokenSettingsSection = Configuration.GetSection("TokenSettings");
            services.Configure<TokenModel>(tokenSettingsSection);

            var tokenSettings = tokenSettingsSection.Get<TokenModel>();
            byte[] key = Encoding.ASCII.GetBytes(tokenSettings.Key);

            services.AddAuthentication(_ =>
            {
                _.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer("Bearer", options =>
            {
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    // валидация издателя
                    ValidateIssuer = true,
                    // издатель
                    ValidIssuer = tokenSettings.Issuer,
                    // валидация потребителя
                    ValidateAudience = true,
                    // потребитель
                    ValidAudience = tokenSettings.Audience,
                    // валидация времени жизни
                    ValidateLifetime = true,
                    // установка ключа безопасности
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    // валидация ключа безопасности
                    ValidateIssuerSigningKey = true,
                    // по умолчанию время жизни 5 минут
                    ClockSkew = TimeSpan.Zero
                };
            });
            //End Token settings

            services.AddControllers();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseAuthentication();    // подключение аутентификации
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSpa(spa =>
            {

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
