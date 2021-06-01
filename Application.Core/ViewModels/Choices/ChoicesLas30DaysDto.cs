using System;
using System.Collections.Generic;

namespace Hamporsesh.Application.Core.ViewModels.Choices
{
    public class ChoicesLas30DaysDto
    {
        public IEnumerable<DateTime> Days { get; set; }
        public IEnumerable<long> ResponseCounts { get; set; }
    }

}
