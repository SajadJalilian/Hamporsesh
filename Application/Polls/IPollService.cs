﻿using System.Collections.Generic;
using Hamporsesh.Application.Core.ViewModels.Choices;
using Hamporsesh.Application.Core.ViewModels.Polls;

namespace Hamporsesh.Application.Polls
{
    public interface IPollService
    {
        /// <summary>
        /// 
        /// </summary>
        void Create(PollInputDto input);

        /// <summary>
        /// 
        /// </summary>
        void Update(PollInputDto input);

        /// <summary>
        /// 
        /// </summary>
        PollOutputDto GetById(long id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        long GetUserPollCount(long userId);

        /// <summary>
        /// 
        /// </summary>
        IEnumerable<PollOutputDto> GetListByUserId(long userId);

        /// <summary>
        /// 
        /// </summary>
        PollInputDto GetToUpdate(long id);

        /// <summary>
        /// 
        /// </summary>
        IEnumerable<PollOutputDto> GetAll();

        /// <summary>
        /// 
        /// </summary>
        void Delete(long id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        IEnumerable<PollOutputDto> GetAllUserPolls(long id);



        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        PollDetailsDto GetPollDetails(long id);



        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        PollResultsDto GetPollResult(long id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        PollParticipateDto Participate(PollParticipateDto input, string ip);
    }
}