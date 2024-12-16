using System.Collections;
using PhotoProcessor.Editing.Collections;
using PhotoProcessor.Extensions;
using PhotoProcessor.Objects;
using SkiaSharp;

namespace PhotoProcessor.Editing
{
    public class LayerGroup : Layer, IList<Layer>
    {
        private readonly ProjectLayerCollection _layers;

        public Layer this[int index] { get => ((IList<Layer>)_layers)[index]; set => ((IList<Layer>)_layers)[index] = value; }

        public int Count => ((ICollection<Layer>)_layers).Count;

        public bool IsReadOnly => ((ICollection<Layer>)_layers).IsReadOnly;

        public LayerGroup(Project project) : base(project)
        {
            _layers = new ProjectLayerCollection(project);
        }

        public void Add(Layer item) => ((ICollection<Layer>)_layers).Add(item);
        public void Clear() => ((ICollection<Layer>)_layers).Clear();
        public bool Contains(Layer item) => ((ICollection<Layer>)_layers).Contains(item);
        public void CopyTo(Layer[] array, int arrayIndex) => ((ICollection<Layer>)_layers).CopyTo(array, arrayIndex);
        public IEnumerator<Layer> GetEnumerator() => ((IEnumerable<Layer>)_layers).GetEnumerator();
        public int IndexOf(Layer item) => ((IList<Layer>)_layers).IndexOf(item);
        public void Insert(int index, Layer item) => ((IList<Layer>)_layers).Insert(index, item);
        public bool Remove(Layer item) => ((ICollection<Layer>)_layers).Remove(item);
        public void RemoveAt(int index) => ((IList<Layer>)_layers).RemoveAt(index);
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)_layers).GetEnumerator();

        public override void Render(SKCanvas canvas)
        {
            using SKBitmap buffer = new SKBitmap(Owner.PixelWidth, Owner.PixelHeight, Owner.ColorType, SKAlphaType.Unpremul);
            using SKCanvas localCanvas = new SKCanvas(buffer);

            foreach (var layer in _layers)
            {
                layer.Render(localCanvas);
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
