using System.Collections;
using PhotoProcessor.Abstraction;
using PhotoProcessor.Editing.Collections;
using SkiaSharp;

namespace PhotoProcessor.Editing.Objects
{
    public class DrawingObjectGroup : DrawingObject, IList<DrawingObject>, IRenderable
    {
        private readonly NotNullCollection<DrawingObject> _storage = new();

        public DrawingObject this[int index] { get => ((IList<DrawingObject>)_storage)[index]; set => ((IList<DrawingObject>)_storage)[index] = value; }

        public int Count => ((ICollection<DrawingObject>)_storage).Count;

        public bool IsReadOnly => ((ICollection<DrawingObject>)_storage).IsReadOnly;

        public void Add(DrawingObject item) => ((ICollection<DrawingObject>)_storage).Add(item);
        public void Clear() => ((ICollection<DrawingObject>)_storage).Clear();
        public bool Contains(DrawingObject item) => ((ICollection<DrawingObject>)_storage).Contains(item);
        public void CopyTo(DrawingObject[] array, int arrayIndex) => ((ICollection<DrawingObject>)_storage).CopyTo(array, arrayIndex);
        public IEnumerator<DrawingObject> GetEnumerator() => ((IEnumerable<DrawingObject>)_storage).GetEnumerator();
        public int IndexOf(DrawingObject item) => ((IList<DrawingObject>)_storage).IndexOf(item);
        public void Insert(int index, DrawingObject item) => ((IList<DrawingObject>)_storage).Insert(index, item);
        public bool Remove(DrawingObject item) => ((ICollection<DrawingObject>)_storage).Remove(item);
        public void RemoveAt(int index) => ((IList<DrawingObject>)_storage).RemoveAt(index);
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)_storage).GetEnumerator();

        public override void Render(SKCanvas canvas)
        {
            foreach (var obj in _storage)
            {
                obj.Render(canvas);
            }
        }
    }
}
