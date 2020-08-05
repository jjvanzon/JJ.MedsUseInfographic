using System.Collections.Generic;

namespace JJ.MedsUseInfographic.Presentation.ViewModels
{
    public class DayViewModel
    {
        public int DayNumber { get; set; }
        public IList<PillViewModel> Pills { get; set; }
    }
}