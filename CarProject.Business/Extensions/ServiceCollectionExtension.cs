using System;
using CarProject.Business.Abstract;
using CarProject.Business.Concrete;
using CarProject.Data.Concrete.EntityFramework.DatabaseContext;
using Microsoft.Extensions.DependencyInjection;

namespace CarProject.Business.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<Context>();
            serviceCollection.AddSingleton<IJwtHelper, JwtHelper>();
            serviceCollection.AddSingleton<ICarService, CarManager>();
            serviceCollection.AddScoped<IUserService, UserManager>();
            serviceCollection.AddScoped<IAuthService, AuthManager>();

            return serviceCollection;
        }
    }
}

