using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using swapi_films_rater.DB;
using Microsoft.EntityFrameworkCore;
using swapi_films_rater.Repository.APIServices;
using swapi_films_rater.Repository.Helpers;
using swapi_films_rater.DB.DAL;
using AutoMapper;
using swapi_films_rater.Repository.DALServices;

namespace swapi_films_rater
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
            //services.AddDbContext<SqlContext>();
            services.AddDbContext<SqlContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("ConnString")));
            services.AddControllersWithViews();
            services.AddAutoMapper(typeof(Startup));


            services.AddHttpClient("swapi", opt => opt.BaseAddress = new Uri("https://swapi.dev/api"));

            services.AddTransient<IFilmsSwapiService, FilmsSwapiService>();
            services.AddTransient<IFilmsHelper, FilmsHelper>();

            services.AddTransient<IFilmRatingsDAL, FilmRatingsDAL>();

            services.AddTransient<IFilmRatingsDalService, FilmRatingsDalService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, SqlContext sqlContext)
        {
            sqlContext.Database.Migrate();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
