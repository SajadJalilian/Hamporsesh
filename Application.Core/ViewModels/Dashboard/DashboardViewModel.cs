using System.Collections.Generic;
using Hamporsesh.Application.Core.ViewModels.Polls;

namespace Hamporsesh.Application.Core.ViewModels.Dashboard
{
    public class DashboardViewModel
    {
        public long TotalPolls { get; set; }
        public long TotalQuestions { get; set; }
        public long TotalAnswers { get; set; }
        public long TotalResponses { get; set; }
        public IEnumerable<PollOutputViewModelAdmin> Polls { get; set; }
        public IEnumerable<string> Days { get; set; }
        public IEnumerable<long> Responses { get; set; }

    }

}
