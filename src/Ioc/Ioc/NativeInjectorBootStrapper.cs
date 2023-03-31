using Autofac;
using Microsoft.Extensions.DependencyInjection;
using Application.Contracts;
using Application.Services;
using Application.Validations.Management;
using Domain.Contracts;
using Infrastructure.Context;
using Infrastructure.Contracts;
using Infrastructure.Repositories;

namespace Ioc
{
    public class NativeInjectorBootStrapper : Module
    {

        public static void RegisterServices(IServiceCollection serviceCollection)
        {
            //Validation
            serviceCollection.AddScoped<IDistribuitorManagement, DistribuitorManagement>();


            //DB
            serviceCollection.AddScoped<IMongoDBContext, MongoDBContext>();


            // Application
            serviceCollection.AddScoped(typeof(IService<,>), typeof(Service<,>));

            // Repository
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            serviceCollection.AddScoped<IDistribuitorRepository, DistribuitorRepository>();


        }
    }
}
