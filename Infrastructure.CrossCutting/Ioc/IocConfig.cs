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

            services.AddSingleton<IConfiguration>(provider => { return configuration; });
            services.AddDbContext<MainContext>(ServiceLifetime.Scoped);

            services.AddTransient<IUnitOfWork, MainContext>();
            services.AddTransient<IAnswerService, AnswerService>();
            services.AddTransient<IChoiceService, ChoiceService>();
            services.AddTransient<IPollService, PollService>();
            services.AddTransient<IQuestionService, QuestionService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IVisitorService, VisitorService>();

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
        }

    }
}
