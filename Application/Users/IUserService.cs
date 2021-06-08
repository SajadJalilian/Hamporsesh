using Hamporsesh.Application.Core.ViewModels.Users;
using System.Collections.Generic;

namespace Hamporsesh.Application.Users
{
    public interface IUserService
    {
        /// <summary>
        /// 
        /// </summary>
        void Create(UserInputDto input);

        /// <summary>
        /// 
        /// </summary>
        void Update(UserInputDto input);

        /// <summary>
        /// 
        /// </summary>
        UserOutputDto GetById(long id);

        /// <summary>
        /// 
        /// </summary>
        UserInputDto GetToUpdate(long id);

        /// <summary>
        /// 
        /// </summary>
        IEnumerable<UserOutputDto> GetAll();

        /// <summary>
        /// 
        /// </summary>
        void Delete(long id);



        /// <summary>
        /// 
        /// </summary>
        UserOutputDto GetByUserName(string currentUserName);
    }
}