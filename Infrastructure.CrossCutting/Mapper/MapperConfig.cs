using Hamporsesh.Application.Core.ViewModels.Answers;
using Infrastructure.CrossCutting.Mapper.Profiles;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Infrastructure.CrossCutting.Mapper
{
    public static class MapperConfig
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            

            services.AddAutoMapper(typeof(AccountProfile));
            services.AddAutoMapper(typeof(AnswerOutputDto));
            services.AddAutoMapper(typeof(AnswerProfile));
            services.AddAutoMapper(typeof(ChoiceProfile));
            services.AddAutoMapper(typeof(DashboardProfile));
            services.AddAutoMapper(typeof(PollProfile));
            services.AddAutoMapper(typeof(QuestionProfile));
            services.AddAutoMapper(typeof(UserProfile));
            services.AddAutoMapper(typeof(VisitorProfile));

        }
    }
}
