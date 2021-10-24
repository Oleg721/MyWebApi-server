using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using BLL.Contracts;
using DAL;
using DAL.Contracts;
using DAL.Repo;
using DTO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MyWebIpi.Contexts;


namespace MyWebIpi
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
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            int maxRequestBodySize = Int32.Parse(Configuration["Limits:MaxRequestBodySize"]);
            int multipartBodyLengthLimit = Int32.Parse(Configuration["Limits:MultipartBodyLengthLimit"]);
            int valueLengthLimit = Int32.Parse(Configuration["Limits:ValueLengthLimit"]);

            services.Configure<KestrelServerOptions>(options =>
            {
                Console.WriteLine(options);
                options.Limits.MaxRequestBodySize = maxRequestBodySize;
            });
            services.Configure<FormOptions>(options =>
            {
               options.ValueLengthLimit = valueLengthLimit;
               options.MultipartBodyLengthLimit = maxRequestBodySize;
            });

            services.AddDbContext<CriptoCoinValueContext>(options =>
                options.UseMySQL(connectionString));
            services.AddHttpContextAccessor();
            services.AddAutoMapper(new[] { typeof(MapperVM), typeof(MapperDAL) });
            services.AddScoped<ICurrencyRepository, CurrencyRepository>();//singlton?
            services.AddScoped<ICurrencyService, CurrencyService>();
            services.AddScoped<IFileIOService<IFormFile, FileDto>, FileIOService>();
            services.AddCors();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyWebIpi", Version = "v1" });
            });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyWebIpi v1"));
            }
         //   app.UseStaticFiles();
            //app.UseStaticFiles(new StaticFileOptions()
            //{
            //    //FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"StaticFiles")),
            //    RequestPath = new PathString("/StaticFiles")
            //});
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(b=> b.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            app.UseAuthorization();
    
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
