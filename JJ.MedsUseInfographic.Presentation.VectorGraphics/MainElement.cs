using JJ.Framework.VectorGraphics.Models.Elements;
using JJ.MedsUseInfographic.Presentation.ViewModels;

namespace JJ.MedsUseInfographic.Presentation.VectorGraphics
{
    public class MainElement : ElementBase
    {
        public MainElement(Element parent) : base(parent) { }

        private MainViewModel _viewModel;

        public MainViewModel ViewModel
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

            // Child View Models
            foreach (DayViewModel dayViewModel in _viewModel.Days)
            {
                new DayElement(this) { ViewModel = dayViewModel };
            }

            // Position
            Position.Width = _viewModel.MinutesADayForWidth;
            Position.Height = _viewModel.DayCountForHeight;
            Position.X = 0;
            Position.Y = _viewModel.FirstDayNumberFormTopY;

            // TODO: Some margin.
            //Position.SetMarginInPixels();
        }
    }
}