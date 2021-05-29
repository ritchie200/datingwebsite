using API.Helpers;
using Core.Interfaces.Setting;
using Core.Interfaces.User;
using Infrastructure.Data.Repositories.Settings;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Setting;
using Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Core.Helpers;
using Core.Interfaces.Like;
using Infrastructure.Data.Repositories.Like;
using Core.Interfaces.Message;
using Infrastructure.Repositories.Message;
using API.SignalR;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));
            services.AddScoped<IPhotoService, PhotoService>();
            services.AddAutoMapper(typeof(AutoMapperProfiles));
            services.AddScoped<LogUserActivity>();
            services.Configure<CloudinarySettings>(config.GetSection("CloudinarySettings"));
            services.AddSingleton<PresenceTracker>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
