using AutoMapper;
using Hamporsesh.Application.Core.ViewModels.Users;
using Hamporsesh.Domain.Entities;

namespace Infrastructure.CrossCutting.Mapper.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            #region ViewModel To Command

            //CreateMap<RegisterViewModel, CreateUserCommand>()
            //  .ConstructUsing(c => new CreateUserCommand(c.DisplayName, c.Email,c.Password));

            #endregion

            #region Dto To Command

            //CreateMap<UserInput, CreateUserCommand>()
            //  .ConstructUsing(c => new CreateUserCommand(c.DisplayName,c.Email));

            //CreateMap<UserInput, UpdateUserCommand>()
            //  .ConstructUsing(c => new UpdateUserCommand(c.Id, c.DisplayName,c.Email));


            #endregion

            #region Command To Domain Model

            //CreateMap<CreateUserCommand, User>()
            // .ConstructUsing(c => new User(c.DisplayName.Trim(),c.Email,c.Email));

            #endregion

            #region Domain Model To Dto

            CreateMap<User, UserOutputDto>();
            CreateMap<User, UserInputDto>();


            #endregion

            #region Dto To Dto

            CreateMap<UserOutputDto, UserInputDto>();


            #endregion

        }
    }
}
