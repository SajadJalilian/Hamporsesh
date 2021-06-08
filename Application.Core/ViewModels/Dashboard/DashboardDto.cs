using Hamporsesh.Application.Core.ViewModels.Polls;
using System.Collections.Generic;

namespace Hamporsesh.Application.Core.ViewModels.Dashboard
{
    public class DashboardDto
    {
        public long TotalPolls { get; set; }
        public long TotalQuestions { get; set; }
        public long TotalAnswers { get; set; }
        public long TotalResponses { get; set; }
        public IEnumerable<PollOutputDto> Polls { get; set; }
        public IEnumerable<string> Days { get; set; }
        public IEnumerable<long> Responses { get; set; }

    }

}
