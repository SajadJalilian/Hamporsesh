using Hamporsesh.Application.Core.ViewModels.Polls;
using System.Collections.Generic;

namespace Hamporsesh.Application.Polls
{
    public interface IPollService
    {
        void Create(PollInputDto input);

        void Update(PollInputDto input);

        PollOutputDto GetById(long id);

        long GetUserPollCount(long userId);

        IEnumerable<PollOutputDto> GetListByUserId(long userId);

        PollInputDto GetToUpdate(long id);

        IEnumerable<PollOutputDto> GetAllUser(long userId);

        void Delete(long id);

        IEnumerable<PollOutputDto> GetAllUserPolls(long userId);

        PollIndexDto GetUserPollIndex(long userId);

        PollDetailsDto GetPollDetails(long id);

        PollResultsDto GetPollResult(long id);

        PollParticipateDto GetParticipate(PollParticipateDto input, string ip);

        IEnumerable<PollOutputDto> GetPollsByParticipatedUserId(long userId);

    }
}