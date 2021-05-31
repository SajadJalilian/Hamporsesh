using System;
using System.Collections.Generic;

namespace Hamporsesh.Application.Core.ViewModels.Choices
{
    public class ChoicesLas30DaysViewModel
    {
        public IEnumerable<DateTime> Days { get; set; }
        public IEnumerable<long> ResponseCounts { get; set; }
    }

}
