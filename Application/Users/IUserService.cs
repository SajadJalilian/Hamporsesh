using Hamporsesh.Application.Core.ViewModels.Users;
using System.Collections.Generic;

namespace Hamporsesh.Application.Users
{
    public interface IUserService
    {

        void Create(UserInputDto input);

        void Update(UserInputDto input);

        UserOutputDto GetById(long id);

        UserInputDto GetToUpdate(long id);

        IEnumerable<UserOutputDto> GetAll();

        void Delete(long id);

        UserOutputDto GetByUserName(string currentUserName);
    }
}