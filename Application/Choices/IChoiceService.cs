using System;
using System.Collections.Generic;

namespace Hamporsesh.Application.Choices
{
    public interface IChoiceService
    {
        /// <summary>
        /// لیستی از جواب‌ها میگیرد ذخیره میکند
        /// </summary>
        void Create(ChoiceInputViewModel input);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IEnumerable<PollOutPutViewModel> GetPollsByParticipatedUserId(long id);

        /// <summary>
        /// 
        /// </summary>
        IEnumerable<ChoiceOutputViewModel> GetUserPollChoices(long userId, long pollid);

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
        ChoicesLas30DaysViewModel GetLast30DaysResponses();

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