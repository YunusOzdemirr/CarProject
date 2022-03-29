using System;
using CarProject.Business.Abstract;
using CarProject.Business.Concrete;
using CarProject.Data.Concrete.EntityFramework.DatabaseContext;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CarProject.Business.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<Context>();
            serviceCollection.AddScoped<IJwtHelper, JwtHelper>();
            serviceCollection.AddScoped<ICarService, CarManager>();
            //serviceCollection.AddScoped<IUserService, UserManager>();
            serviceCollection.AddScoped<IAuthService, AuthManager>();
            serviceCollection.AddScoped<IBusService, BusManager>();
            serviceCollection.AddScoped<IBoatService, BoatManager>();
            return serviceCollection;
        }
    }
}

