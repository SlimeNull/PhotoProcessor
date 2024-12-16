using SkiaSharp;

namespace PhotoProcessor.Objects.Shapes
{
    public abstract class ShapeObject : DrawingObject
    {
        public SKPaint? Paint { get; }
    }
}
