using Hamporsesh.Application.Core.ViewModels.Choices;
using Hamporsesh.Application.Core.ViewModels.Polls;
using System;
using System.Collections.Generic;

namespace Hamporsesh.Application.Choices
{
    public interface IChoiceService
    {

        void Create(PollParticipateDto input);

        ChoicesLas30DaysDto GetLast30DaysResponses();

        IEnumerable<DateTime> EachDay(DateTime from, DateTime thru);

        long GetAnswerTotalResponses(long id);

        long GetPollTotalResponses(long pollId);

        IEnumerable<ChoiceOutputDto> UserChoices(long userId);

    }
}