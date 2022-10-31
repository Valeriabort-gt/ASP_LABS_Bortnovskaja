using System.Reflection;
using Application;
using Application.Common.Mappings;
using Application.Interfaces;
using Persistence;
using WebAPI.MiddlewareEndpoints;
//using WebAPI.Middleware;
//using WebAPI.Endpoints;

namespace WebAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(config =>
            {
                config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
                config.AddProfile(new AssemblyMappingProfile(typeof(IDbContext).Assembly));
            });

            services.AddApplication();
            services.AddPersistence(Configuration);
            services.AddControllers();
            services.AddDistributedMemoryCache();
            services.AddMemoryCache();
            services.AddSession();
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseCors("AllowAll");
            app.UseSession();
            app.Map("/Info", RouteEndpoints.Info);
            app.Map("/Rents", RouteEndpoints.GetRents);
            app.Map("/searchFirst", RouteEndpoints.FirstSearch);
            app.Map("/searchSecond", RouteEndpoints.SecondSearch);

            //app.UseMiddleware<DefaultMidlleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello world");
                });
            });
        }
    }
}
