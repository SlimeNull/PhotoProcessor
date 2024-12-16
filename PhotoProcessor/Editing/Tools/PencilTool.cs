using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using PhotoProcessor.Editing.Layers;
using PhotoProcessor.Helpers;
using PhotoProcessor.Utilities;
using SkiaSharp;

namespace PhotoProcessor.Editing.Tools
{
    public class PencilTool : Tool
    {
        private SKPoint? _lastPoint;
        private Cache<SKBitmap, SKCanvas> _canvasCache;

        public override Geometry Icon => IconResourceUtilities.Pen;

        public PencilTool()
        {
            _canvasCache = new Cache<SKBitmap, SKCanvas>(bitmap => new SKCanvas(bitmap));
        }

        private void Paint(NormalLayer normalLayer, float x, float y)
        {
            using var paint = new SKPaint();
            paint.Color = new SKColor(0, 0, 0, 255);

            var canvas = _canvasCache.GetValue(normalLayer.Bitmap);
            var currentPoint = new SKPoint(x, y);

            if (_lastPoint is null)
            {
                canvas.DrawPoint(currentPoint, paint);
            }
            else
            {
                canvas.DrawLine(_lastPoint.Value, currentPoint, paint);
            }

            _lastPoint = currentPoint;
        }

        public override void OnCursorDown(Layer layer, float x, float y)
        {
            if (layer is not NormalLayer normalLayer)
            {
                return;
            }

            Paint(normalLayer, x, y);
        }

        public override void OnCursorDrag(Layer layer, float x, float y)
        {
            if (layer is not NormalLayer normalLayer)
            {
                return;
            }

            Paint(normalLayer, x, y);
        }

        public override void OnCursorUp(Layer layer, float x, float y)
        {
            _lastPoint = null;
        }
    }
}
