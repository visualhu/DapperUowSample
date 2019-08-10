using Data;
using Data.Context;
using Data.Model.PublicService;
using Data.Model.Sentry;
using Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            TCBase.ConfigCenter.ConfigCenterClient.Init();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDapperDbContext<SentryDbContext>(options =>
            {
                //options.DbName = "TCFlySentryPlus";
                options.Configuration = "Server=192.168.3.222;Port=3306;Database=demo1;Uid=rdbuser;Pwd=Qwer123$;";
            });

            services.AddDapperDbContext<PublicServiceDbContext>(options =>
            {
                //options.DbName = "TCFlyPublicService";
                options.Configuration = "Server=192.168.3.222;Port=3306;Database=demo2;Uid=rdbuser;Pwd=Qwer123$;";
            });

            services.AddScoped<IFlightUserRepository, FlightUserRepository>();
            services.AddScoped<ISysMenuRepository, SysMenuRepository>();
            services.AddScoped<IUnitOfWorkFactory, DapperUnitOfWorkFactory>();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });




            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (string.Equals(env.EnvironmentName, "test"))
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            //app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
