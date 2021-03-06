﻿using System.Collections.Generic;

namespace JJ.MedsUseInfographic.Presentation.ViewModels
{
    public class MainViewModel
    {
        public IList<DayViewModel> Days { get; set; }
        public IList<TracePathViewModel> TracePaths { get; set; }
        public IList<decimal> TotalMilligramsADay { get; set; }

        public int MinutesADayForWidth { get; set; }
        public int DayCountForHeight { get; set; }
        public int FirstDayNumberFormTopY { get; set; }
    }
}