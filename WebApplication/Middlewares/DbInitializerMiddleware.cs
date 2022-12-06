using Persistence;

namespace WebApplication.Middlewares
{
    public class DbInitializerMiddleware
    {
        private readonly RequestDelegate _next;

        public DbInitializerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;

                try
                {
                    var dbcontext = serviceProvider.GetRequiredService<AppDbContext>();
                    DbInitializer.Initialize(dbcontext);
                }
                catch
                {

                }
            }

            await _next.Invoke(context);
        }
    }
}
