using SkiaSharp;

namespace PhotoProcessor.Editing.Masking
{
    public abstract class Mask
    {
        public abstract SKBitmap CreateMaskBitmap();
    }
}
