using Exam3.DAL.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Exam3.DAL
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<Exam3DbContext>(opt =>
            {
                opt.UseSqlServer(connectionString);
            });
            return services;
        }
    }
}
