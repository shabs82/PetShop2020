using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using PetShop2020.Core.Application_Service;
using PetShop2020.Core.Application_Service.Service;
using PetShop2020.Core.Application_Service.Services;
using PetShop2020.Core.Domain_Service;
using PetShop2020.Core.Helper;
using PetShop2020.Infrastruture;

namespace PetShop2020.UI.Rest.API
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
            Byte[] secretBytes = new byte[40];
            Random rand = new Random();
            rand.NextBytes(secretBytes);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretBytes),
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(5)
                };
            });
            var loggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });
                services.AddSwaggerGen(options =>
                {
                    options.SwaggerDoc("v1",
                        new OpenApiInfo
                        {
                            Title = "Pet Shop ",
                            Description = "Pet Shop API",
                            Version = "v1"

                        });
                    var fileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.XMl";
                    var filePath = Path.Combine(AppContext.BaseDirectory, fileName);
                    options.IncludeXmlComments(filePath);
                });




                services.AddDbContext<PetShop2020DBContext>(opt =>
                {
                    opt.UseLoggerFactory(loggerFactory);//logs all sql queries.

                    opt.UseSqlite("Data Source=PetShopApp.db");
                });

                services.AddCors(options =>
                    options.AddDefaultPolicy(builder =>
                    {
                        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                    }));
                services.AddScoped<IPetRepository, PetRepository>();
                services.AddScoped<IPetService, PetService>();

                services.AddScoped<IOwnerRepository, OwnerRepository>();
                services.AddScoped<IOwnerService, OwnerService>();
                services.AddSingleton<IAuthenticationHelper>(new AuthenticationHelper(secretBytes));
                services.AddTransient<IDBInitializer, DBInitializer>();
                services.AddControllers().AddNewtonsoftJson(option =>
                {
                    option.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    option.SerializerSettings.MaxDepth = 5;
                }); //is to avoid a never ending reference loop between entities.

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            {
                if (env.IsDevelopment())
                {
                    using (var scope = app.ApplicationServices.CreateScope())
                    {
                        PetShop2020DBContext context = scope.ServiceProvider.GetService<PetShop2020DBContext>();
                        context.Database.EnsureDeleted();// only in dev mode. never in prod mode or the whole database will be lost.
                        context.Database.EnsureCreated();
                        IDBInitializer DbInit = scope.ServiceProvider.GetService<IDBInitializer>();
                        DbInit.Seed(context);
                    }

                    app.UseDeveloperExceptionPage();
                }

                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Pet Shop API");
                    options.RoutePrefix = "";

                });

                app.UseHttpsRedirection();

                app.UseRouting();

                app.UseCors();

                app.UseAuthentication();

                app.UseAuthorization();

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers(); 

                });


            }
        }
    }
        