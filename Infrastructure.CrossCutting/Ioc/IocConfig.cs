using Hamporsesh.Application.Answers;
using Hamporsesh.Application.Choices;
using Hamporsesh.Application.Polls;
using Hamporsesh.Application.Questions;
using Hamporsesh.Application.Users;
using Hamporsesh.Application.Visitors;
using Hamporsesh.Infrastructure.Data.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.CrossCutting.Ioc
{
    public static class IocConfig
    {
        public static void AddIocConfig(this IServiceCollection services, IConfiguration configuration)
        {
            #region DotNetDI

            /*
             * The below three methods define the lifetime of the services,
             * 
             * AddTransient:
             *      Transient lifetime services are created each time they are requested.
             *      This lifetime works best for lightweight, stateless services.
             *      
             * AddScoped:
             *      Scoped lifetime services are created once per request.
             *      
             * AddSingleton:
             *      Singleton lifetime services are created the first time they are requested
             *      (or when ConfigureServices is run if you specify an instance there)
             *      and then every subsequent request will use the same instance.
             */

            services.AddSingleton<IConfiguration>(provider => { return configuration; });
            services.AddDbContext<MainContext>(ServiceLifetime.Scoped);

            services.AddScoped<IUnitOfWork, MainContext>();
            services.AddScoped<IAnswerService, AnswerService>();
            services.AddScoped<IChoiceService, ChoiceService>();
            services.AddScoped<IPollService, PollService>();
            services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IVisitorService, VisitorService>();

            #endregion

            #region StructureMap

            //var container = new Container();
            //container.Configure(config =>
            //{
            //    // Services
            //    config.For<IAnswerService>().Use<AnswerService>();
            //    config.For<IChoiceService>().Use<ChoiceService>();
            //    config.For<IPollService>().Use<PollService>();
            //    config.For<IQuestionService>().Use<QuestionService>();
            //    config.For<IUserService>().Use<UserService>();
            //    config.For<IVisitorService>().Use<VisitorService>();
            //    config.For<IUnitOfWork>().Use<MainContext>();
            //});
            //container.Populate(services);
            //return container.GetInstance<IServiceProvider>();

            #endregion
        }

    }
}
