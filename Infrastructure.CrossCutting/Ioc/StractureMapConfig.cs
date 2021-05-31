using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hamporsesh.Application.Answers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StructureMap;

namespace Infrastructure.CrossCutting.Ioc
{
    public static class StructureMapConfig
    {
        public static IServiceProvider ConfigureIocContainer(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddSingleton<IConfiguration>(provider => { return configuration; });

            var container = new Container();
            container.Configure(config =>
            {
              
                //DbContext
               // config.For<IMainContext>().Use<MongoDbContext>();
               
                //Sevices
                config.For<IAnswerService>().Use<AnswerService>();
                //TODO add all services
                
            });


            container.Populate(services);

            return container.GetInstance<IServiceProvider>();
        }

    }
}
