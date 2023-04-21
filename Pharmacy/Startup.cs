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
using Microsoft.OpenApi.Models;
using Pharmacy.BL.Interfaces;
using Pharmacy.BL.Services;
using Pharmacy.Core.Models;
using Pharmacy.Entity;
using System;
using System.Security.Claims;
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
            services.Configure<DepartmentSettings>(Configuration.GetSection("DepartmentSettings"));
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<Entity.PharmacyContext>(opt => opt.UseSqlServer(connection));

            /*services.Configure<IdentityOptions>(options => 
                options.ClaimsIdentity.UserIdClaimType = ClaimTypes.NameIdentifier);*/
            services.AddIdentity<User, IdentityRole<int>>(options =>
                {
                    //options.ClaimsIdentity.EmailClaimType = ClaimTypes.Name;
                    //options.ClaimsIdentity.UserIdClaimType = ClaimTypes.Name;
                    
                    options.ClaimsIdentity.UserIdClaimType = ClaimTypes.NameIdentifier;
                    options.ClaimsIdentity.EmailClaimType = ClaimTypes.Email;
                })
                .AddEntityFrameworkStores<Entity.PharmacyContext>()
                .AddDefaultTokenProviders();

            services.AddHttpClient();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IAdministrationService, AdministrationService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICommerceService, CommerceService>();
            services.AddScoped<IWarehouseService, WarehouseService>();
            services.AddScoped<IPriceService, PriceService>();

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
                    // ��������� ��������
                    ValidateIssuer = true,
                    // ��������
                    ValidIssuer = tokenSettings.Issuer,
                    // ��������� �����������
                    ValidateAudience = true,
                    // �����������
                    ValidAudience = tokenSettings.Audience,
                    // ��������� ������� �����
                    ValidateLifetime = true,
                    // ��������� ����� ������������
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    // ��������� ����� ������������
                    ValidateIssuerSigningKey = true,
                    // �� ��������� ����� ����� 5 �����
                    ClockSkew = TimeSpan.Zero,
                    
                };
            });
            //End Token settings

            services.AddControllers()
                .AddJsonOptions(opt=> 
                opt.JsonSerializerOptions.PropertyNamingPolicy = null);
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist/ClientApp";
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApplication1", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pharmacy v1"));
            }

            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseAuthentication();
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
