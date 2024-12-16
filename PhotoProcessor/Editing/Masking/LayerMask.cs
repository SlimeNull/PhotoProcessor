using PhotoProcessor.Editing.Layers;
using SkiaSharp;

namespace PhotoProcessor.Editing.Masking
{
    public class LayerMask : Mask
    {
        public Layer Layer { get; }

        public LayerMask(Layer layer)
        {
            Layer = layer;
        }

        public override SKBitmap CreateMaskBitmap()
        {
            var maskBitmap = new SKBitmap(Layer.Owner.PixelWidth, Layer.Owner.PixelHeight, Layer.Owner.ColorType, SKAlphaType.Unpremul);
            var maskCanvas = new SKCanvas(maskBitmap);

            Layer.Render(maskCanvas);

            return maskBitmap;
        }
    }
}
