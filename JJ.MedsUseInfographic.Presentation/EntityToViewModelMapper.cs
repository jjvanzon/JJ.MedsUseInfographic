using System;
using System.Collections.Generic;
using System.Linq;
using JJ.Framework.Exceptions.InvalidValues;
using JJ.Framework.Mathematics;
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
                Size = GetPillSizeEnum(entity.DosageInMilligrams),
                Style = GetPillStyleEnum(entity.DosageInMilligrams),
                TimeOfDay = entity.DateTime.TimeOfDay
            };

            return viewModel;
        }

        private PillSizeEnum GetPillSizeEnum(decimal dosageInMilligrams)
        {
            switch (dosageInMilligrams)
            {
                case 6.25m: return PillSizeEnum.Size1;
                case 12.5m: return PillSizeEnum.Size2;
                case 50m: return PillSizeEnum.Size3;
                default: throw new InvalidValueException(dosageInMilligrams);
            }
        }

        private PillStyleEnum GetPillStyleEnum(decimal dosageInMilligrams)
        {
            switch (dosageInMilligrams)
            {
                case 6.25m: 
                case 12.5m:
                    return Randomizer.GetRandomItem(new [] { PillStyleEnum.Style1, PillStyleEnum.Style2 });

                case 50m: 
                    return PillStyleEnum.Style3;

                default: 
                    throw new InvalidValueException(dosageInMilligrams);
            }
        }
    }
}