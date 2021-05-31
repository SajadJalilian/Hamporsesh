using Hamporsesh.Application.Answers;
using Hamporsesh.Application.Choices;
using Hamporsesh.Application.Polls;
using Hamporsesh.Application.Questions;
using Hamporsesh.Application.Users;
using Hamporsesh.Application.Visitors;
using Hamporsesh.Infrastructure.Data.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StructureMap;
using System;

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
              
                // DbContext
               // config.For<IMainContext>().Use<MongoDbContext>();
               
                // Services
                config.For<IAnswerService>().Use<AnswerService>();
                config.For<IChoiceService>().Use<ChoiceService>();
                config.For<IPollService>().Use<PollService>();
                config.For<IQuestionService>().Use<QuestionService>();
                config.For<IUserService>().Use<UserService>();
                config.For<IVisitorService>().Use<VisitorService>();
                config.For<IUnitOfWork>().Use<MainContext>();
                
            });


            container.Populate(services);

            return container.GetInstance<IServiceProvider>();
        }

    }
}
