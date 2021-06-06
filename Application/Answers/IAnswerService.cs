using Hamporsesh.Application.Core.ViewModels.Answers;
using System.Collections.Generic;

namespace Hamporsesh.Application.Answers
{
    public interface IAnswerService
    {
        void Create(AnswerInputDto input);

        void Update(AnswerInputDto input);

        AnswerOutputDto GetById(long id);

        IEnumerable<AnswerOutputDto> GetListByQuestionId(long QuestionId);

        AnswerInputDto GetToUpdate(long id);

        IEnumerable<AnswerOutputDto> GetAll();

        void Delete(long id);

        long GetAnswerQuestionCount(long id);

        IEnumerable<AnswerOutputDto> GetAnswerByQuestionId(long id);
    }
}