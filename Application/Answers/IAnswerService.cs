using System.Collections.Generic;
using Hamporsesh.Application.Core.ViewModels.Answers;

namespace Hamporsesh.Application.Answers
{
    public interface IAnswerService
    {
        /// <summary>
        /// 
        /// </summary>
        void Create(AnswerInputDto input);

        /// <summary>
        /// 
        /// </summary>
        void Update(AnswerInputDto input);

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
        AnswerInputDto GetToUpdate(long id);

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