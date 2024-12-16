using SkiaSharp;

namespace PhotoProcessor.Abstraction
{
    public interface IRenderable
    { 
        public void Render(SKCanvas canvas);
    }
}
