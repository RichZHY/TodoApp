using Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoApp.API.DataAccess.DBContext;

namespace TodoApp.API.Extensions
{
    public static class ServiceExtensions
    {
        private static readonly string AllowAnyOrigin = "_allowAnyOrigin";
        public static void ConfigureCores(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: AllowAnyOrigin,
                    policy =>
                    {
                        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                    });
            });
        }
        public static void ConfigureLoggerService(this IServiceCollection services) { }
        public static void ConfigureSqlContext(this IServiceCollection services, ConfigurationManager config) 
        {
            services.AddDbContext<MainContext>(options =>
            {
                var useInMemoryDb = config.GetValue<bool>("Settings:UseInMemoryDb");
                if (useInMemoryDb)
                {
                    options.UseInMemoryDatabase("InMemoryDb");
                }
                else
                {
                    options.UseSqlite(config.GetConnectionString("WebApiDatabase"));
                }
            });
        }
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddTransient<IRepositoryWrapper, RepositoryWrapper>();
        }
    }
}
