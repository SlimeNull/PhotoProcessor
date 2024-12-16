using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoProcessor.Abstraction;
using PhotoProcessor.Editing.Collections;
using PhotoProcessor.Editing.Objects;
using PhotoProcessor.Extensions;
using SkiaSharp;

namespace PhotoProcessor.Editing.Layers
{
    public class NormalLayer : Layer
    {
        public SKBitmap Bitmap { get; }
        public DrawingObjectCollection DrawingObjects { get; }

        public NormalLayer(Project project) : base(project)
        {
            Bitmap = new SKBitmap(project.PixelWidth, project.PixelHeight, project.ColorType, SKAlphaType.Unpremul);
            Bitmap.Erase(new SKColor(0, 0, 0, 0));

            DrawingObjects = new DrawingObjectCollection();
        }

        public override void Render(SKCanvas canvas)
        {
            using SKBitmap buffer = new SKBitmap(Owner.PixelWidth, Owner.PixelHeight, Owner.ColorType, SKAlphaType.Unpremul);
            using SKCanvas localCanvas = new SKCanvas(buffer);

            localCanvas.DrawBitmap(Bitmap, default(SKPoint));

            foreach (var drawingObject in DrawingObjects)
            {
                drawingObject.Render(localCanvas);
            }

            if (Mask is not null)
            {
                using var maskBitmap = Mask.CreateMaskBitmap();
                buffer.ApplyMask(maskBitmap);
            }

            canvas.DrawBitmap(buffer, default(SKPoint));
        }
    }
}
