using System.Collections.Generic;

namespace Hamporsesh.Application.Answers
{
    public interface IAnswerService
    {
        /// <summary>
        /// 
        /// </summary>
        void Create(AnswerInputViewModel input);

        /// <summary>
        /// 
        /// </summary>
        void Update(AnswerInputViewModel input);

        /// <summary>
        /// 
        /// </summary>
        AnswerOutputViewModel GetById(long id);

        /// <summary>
        /// 
        /// </summary>
        IEnumerable<AnswerOutputViewModel> GetListByQuestionId(long QuestionId);

        /// <summary>
        /// 
        /// </summary>
        AnswerInputViewModel GetToUpdate(long id);

        /// <summary>
        /// 
        /// </summary>
        IEnumerable<AnswerOutputViewModel> GetAll();

        /// <summary>
        /// 
        /// </summary>
        void Delete(long id);

        /// <summary>
        /// 
        /// </summary>
        IEnumerable<AnswerOutputViewModel> GetAllPollAnswers(long pollId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        long GetUserTotalAnswers(long userId);
    }
}