using System;

namespace JJ.MedsUseInfographic.Presentation
{
    public class PillViewModel
    { 
        public TimeSpan TimeOfDay { get; set; }
        public PillSizeEnum Size { get; set; }
        public PillStyleEnum Style { get; set; }
    }
}