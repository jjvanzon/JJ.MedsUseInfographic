using JJ.Framework.VectorGraphics.Models.Styling;

namespace JJ.MedsUseInfographic.Presentation.VectorGraphics
{
    internal static class StyleHelper
    {
        public static BackStyle BackStyle_OutlinedCircle { get; } = new BackStyle();
        public static LineStyle LineStyle_OutlinedCircle { get; } = new LineStyle();
        public static BackStyle BackStyle_SolidCircle { get; } = new BackStyle();
        public static LineStyle LineStyle_SolidCircle { get; } = new LineStyle();
        public static BackStyle BackStyle_OutlinedCircle_FilledWithAlternateColor { get; } = new BackStyle();
        public static LineStyle LineStyle_OutlinedCircle_FilledWithAlternateColor { get; } = new LineStyle();
        public static float CircleWidth1 { get; }
        public static float CircleWidth2 { get; }
        public static float CircleWidth3 { get; }
    }
}