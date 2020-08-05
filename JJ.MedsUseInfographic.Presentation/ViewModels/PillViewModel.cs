using System;
using JJ.MedsUseInfographic.Presentation.Enums;

namespace JJ.MedsUseInfographic.Presentation.ViewModels
{
    public class PillViewModel
    { 
        public TimeSpan TimeOfDay { get; set; }
        public PillSizeEnum Size { get; set; }
        public PillStyleEnum Style { get; set; }
    }
}