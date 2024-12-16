using PhotoProcessor.Abstraction;
using PhotoProcessor.Editing.Collections;
using SkiaSharp;

namespace PhotoProcessor.Editing
{
    public class Project : IRenderable
    {
        public int PixelWidth { get; }
        public int PixelHeight { get; }
        public SKColorType ColorType { get; }

        public ProjectLayerCollection Layers { get; }

        public Project(int pixelWidth, int pixelHeight, SKColorType colorType)
        {
            PixelWidth = pixelWidth;
            PixelHeight = pixelHeight;
            ColorType = colorType;

            Layers = new ProjectLayerCollection(this);
        }

        public void Render(SKCanvas canvas)
        {
            foreach (var layer in Layers)
            {
                layer.Render(canvas);
            }
        }
    }
}
