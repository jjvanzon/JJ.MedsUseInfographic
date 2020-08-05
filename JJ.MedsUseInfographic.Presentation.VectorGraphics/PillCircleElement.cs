using System;
using JJ.Framework.Exceptions.InvalidValues;
using JJ.Framework.VectorGraphics.Models.Elements;
using JJ.MedsUseInfographic.Presentation.Enums;
using JJ.MedsUseInfographic.Presentation.ViewModels;

// ReSharper disable SwitchStatementHandlesSomeKnownEnumValuesWithDefault

namespace JJ.MedsUseInfographic.Presentation.VectorGraphics
{
    internal class PillCircleElement : ElementBase
    {
        private readonly Ellipse _ellipse;

        public PillCircleElement(Element parent) : base(parent)
        {
            _ellipse = new Ellipse(this);
        }

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
                    _ellipse.Style.BackStyle = StyleHelper.BackStyle_OutlinedCircle;
                    _ellipse.Style.LineStyle = StyleHelper.LineStyle_OutlinedCircle;
                    break;

                case PillStyleEnum.Style2:
                    _ellipse.Style.BackStyle = StyleHelper.BackStyle_SolidCircle;
                    _ellipse.Style.LineStyle = StyleHelper.LineStyle_SolidCircle;
                    break;

                case PillStyleEnum.Style3:
                    _ellipse.Style.BackStyle = StyleHelper.BackStyle_OutlinedCircle_FilledWithAlternateColor;
                    _ellipse.Style.LineStyle = StyleHelper.LineStyle_OutlinedCircle_FilledWithAlternateColor;
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
                    _ellipse.Position.Width = StyleHelper.CircleWidth1;
                    _ellipse.Position.Height = StyleHelper.CircleWidth1;
                    break;

                case PillSizeEnum.PillSize2:
                    _ellipse.Position.Width = StyleHelper.CircleWidth2;
                    _ellipse.Position.Height = StyleHelper.CircleWidth2;
                    break; 

                case PillSizeEnum.PillSize3:
                    _ellipse.Position.Width = StyleHelper.CircleWidth3;
                    _ellipse.Position.Height = StyleHelper.CircleWidth3;
                    break; 

                default:
                    throw new ValueNotSupportedException(_viewModel.Style);
            }

            // Position
            const float totalMinutesADay = 24 * 60;
            _ellipse.Position.CenterX = (float)_viewModel.TimeOfDay.TotalMinutes / totalMinutesADay;
            _ellipse.Position.CenterY = 0;
        }
    }
}