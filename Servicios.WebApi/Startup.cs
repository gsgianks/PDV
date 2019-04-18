using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Servicios.BusinessLogic.Implementations;
using Servicios.BusinessLogic.Intefaces;
using Servicios.DataAccess;
using Servicios.UnitOfWork;
using Servicios.WebApi.Authentication;
using Servicios.WebApi.Controllers.GlobalErrorHandling;

namespace Servicios.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

       // readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            /*inicio pruebas*/
            services.AddCors(options =>
            {
                options.AddPolicy("MyPolicy",
                builder =>
                {
                    builder.AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowAnyOrigin();
                });
            });
            /*fin pruebas*/

            //Inyección de dependencias de capa de lógica.
            services.AddTransient<ISupplierLogic, SupplierLogic>();
            services.AddTransient<IOrderLogic, OrderLogic>();
            services.AddTransient<ICustomerLogic, CustomerLogic>();
            services.AddTransient<IProductosLogic, ProductosLogic>();
            services.AddTransient<ITokenLogic, TokenLogic>();


            services.AddSingleton<IUnitOfWork>(option => new ServiciosUnitOfWork(
                Configuration.GetConnectionString("BDPuntoVenta")
                ));

            var tokenProvider = new JwtProvider("issuer", "audience", "northwind_2000");
            services.AddSingleton<ITokenProvider>(tokenProvider);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options=> 
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = tokenProvider.GetValidationParameters();
                });
            services.AddAuthorization(auth => {
                auth.DefaultPolicy = new AuthorizationPolicyBuilder()
                .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                .RequireAuthenticatedUser()
                .Build();
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseCors("MyPolicy");
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.ConfigureExceptionHandler();
            app.UseMvc();
        }
    }
}
