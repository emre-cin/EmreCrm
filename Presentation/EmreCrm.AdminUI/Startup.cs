using AutoMapper;
using AutoMapper.Configuration;
using EmreCrm.Core.Caching;
using EmreCrm.Core.Helper;
using EmreCrm.Core.Models;
using EmreCrm.Core.UnitOfWork;
using EmreCrm.Data.Context;
using EmreCrm.Model.Mapper;
using EmreCrm.Service.UserService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;

namespace EmreCrm.AdminUI
{
    public class Startup
    {
        public Startup(Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public Microsoft.Extensions.Configuration.IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region Options

            services.AddOptions();

            AppSettings appSettings = new AppSettings();
            Configuration.GetSection("AppSettings").Bind(appSettings);

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            #endregion

            #region Max Size Support

            services.Configure<FormOptions>(x =>
            {
                x.BufferBodyLengthLimit = int.MaxValue;
                x.KeyLengthLimit = int.MaxValue;
                x.MultipartBodyLengthLimit = int.MaxValue;
                x.ValueCountLimit = int.MaxValue;
                x.ValueLengthLimit = int.MaxValue;
            });

            #endregion

            #region DbContext

            services.AddDbContext<EmreCrmContext>(options => options.UseSqlServer(appSettings.DatabaseSettings.ConnectionString, b => b.MigrationsAssembly("Data")));

            #endregion

            #region UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            #endregion

            #region Auto Mapper

            MapperConfigurationExpression mapperConfig = new MapperConfigurationExpression();

            mapperConfig.AllowNullCollections = true;

            mapperConfig.AddProfile(new AutoMapperProfileConfiguration());

            Mapper.Initialize(mapperConfig);

            #endregion

            //Injection
            services.AddSingleton<RedisCacheService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IUserService, UserService>();

            //services.AddAuthentication(o =>
            //{
            //    o.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //    o.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //    o.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //})
            //.AddCookie(o =>
            //{
            //    o.LoginPath = new PathString("/Home/Login");
            //    o.LogoutPath = new PathString("/Home/Logout");
            //});


            services.AddMvc()
                        .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                        .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver())
                        .AddNewtonsoftJson(options => options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore);

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) 
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                   name: "users",
                   pattern: "/kullanicilar",
                   defaults: new { controller = "Home", action = "Index" });

                endpoints.MapControllerRoute(
                   name: "add-user",
                   pattern: "/kullanici-ekle",
                   defaults: new { controller = "Home", action = "Add" });

                endpoints.MapControllerRoute(
                   name: "edit-user",
                   pattern: "/kullanici/{id}",
                   defaults: new { controller = "Home", action = "Edit" });

                endpoints.MapControllerRoute(
                   name: "delete-user",
                   pattern: "/kullanici-sil/{id}",
                   defaults: new { controller = "Home", action = "Delete" });
            });
        }
    }
}
