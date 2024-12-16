using SkiaSharp;

namespace PhotoProcessor.Editing.Objects.Shapes
{
    public class PolygonObject : ShapeObject
    {
        public List<SKPoint> Points { get; } = new();


        public override void Render(SKCanvas canvas)
        {
            canvas.DrawPoints(SKPointMode.Polygon, Points.ToArray(), Paint);
        }
    }
}
