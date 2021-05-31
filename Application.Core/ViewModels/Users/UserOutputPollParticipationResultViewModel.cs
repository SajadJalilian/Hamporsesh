﻿using System.Collections.Generic;
using Hamporsesh.Application.Core.ViewModels.Choices;

namespace Hamporsesh.Application.Core.ViewModels.Users
{
    public class UserOutputPollParticipationResultViewModel
    {
        public PollOutPutViewModel Poll { get; set; }
        public UserInputViewModel User { get; set; }
        public IEnumerable<ChoiceOutputViewModel> Choices { get; set; }
    }
}