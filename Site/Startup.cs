namespace Site
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Repository;
    using Services.Abstract;
    using Services.Concrete;
    using System;

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
            services.AddSession(op =>
            {
                op.IdleTimeout = TimeSpan.FromMinutes(20);
                op.Cookie.HttpOnly = true;
            });
            services.AddDistributedMemoryCache();
            services.AddMvc().AddJsonOptions
               (
                   op =>
                   {
                       op.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                   }
               ).AddSessionStateTempDataProvider();
            services.AddTransient<ICommonServices, CommonServices>();
            services.AddTransient<ILegalUserService, LegalUserService>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IIndividualUserService, IndividualUserService>();
            services.AddTransient<IAddressContactService, AddressContactService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IItemService, ItemService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            env.EnvironmentName = EnvironmentName.Development;
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseExceptionHandler("/error");
            app.UseSession();
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                name: "areas",
                template: "{area}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                        name: "default",
                        template: "{controller=Home}/{action=Index}/{id?}");

            });
            

        }
    }
}
