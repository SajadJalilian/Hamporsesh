﻿using System.Collections.Generic;
using Hamporsesh.Application.Core.ViewModels.Questions;

namespace Hamporsesh.Application.Core.ViewModels.Polls

{
    public class PollQuestionsAnswersViewModelAdmin
    {
        public PollOutputViewModelAdmin Poll { get; set; }
        public IEnumerable<QuestionDetailViewModel> Questions { get; set; }
    }
}
