using System;
using System.Collections.Generic;
using System.Linq;
using JJ.MedsUseInfographic.Data;

namespace JJ.MedsUseInfographic.Presentation
{
    internal class EntityToViewModelMapper : IEntityToViewModelMapper
    {
        public MainViewModel ConvertToMainViewModel(IList<PillMoment> entities)
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));

            var groupsByDay = entities.GroupBy(x => x.DateTime.Date);

            var viewModel = new MainViewModel
            {
                Days = groupsByDay.Select(ConvertToDayViewModel).ToList(),
                Paths = new List<PathViewModel>()
            };

            return viewModel;
        }

        private DayViewModel ConvertToDayViewModel(IEnumerable<PillMoment> pillMomentsOfADay)
        {
            if (pillMomentsOfADay == null) throw new ArgumentNullException(nameof(pillMomentsOfADay));

            var viewModel = new DayViewModel
            { 
                Pills = pillMomentsOfADay.Select(ConvertToPillViewModel).ToList()
            };

            return viewModel;
        }

        private PillViewModel ConvertToPillViewModel(PillMoment arg)
        {
            var viewModel = new PillViewModel
                { };
            throw new NotImplementedException();
        }

    }
}