using Estate.API.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Estate.API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddIdentityServer()
                .AddInMemoryApiResources(IdentityServerConfiguration.GetApis())
                .AddInMemoryClients(IdentityServerConfiguration.GetClients())
                .AddDeveloperSigningCredential();

            //services.AddAuthorization();

            //services.AddAuthentication()
            //    .AddJwtBearer("Bearer", option => {
            //        option.Authority = "http://localhost:5000";
            //        option.RequireHttpsMetadata = false;
            //        option.Audience = IdentityServerConfiguration.SCOPE_NAME;
            //    });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseIdentityServer();
            //app.UseAuthentication();
            app.UseMvc();
        }
    }
}
