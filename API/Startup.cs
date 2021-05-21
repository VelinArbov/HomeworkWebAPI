using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Endava.Internship2020.WebApiExamples.DataAccess;
using Endava.Internship2020.WebApiExamples.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace API
{
    public class Startup
    {
        private IConfiguration _config;
        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerExamplesFromAssemblyOf<Startup>();
            services.AddScoped<ITicketsRepository, TicketsRepository>();
            services.AddScoped<ITicketService, TicketsService>();
            services
                .AddControllersWithViews()
                .AddNewtonsoftJson();
            services.AddSwaggerGen(options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Version = "v1",
                        Title = "Homework Web API",
                        Description = "A simple example ASP.NET Core Web API",
                        TermsOfService = new Uri("https://example.com/terms"),
                        Contact = new OpenApiContact
                        {
                            Name = "Velin Arbov",
                            Email = "arbov.v@gmail.com",
                            Url = new Uri("https://www.linkedin.com/in/velin-arbov/"),
                        }
                    });
                    options.IgnoreObsoleteActions();
                    options.ExampleFilters();
                }
            );
            services.AddDbContext<DataContext>(x =>
                    x.UseSqlServer(_config.GetConnectionString("DefaultConnection")));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "HOMEWORK ENDAVA API V1");
                c.RoutePrefix = string.Empty;
            });
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

            Migrate(app);
        }

        private static void Migrate(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var dataContext = scope.ServiceProvider.GetService<DataContext>();
            dataContext?.Database.Migrate();
        }
    }
}
