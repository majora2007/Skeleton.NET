using API.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Skeleton.Data;

namespace Skeleton.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration config, IWebHostEnvironment env)
        {
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);

            services.AddSqLite(config, env);
            services.AddLogging(config);
            services.AddSignalR();
        }

        private static void AddSqLite(this IServiceCollection services, IConfiguration config,
            IWebHostEnvironment env)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite(config.GetConnectionString("DefaultConnection"));
                options.EnableSensitiveDataLogging(env.IsDevelopment());
            });
        }

        private static void AddLogging(this IServiceCollection services, IConfiguration config)
        {
          services.AddLogging();
        }
    }
}
