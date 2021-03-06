using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Tokens;

namespace ProductsService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            
        }

        public IConfiguration Configuration { get; }
        CustomConfiguration customConfiguration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            IdentityModelEventSource.ShowPII = true;
            customConfiguration = new CustomConfiguration();
            Configuration.GetSection("CustomConfiguration").Bind(customConfiguration);
            //Configuration.GetSection

            services.Configure<CustomConfiguration>(Configuration);

            //services.AddDbContextPool<ConfigurationStoreContext>(o => o.UseSqlServer(connectionString));

            AddAuthentication(services);
            services.AddControllers();
        }

        private void AddAuthentication(IServiceCollection services)
        {
            
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            })
                .AddJwtBearer(o =>
                {
                    o.Authority = "https://localhost:44311";//auth server address
                    //o.Authority = customConfiguration.TokenAuthority;
                    o.Audience = "ProductsApi";//not used to validate
                    o.RequireHttpsMetadata = false;
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("somethingyouwantwhichissecurewillworkk")),
                        ValidateIssuer = true,
                        ValidateAudience = true
                    };
                });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("PublicSecure1", policy => policy.RequireClaim("client_id"));
                options.AddPolicy("PublicSecure2", policy => policy.RequireClaim(ClaimTypes.Email));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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
        }
    }
}
