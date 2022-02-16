using BasketballClub_Rest.Domain;
using BasketballClub_Rest.Repository.UnitOfWork;
using BasketballClub_Rest.Services;
using BasketballClubApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballClubApi
{
    /// <summary>
    /// Klasa za konfiguraciju aplikacije, odnosno dodavnje servisa i definisanje pipline-a
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Konstruktor za klasu Startup joja prima parametar configuartion
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        /// <summary>
        /// Properti koji predstavlja konfiguraciju aplikacije
        /// </summary>
        public IConfiguration Configuration { get; }
        /// <summary>
        /// Metoda koja nam sluzi za dodavanje servisa u kontejnjere
        /// </summary>
        /// <param name="services"></param>
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services.AddControllers().AddNewtonsoftJson(
               opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BasketballClubApi", Version = "v1" });
            });
            services.AddControllers().AddNewtonsoftJson(
                opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

           

            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)

            //  .AddJwtBearer(options =>
            //  {


            //      options.TokenValidationParameters = new TokenValidationParameters
            //      {
            //          ValidateIssuer = false,
            //          ValidateAudience = false,
            //          ValidateLifetime = true,
            //          ValidateIssuerSigningKey = true,

            //          IssuerSigningKey = new SymmetricSecurityKey(
            //              Encoding.UTF8.GetBytes(Configuration.GetValue<string>("JWTSecretKey"))
            //          )
            //      };

            //  });
            services.AddDbContext<BCContext>();
            services.AddScoped<IUnitOfWork, BCUnitOfWork>();
            services.AddScoped<PlayerService>();
            services.AddScoped<CoachService>();
            services.AddScoped<GymService>();
            services.AddScoped<TrainingService>();
            services.AddScoped<SelectionService>();



            services.AddSingleton<IAuthService>(new AuthService(
                    new BCUnitOfWork(new BCContext()),
                    Configuration.GetValue<string>("JWTSecretKey"),
                    Configuration.GetValue<int>("JWTLifespan")

                ));



        }
        /// <summary>
        /// Metoda koja nam sluzi za definisanje pipeline-a
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BasketballClubApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(builder => builder
             .AllowAnyOrigin()
             .AllowAnyMethod()
             .AllowAnyHeader()
             );
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
