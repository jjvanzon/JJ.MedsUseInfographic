using System;
using System.Collections.Generic;
using System.Linq;
using JJ.Framework.Exceptions.InvalidValues;
using JJ.Framework.Collections;
using JJ.Framework.Mathematics;
using JJ.MedsUseInfographic.Data;
using JJ.MedsUseInfographic.Presentation.Enums;
using JJ.MedsUseInfographic.Presentation.ViewModels;

// ReSharper disable SuggestVarOrType_Elsewhere

namespace JJ.MedsUseInfographic.Presentation
{
    internal class EntityToViewModelMapper : IEntityToViewModelMapper
    {
        private const int MINUTES_A_DAY = 60 * 24;

        public MainViewModel ConvertToMainViewModel(IList<PillMoment> entities)
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));

            var groupsByDay = entities.GroupBy(x => x.DateTime.Date).ToArray();

            var viewModel = new MainViewModel
            {
                Days = groupsByDay.Select(ConvertToDayViewModel).ToList(),
                TotalMilligramsADay = groupsByDay.Select(GetTotalMilligrams).ToList(),
                MinutesADayForWidth = MINUTES_A_DAY,
                TracePaths = new List<TracePathViewModel>()
            };

            viewModel.DayCountForHeight = viewModel.Days.Count;
            viewModel.FirstDayNumberFormTopY = viewModel.Days.Select(x => x.DayNumber).FirstOrDefault();

            return viewModel;
        }

        private decimal GetTotalMilligrams(IEnumerable<PillMoment> pillMomentsOfADay)
            => pillMomentsOfADay.Sum(y => y.Milligrams);

        private DayViewModel ConvertToDayViewModel(IEnumerable<PillMoment> pillMomentsOfADay)
        {
            pillMomentsOfADay = pillMomentsOfADay.ToArray();

            var viewModel = new DayViewModel
            {
                DayNumber = pillMomentsOfADay.Select(x => x.DateTime.DayOfYear).SingleWithClearException(),
                Pills = pillMomentsOfADay.Select(ConvertToPillViewModel).ToList()
            };

            return viewModel;
        }

        private PillViewModel ConvertToPillViewModel(PillMoment entity)
        {
            var viewModel = new PillViewModel
            {
                PillSize = GetPillSizeEnum(entity.Milligrams),
                Style = GetPillStyleEnum(entity.Milligrams),
                TimeOfDay = entity.DateTime.TimeOfDay
            };

            return viewModel;
        }

        private PillSizeEnum GetPillSizeEnum(decimal milligrams)
        {
            switch (milligrams)
            {
                case 6.25m: return PillSizeEnum.PillSize1;
                case 12.5m: return PillSizeEnum.PillSize2;
                case 50m: return PillSizeEnum.PillSize3;
                default: throw new InvalidValueException(milligrams);
            }
        }

        private PillStyleEnum GetPillStyleEnum(decimal milligrams)
        {
            switch (milligrams)
            {
                case 6.25m:
                case 12.5m:
                    return Randomizer.GetRandomItem(new[] { PillStyleEnum.Style1, PillStyleEnum.Style2 });

                case 50m:
                    return PillStyleEnum.Style3;

                default:
                    throw new InvalidValueException(milligrams);
            }
        }
    }
}