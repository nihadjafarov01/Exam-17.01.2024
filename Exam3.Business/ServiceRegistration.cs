
using AutoMapper;
using Exam3.Business.Profiles;
using Microsoft.Extensions.DependencyInjection;

namespace Exam3.Business
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICardRepository, CardRepository>();
            return services;
        }
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICardService, CardService>();
            services.AddScoped<IAuthService, AuthService>();
            return services;
        }
        public static IServiceCollection AddMappers(this IServiceCollection services)
        {
            services.AddAutoMapper(opt =>
            {
                opt.AddProfile<CardMappingProfile>();
            });
            return services;
        }
    }
}

