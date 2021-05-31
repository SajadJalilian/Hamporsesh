using System.Collections.Generic;

namespace Hamporsesh.Application.Polls
{
    public interface IPollService
    {
        /// <summary>
        /// 
        /// </summary>
        void Create(PollInputViewModelAdmin input);

        /// <summary>
        /// 
        /// </summary>
        void Update(PollInputViewModelAdmin input);

        /// <summary>
        /// 
        /// </summary>
        PollOutPutViewModel GetById(long id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        long GetUserPollCount(long userId);

        /// <summary>
        /// 
        /// </summary>
        IEnumerable<PollOutPutViewModel> GetListByUserId(long userId);

        /// <summary>
        /// 
        /// </summary>
        PollInputViewModelAdmin GetToUpdate(long id);

        /// <summary>
        /// 
        /// </summary>
        IEnumerable<PollOutPutViewModel> GetAll();

        /// <summary>
        /// 
        /// </summary>
        void Delete(long id);

        /// <summary>
        /// 
        /// </summary>
        IEnumerable<PollOutputViewModelAdmin> GetAllAdmin();

        /// <summary>
        /// 
        /// </summary>
        PollOutputViewModelAdmin GetByIdAdmin(long id);

        /// <summary>
        /// 
        /// </summary>
        IEnumerable<PollOutputViewModelAdmin> GetListByUserIdAdmin(long userId);
    }
}