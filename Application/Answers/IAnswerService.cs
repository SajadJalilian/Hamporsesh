using Hamporsesh.Application.Core.ViewModels.Answers;
using System.Collections.Generic;

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
        AnswerOutputDto GetById(long id);

        /// <summary>
        /// 
        /// </summary>
        IEnumerable<AnswerOutputDto> GetListByQuestionId(long QuestionId);

        /// <summary>
        /// 
        /// </summary>
        AnswerInputDto GetToUpdate(long id);

        /// <summary>
        /// 
        /// </summary>
        IEnumerable<AnswerOutputDto> GetAll();

        /// <summary>
        /// 
        /// </summary>
        void Delete(long id);

        /// <summary>
        /// 
        /// </summary>
        IEnumerable<AnswerOutputDto> GetAllPollAnswers(long pollId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        long GetUserTotalAnswers(long userId);
    }
}