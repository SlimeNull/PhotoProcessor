using SkiaSharp;

namespace PhotoProcessor.Editing.Masking
{
    public class BitmapMask : Mask
    {
        public BitmapMask(SKBitmap bitmap)
        {
            Bitmap = bitmap;
        }

        public SKBitmap Bitmap { get; }

        public override SKBitmap CreateMaskBitmap()
        {
            return Bitmap.Copy();
        }
    }
}
