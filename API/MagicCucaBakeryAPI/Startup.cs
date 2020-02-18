using MagicCucaBakery.Business;
using MagicCucaBakery.DataAccess.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MagicCucaBakery.Domain.DataAccess.Context.Abstractions;
using MagicCucaBakery.Domain.Abstractions.Business.Abstractions;
using MagicCucaBakery.Domain.DataAccess.Repositories.Abstractions;
using MagicCucaBakery.DataAccess.Repositories;
using AutoMapper;
using MagicCucaBakery.Domain.Mapping;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace MagicCucaBakery.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            // configure jwt authentication
            var key = Encoding.ASCII.GetBytes(Configuration.GetSection("Auth").GetValue<string>("Secret"));
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MagicCucaBakery", Version = "v1" });
            });

            services.AddTransient<IMagicCucaBakeryContext, MagicCucaBakeryContext>();

            services.AddTransient<ICustomersBusiness, CustomersBusiness>();
            services.AddTransient<IProductsBusiness, ProductsBusiness>();
            services.AddTransient<IOrdersBusiness, OrdersBusiness>();
            services.AddTransient<IUsersBusiness, UsersBusiness>();

            services.AddTransient<ICustomersRepository, CustomersRepository>();
            services.AddTransient<IProductsRepository, ProductsRepository>();
            services.AddTransient<IOrdersRepository, OrdersRepository>();
            services.AddTransient<IUsersRepository, UsersRepository>();

            services.AddAutoMapper(typeof(MapperConfig));

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MagicCucaBakery V1");
            });


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            using (MagicCucaBakeryContext context = new MagicCucaBakeryContext(Configuration))
            {
                context.Database.Migrate();
            }
        }
    }
}
