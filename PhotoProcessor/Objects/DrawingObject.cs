using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoProcessor.Abstraction;
using SkiaSharp;

namespace PhotoProcessor.Objects
{
    public abstract class DrawingObject : IRenderable
    {
        public abstract void Render(SKCanvas canvas);
    }
}
