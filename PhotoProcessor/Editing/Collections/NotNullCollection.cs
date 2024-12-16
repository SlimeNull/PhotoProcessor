using System.Collections.ObjectModel;

namespace PhotoProcessor.Editing.Collections
{
    public class NotNullCollection<T> : ObservableCollection<T>
    {
        protected override void InsertItem(int index, T item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            base.InsertItem(index, item);
        }

        protected override void SetItem(int index, T item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            base.SetItem(index, item);
        }
    }
}
