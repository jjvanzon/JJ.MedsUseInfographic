using System;
using System.Collections.Generic;
using System.Linq;
using JJ.Framework.Exceptions.InvalidValues;
using JJ.Framework.Mathematics;
using JJ.MedsUseInfographic.Data;
using JJ.MedsUseInfographic.Presentation.Enums;
using JJ.MedsUseInfographic.Presentation.ViewModels;

// ReSharper disable SuggestVarOrType_Elsewhere

namespace JJ.MedsUseInfographic.Presentation
{
    internal class EntityToViewModelMapper : IEntityToViewModelMapper
    {
        public MainViewModel ConvertToMainViewModel(IList<PillMoment> entities)
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));

            var groupsByDay = entities.GroupBy(x => x.DateTime.Date).ToArray();

            var viewModel = new MainViewModel
            {
                Days = groupsByDay.Select(ConvertToDayViewModel).ToList(),
                TotalMilligramsADay = groupsByDay.Select(GetTotalMilligrams).ToList(),
                Paths = new List<PathViewModel>()
            };

            return viewModel;
        }

        private decimal GetTotalMilligrams(IEnumerable<PillMoment> pillMomentsOfADay)
            => pillMomentsOfADay.Sum(y => y.Milligrams);

        private DayViewModel ConvertToDayViewModel(IEnumerable<PillMoment> pillMomentsOfADay)
        {
            var viewModel = new DayViewModel
            {
                Pills = pillMomentsOfADay.Select(ConvertToPillViewModel).ToList()
            };

            return viewModel;
        }

        private PillViewModel ConvertToPillViewModel(PillMoment entity)
        {
            var viewModel = new PillViewModel
            {
                Size = GetPillSizeEnum(entity.Milligrams),
                Style = GetPillStyleEnum(entity.Milligrams),
                TimeOfDay = entity.DateTime.TimeOfDay
            };

            return viewModel;
        }

        private PillSizeEnum GetPillSizeEnum(decimal milligrams)
        {
            switch (milligrams)
            {
                case 6.25m: return PillSizeEnum.Size1;
                case 12.5m: return PillSizeEnum.Size2;
                case 50m: return PillSizeEnum.Size3;
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