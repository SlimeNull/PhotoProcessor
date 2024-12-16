using System.Collections.ObjectModel;
using PhotoProcessor.Abstraction;

namespace PhotoProcessor.Editing.Collections
{
    public abstract class ChildrenCollection<TOwner, TChild> : NotNullCollection<TChild>
        where TChild : IChild<TOwner>
    {
        public TOwner Owner { get; }

        public ChildrenCollection(TOwner owner)
        {
            Owner = owner;
        }

        protected override void InsertItem(int index, TChild item)
        {
            if (!Equals(Owner, item.Owner))
            {
                throw new ArgumentException("Owner not match", nameof(item));
            }

            base.InsertItem(index, item);
        }

        protected override void SetItem(int index, TChild item)
        {
            if (!Equals(Owner, item.Owner))
            {
                throw new ArgumentException("Owner not match", nameof(item));
            }

            base.SetItem(index, item);
        }
    }
}
