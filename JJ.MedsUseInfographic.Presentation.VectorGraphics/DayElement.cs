using JJ.Framework.VectorGraphics.Models.Elements;
using JJ.MedsUseInfographic.Presentation.ViewModels;

namespace JJ.MedsUseInfographic.Presentation.VectorGraphics
{
    internal class DayElement : ElementBase
    {
        public DayElement(Element parent) : base(parent) { }

        private DayViewModel _viewModel;
        public DayViewModel ViewModel
        {
            get => _viewModel;
            set
            {
                _viewModel = value;
                ApplyViewModel();
            }
        }

        private void ApplyViewModel()
        {
            Children.Clear();

            if (_viewModel == null) return;

            // Child Elements
            foreach (PillViewModel pillViewModel in _viewModel.Pills)
            {
                new PillElement(this) { ViewModel = pillViewModel };
            }

            // Position
            Position.Y = _viewModel.DayNumber;
        }
    }
}