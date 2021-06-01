using Microsoft.Extensions.DependencyInjection;
using System;
using TaskoMask.Application.Mapper.Profiles;

namespace Infrastructure.CrossCutting.Mapper
{
    public static class MapperConfig
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(OrganizationMappingProfile));
            services.AddAutoMapper(typeof(ProjectMappingProfile));
            services.AddAutoMapper(typeof(UserProfile));
            services.AddAutoMapper(typeof(CardMappingProfile));

        }
    }
}
