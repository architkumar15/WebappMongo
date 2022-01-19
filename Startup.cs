using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using Newtonsoft.Json.Serialization;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebappMongo.DAL;
using WebappMongo.DAL.DbSettings;
using Microsoft.Extensions.Options;
using WebappMongo.Controllers;
using Bookstore.core;
using WebappMongo.DAL.Collection;

namespace WebappMongo
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

            services.AddTransient< IBookServices ,BookServices > ();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebappMongo", Version = "v1" });
            });

            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

    

            services.AddControllersWithViews().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver
                = new DefaultContractResolver());


            services.Configure<RestaurantDatabaseSettings>(
                Configuration.GetSection(nameof(RestaurantDatabaseSettings)));
           

            services.AddSingleton<IRestaurantDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<RestaurantDatabaseSettings>>().Value);

            services.Configure<BooksDatabaseSettings>(
             Configuration.GetSection(nameof(BooksDatabaseSettings)));
            services.AddSingleton<IBooksDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<BooksDatabaseSettings>>().Value);

            services.AddSingleton<ResturantController>();
            services.AddSingleton<DeveloperController>();
            services.AddSingleton<BooksController>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebappMongo v1"));
            }

           
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
