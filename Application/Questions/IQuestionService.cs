using System.Collections.Generic;
using Hamporsesh.Application.Core.ViewModels.Questions;

namespace Hamporsesh.Application.Questions
{
    public interface IQuestionService
    {
        /// <summary>
        /// 
        /// </summary>
        void Create(QuestionInputViewModel input);

        /// <summary>
        /// 
        /// </summary>
        void Update(QuestionInputViewModel input);

        /// <summary>
        /// 
        /// </summary>
        QuestionOutputViewModel GetbyId(long id);

        /// <summary>
        /// 
        /// </summary>
        IEnumerable<QuestionOutputViewModel> GetListByPollId(long pollId);

        /// <summary>
        /// 
        /// </summary>
        QuestionInputViewModel GetToUpdate(long id);

        /// <summary>
        /// 
        /// </summary>
        IEnumerable<QuestionOutputViewModel> GetAll();

        /// <summary>
        /// 
        /// </summary>
        void Delete(long id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        long GetUserTotalQuestions(long userId);
    }
}