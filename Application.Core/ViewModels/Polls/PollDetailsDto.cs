using Hamporsesh.Application.Core.ViewModels.Questions;
using Hamporsesh.Application.Core.ViewModels.Users;
using System.Collections.Generic;

namespace Hamporsesh.Application.Core.ViewModels.Polls
{
    public class PollDetailsDto
    {
        public PollOutputDto Poll { get; set; }
        public IEnumerable<QuestionDetailDto> Questions { get; set; }
        public UserOutputDto User { get; set; }
    }
}