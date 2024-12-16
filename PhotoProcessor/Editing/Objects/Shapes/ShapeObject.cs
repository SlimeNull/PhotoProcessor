using PhotoProcessor.Editing.Objects;
using SkiaSharp;

namespace PhotoProcessor.Editing.Objects.Shapes
{
    public abstract class ShapeObject : DrawingObject
    {
        public SKPaint? Paint { get; }
    }
}
