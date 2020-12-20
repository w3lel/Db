using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CyberAge.Database;
using AutoMapper;
using Swashbuckle.AspNetCore.Swagger;
using CyberAge.Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using CyberAge.Authorization.Jwt;
using CyberAge.Authorization.Jwt.Models;
using CyberAge.Utils;
using Microsoft.AspNetCore.Authorization;

namespace CyberAge.API
{
    public class Startup
    {

        /// <summary/>
        private IdentityOptions IdentityOptions { get; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="configuration">Конфигурация</param>
        /// <param name="environment">Окружение</param>
        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
            IdentityOptions = new IdentityOptions
            {
                TokenIssuer = "Server",
                TokenAudience = "Audience",
                LifeTime = TimeSpan.FromDays(90),
                SigningKey = "b12e1814-957c-44a9-aa34-d366b6450682"
            };
        }


        /// <summary>
        /// Окружение
        /// </summary>
        public IHostingEnvironment Environment { get;  }

        /// <summary>
        /// Конфигурация
        /// </summary>
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            #region Session
            
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build());
            });

            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(o =>
                {
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(IdentityOptions.SigningKey)),

                        ValidateIssuer = true,
                        ValidIssuer = IdentityOptions.TokenIssuer,

                        ValidateAudience = true,
                        ValidAudience = IdentityOptions.TokenAudience,

                        ValidateLifetime = true,

                        ClockSkew = TimeSpan.Zero
                    };
                });
            services.AddIdentityServices(options =>
            {
                options.TokenIssuer = IdentityOptions.TokenIssuer;
                options.TokenAudience = IdentityOptions.TokenAudience;
                options.LifeTime = IdentityOptions.LifeTime;
                options.SigningKey = IdentityOptions.SigningKey;
            });

            #endregion

            #region Data

            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseNpgsql(Configuration["Database"], builder => builder.MigrationsAssembly("EmpApp.API"));
            });
            
            services.AddScoped<DatabaseInitializer>();

            services.AddAutoMapper(a =>
            {
                Mapper.Initialize(options => options.AddProfile<DomainMappingProfile>());
            });

            #endregion

            #region Utils

            services.AddUtils();

            #endregion

            #region Core

            services.AddMvc();
            services.AddDomain();

            #endregion

            if (Environment.IsDevelopment())
            {
                //Documents
                services.AddSwaggerGen(options =>
                {
                    options.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
                    options.AddSecurityDefinition("Bearer", new ApiKeyScheme
                    {
                        Description = "Авторизация с помощью JWT токена. Пример: Bearer -token-",
                        Name = "Authorization",
                        In = "header",
                        Type = "apiKey"
                    });
                });

                services.Configure<CookiePolicyOptions>(options =>
                {
                    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                    options.CheckConsentNeeded = context => true;
                    options.MinimumSameSitePolicy = SameSiteMode.None;
                });

            }
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseMvcWithDefaultRoute();
        }
    }
}

