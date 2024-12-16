using System.Windows.Media;

namespace PhotoProcessor.Utilities
{
    internal static class IconResourceUtilities
    {
        private static Geometry GetRequiredIconResource(string key)
        {
            return App.Current.FindResource(key) as Geometry ?? throw new InvalidOperationException();
        }

        public static Geometry Pen => GetRequiredIconResource("IconPen");
        public static Geometry Pencil => GetRequiredIconResource("IconPencil");
    }
}
