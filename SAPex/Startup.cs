using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BusinessLogicLayer.Helpers;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using DataAccessLayer.Service;
using DbMigrations.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SAPexAuthService.Models;
using SAPexAuthService.Services;

namespace SAPex
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
            services.AddCors();
            services.AddControllers();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings").GetSection("Secret").Value)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                };
            });

            services.AddDbContext<AppDbContext>(options => options
                                                           .UseLazyLoadingProxies()
                                                           .UseSqlServer(Environment.GetEnvironmentVariable("MSSQL_CONNECTION_STRING")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.Configure<AppSettingsModel>(Configuration.GetSection("AppSettings"));
            services.AddScoped<AuthUserService, AuthUserService>();
            services.AddScoped<AuthUserRefreshTokenService, AuthUserRefreshTokenService>();
            services.AddScoped<JwtService, JwtService>();

            services.AddSwaggerGen(c =>
            {
                var jwtSecurityScheme = new OpenApiSecurityScheme
                {
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Name = "JWT Authentication",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme,
                    },
                };

                c.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { jwtSecurityScheme, Array.Empty<string>() },
                });
                c.OperationFilter<SwaggerFileUploadOperationFilter>();
            });

            services.AddScoped<IAvailabilityTypeService, AvailabilityTypeService>();
            services.AddScoped<ILanguageLevelService, LanguageLevelService>();
            services.AddScoped<ISandboxService, SandboxService>();
            services.AddScoped<ISkillService, SkillService>();
            services.AddScoped<ILanguageService, LanguageService>();
            services.AddScoped<IStackTechnologyService, StackTechnologyService>();
            services.AddScoped<ICandidateService, CandidateService>();
            services.AddScoped<ISandboxLanguagesService, SandboxLanguageService>();
            services.AddScoped<ISandboxStackTechnologyService, SandboxStackTechnologyService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IFileService, FileService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppDbContext dbContext)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "SAPex API v1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            // app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            dbContext.Database.Migrate();

            List<IApplicationHelper> helpers = new ()
            {
                new UserHelper(dbContext),
                new RoleHelper(dbContext),
                new UserRoleHelper(dbContext),
            };
            helpers.ForEach(helper => helper.CreateTestData());

            TestDataHelper.InitTestData(Environment.GetEnvironmentVariable("MSSQL_CONNECTION_STRING"));
        }
    }
}
