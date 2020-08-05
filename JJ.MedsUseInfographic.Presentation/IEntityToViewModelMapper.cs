using System.Collections.Generic;
using JJ.MedsUseInfographic.Data;

namespace JJ.MedsUseInfographic.Presentation
{
    internal interface IEntityToViewModelMapper
    {
        MainViewModel ConvertToMainViewModel(IList<PillMoment> entities);
    }
}