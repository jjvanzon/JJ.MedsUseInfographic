using System.Collections.Generic;
using JJ.MedsUseInfographic.Data;
using JJ.MedsUseInfographic.Presentation.ViewModels;

namespace JJ.MedsUseInfographic.Presentation
{
    internal interface IEntityToViewModelMapper
    {
        MainViewModel ConvertToMainViewModel(IList<PillMoment> entities);
    }
}