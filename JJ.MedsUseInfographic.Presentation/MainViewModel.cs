using System.Collections.Generic;

namespace JJ.MedsUseInfographic.Presentation
{
    public class MainViewModel
    {
        public IList<DayViewModel> Days { get; set; }
        public IList<PathViewModel> Paths { get; set; }
        private IList<decimal> TotalsADay { get; set; }
    }
}