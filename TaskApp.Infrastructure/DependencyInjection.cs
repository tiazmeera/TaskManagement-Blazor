using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskApp.Application.Interfaces;
using TaskApp.Infrastructure.Persistence;

namespace TaskApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            var conn = config.GetConnectionString("DefaultConnection") ?? "Data Source=taskapp.db";

            services.AddDbContext<TodoDbContext>(options =>
                options.UseSqlite(conn));

            services.AddScoped<ITodoDbContext>(provider => provider.GetRequiredService<TodoDbContext>());

            return services;
        }
    }
}
