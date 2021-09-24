using AutoMapper;
using AutoMapper.Configuration;
using EmreCrm.Core.Caching;
using EmreCrm.Core.Models;
using EmreCrm.Core.UnitOfWork;
using EmreCrm.Data.Context;
using EmreCrm.Model.Mapper;
using EmreCrm.Service.UserService;
using EmreCrm.WebApi.Filter;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;
using System.Text;
using System.Threading.Tasks;

namespace EmreCrm.WebApi
{
    public class Startup
    {
        public Startup(Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public Microsoft.Extensions.Configuration.IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            #region Application Settings

            services.AddOptions();

            AppSettings appSettings = new AppSettings();
            Configuration.GetSection("AppSettings").Bind(appSettings);

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            #endregion

            #region DbContext

            services.AddDbContext<EmreCrmContext>(options => options.UseSqlServer(appSettings.DatabaseSettings.ConnectionString, b => b.MigrationsAssembly("Data")));

            #endregion

            #region UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            #endregion

            #region Injection

            services.AddSingleton<RedisCacheService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IUserService, UserService>();

            #endregion

            #region Auto Mapper

            MapperConfigurationExpression mapperConfig = new MapperConfigurationExpression();

            mapperConfig.AllowNullCollections = true;

            mapperConfig.AddProfile(new AutoMapperProfileConfiguration());

            Mapper.Initialize(mapperConfig);

            #endregion

            #region Api Settings

            services.AddMvcCore().AddApiExplorer();

            #endregion

            #region Swagger

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "EmreCrm API Documentation",
                    Version = "v1",
                });
            });

            #endregion

            #region Jwt

            var key = Encoding.ASCII.GetBytes(appSettings.JwtConfiguration.SigningKey);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.Audience = appSettings.JwtConfiguration.Audience;
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.ClaimsIssuer = appSettings.JwtConfiguration.Issuer;
                x.IncludeErrorDetails = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = true
                };
                x.Events = new JwtBearerEvents()
                {
                    OnTokenValidated = (context) =>
                    {
                        var name = context.Principal.Identity.Name;
                        if (string.IsNullOrEmpty(name))
                        {
                            context.Fail("Yetki saðlanamadý.");
                        }
                        return Task.CompletedTask;
                    }
                };
            });

            #endregion

            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ValidateModelAttribute));
            })
              .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
              .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver())
              .AddNewtonsoftJson(options => options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "EmreCrm API");
            });
        }
    }
}
