using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using PhotoProcessor.Editing.Layers;

namespace PhotoProcessor.Editing.Tools
{
    public abstract class Tool
    {
        public abstract Geometry Icon { get; }

        public virtual void OnSelected() { }
        public virtual void OnUnselected() { }

        public virtual void OnCursorDown(Layer layer, float x, float y) { }
        public virtual void OnCursorDrag(Layer layer, float x, float y) { }
        public virtual void OnCursorUp(Layer layer, float x, float y) { }
    }
}
