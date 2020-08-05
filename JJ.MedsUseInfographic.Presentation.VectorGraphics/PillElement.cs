using JJ.Framework.Exceptions.InvalidValues;
using JJ.Framework.VectorGraphics.Models.Elements;
using JJ.MedsUseInfographic.Presentation.Enums;
using JJ.MedsUseInfographic.Presentation.ViewModels;

// ReSharper disable SwitchStatementHandlesSomeKnownEnumValuesWithDefault

namespace JJ.MedsUseInfographic.Presentation.VectorGraphics
{
    internal class PillElement : Ellipse
    {
        public PillElement(Element parent) : base(parent) { }

        private PillViewModel _viewModel;

        public PillViewModel ViewModel
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
            // Style
            switch (_viewModel.Style)
            {
                case PillStyleEnum.Style1:
                    Style.BackStyle = StyleHelper.BackStyle_OutlinedCircle;
                    Style.LineStyle = StyleHelper.LineStyle_OutlinedCircle;
                    break;

                case PillStyleEnum.Style2:
                    Style.BackStyle = StyleHelper.BackStyle_SolidCircle;
                    Style.LineStyle = StyleHelper.LineStyle_SolidCircle;
                    break;

                case PillStyleEnum.Style3:
                    Style.BackStyle = StyleHelper.BackStyle_OutlinedCircle_FilledWithAlternateColor;
                    Style.LineStyle = StyleHelper.LineStyle_OutlinedCircle_FilledWithAlternateColor;
                    break;

                default:
                    throw new ValueNotSupportedException(_viewModel.Style);
            }

            // Size

            // TODO: I feel uneasy that the size of the pill is quite abstract here.
            // I would like to see better that it corresponds to the milligrams of the pill.

            switch (_viewModel.PillSize)
            {
                case PillSizeEnum.PillSize1:
                    Position.Width = StyleHelper.CircleWidth1;
                    Position.Height = StyleHelper.CircleWidth1;
                    break;

                case PillSizeEnum.PillSize2:
                    Position.Width = StyleHelper.CircleWidth2;
                    Position.Height = StyleHelper.CircleWidth2;
                    break;

                case PillSizeEnum.PillSize3:
                    Position.Width = StyleHelper.CircleWidth3;
                    Position.Height = StyleHelper.CircleWidth3;
                    break;

                default:
                    throw new ValueNotSupportedException(_viewModel.Style);
            }

            // Position
            const float totalMinutesADay = 24 * 60;
            Position.CenterX = (float)_viewModel.TimeOfDay.TotalMinutes / totalMinutesADay;
            Position.CenterY = 0;
        }
    }
}