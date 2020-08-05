using System.Collections.Generic;
using JJ.MedsUseInfographic.Data;
using JJ.MedsUseInfographic.Data.InMemory;

namespace JJ.MedsUseInfographic.Presentation
{
    public class MainPresenter : IMainPresenter
    {
        private readonly IPillMomentRepository _pillMomentRepository;
        private readonly IEntityToViewModelMapper _entityToViewModelConverter;

        public MainPresenter()
        {
            _pillMomentRepository = new PillMomentRepository();
            _entityToViewModelConverter = new EntityToViewModelMapper();
        }

        public MainViewModel Show()
        {
            IList<PillMoment> entities = _pillMomentRepository.GetAll();
            MainViewModel viewModel = _entityToViewModelConverter.ConvertToMainViewModel(entities);
            return viewModel;
        }
    }
}