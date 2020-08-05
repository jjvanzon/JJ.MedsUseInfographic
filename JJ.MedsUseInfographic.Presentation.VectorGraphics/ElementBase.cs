using JJ.Framework.VectorGraphics.Models.Elements;

namespace JJ.MedsUseInfographic.Presentation.VectorGraphics
{
    internal class ElementBase : Element
    {
        public ElementBase(Element parent) : base(parent) => Position = new RectanglePosition(this);

        public override ElementPosition Position { get; }
    }
}