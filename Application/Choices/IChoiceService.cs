using Hamporsesh.Application.Core.ViewModels.Choices;
using Hamporsesh.Application.Core.ViewModels.Polls;
using System;
using System.Collections.Generic;

namespace Hamporsesh.Application.Choices
{
    public interface IChoiceService
    {
        /// <summary>
        /// لیستی از جواب‌ها میگیرد ذخیره میکند
        /// </summary>
        void Create(PollParticipateDto input);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IEnumerable<PollOutputDto> GetPollsByParticipatedUserId(long id);

        /// <summary>
        /// 
        /// </summary>
        IEnumerable<ChoiceOutputDto> GetUserPollChoices(long userId, long pollid);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pollId"></param>
        /// <returns></returns>
        long GetPollTotalResponses(long pollId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        long GetAllPollsTotalResponses(long userId);

        /// <summary>
        /// 
        /// </summary>
        ChoicesLas30DaysDto GetLast30DaysResponses();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="thru"></param>
        IEnumerable<DateTime> EachDay(DateTime from, DateTime thru);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        long GetAnswerTotalResponses(long id);
    }
}