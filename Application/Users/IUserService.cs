using System.Collections.Generic;

namespace Hamporsesh.Application.Users
{
    public interface IUserService
    {
        /// <summary>
        /// 
        /// </summary>
        void Create(UserInputViewModel input);

        /// <summary>
        /// 
        /// </summary>
        void Update(UserInputViewModel input);

        /// <summary>
        /// 
        /// </summary>
        UserOutputViewModel GetById(long id);

        /// <summary>
        /// 
        /// </summary>
        UserInputViewModel GetToUpdate(long id);

        /// <summary>
        /// 
        /// </summary>
        IEnumerable<UserOutputViewModel> GetAll();

        /// <summary>
        /// 
        /// </summary>
        void Delete(long id);
    }
}