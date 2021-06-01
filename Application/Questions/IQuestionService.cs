using System.Collections.Generic;
using Hamporsesh.Application.Core.ViewModels.Questions;

namespace Hamporsesh.Application.Questions
{
    public interface IQuestionService
    {
        /// <summary>
        /// 
        /// </summary>
        void Create(QuestionInputDto input);

        /// <summary>
        /// 
        /// </summary>
        void Update(QuestionInputDto input);

        /// <summary>
        /// 
        /// </summary>
        QuestionOutputDto GetbyId(long id);

        /// <summary>
        /// 
        /// </summary>
        IEnumerable<QuestionOutputDto> GetListByPollId(long pollId);

        /// <summary>
        /// 
        /// </summary>
        QuestionInputDto GetToUpdate(long id);

        /// <summary>
        /// 
        /// </summary>
        IEnumerable<QuestionOutputDto> GetAll();

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