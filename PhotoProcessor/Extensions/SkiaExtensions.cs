using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiaSharp;

namespace PhotoProcessor.Extensions
{
    internal static class SkiaExtensions
    {
        public static System.Windows.Media.PixelFormat ToWpfPixelFormat(this SKColorType colorType)
        {
            return colorType switch
            {
                SKColorType.Bgra8888 => System.Windows.Media.PixelFormats.Bgr32,
                SKColorType.Gray8 => System.Windows.Media.PixelFormats.Gray8,
                _ => throw new NotSupportedException(),
            };
        }

        public static unsafe void ApplyMask(this SKBitmap bitmap, SKBitmap mask)
        {
            
        }
    }
}
