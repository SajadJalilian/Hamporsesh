using Hamporsesh.Application.Core.ViewModels.Questions;
using System.Collections.Generic;

namespace Hamporsesh.Application.Questions
{
    public interface IQuestionService
    {
        void Create(QuestionInputDto input);

        void Update(QuestionInputDto input);

        QuestionOutputDto GetbyId(long id);

        IEnumerable<QuestionOutputDto> GetListByPollId(long pollId);

        QuestionInputDto GetToUpdate(long id);

        IEnumerable<QuestionOutputDto> GetAll();

        void Delete(long id);

        long GetUserTotalQuestions(long userId);

        long GetpollQuestionCount(long id);
    }
}