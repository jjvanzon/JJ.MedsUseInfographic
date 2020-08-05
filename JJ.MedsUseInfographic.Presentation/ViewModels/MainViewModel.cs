using System.Collections.Generic;

namespace JJ.MedsUseInfographic.Presentation.ViewModels
{
    public class MainViewModel
    {
        public IList<DayViewModel> Days { get; set; }
        public IList<PathViewModel> Paths { get; set; }
        public IList<decimal> TotalMilligramsADay { get; set; }
    }
}