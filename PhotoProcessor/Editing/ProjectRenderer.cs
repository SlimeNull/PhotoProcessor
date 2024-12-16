using SkiaSharp;

namespace PhotoProcessor.Editing
{
    public class ProjectRenderer
    {
        public Project Project { get; }

        public ProjectRenderer(Project project)
        {
            Project = project;
        }

        public SKBitmap Render()
        {
            var buffer = new SKBitmap(Project.PixelWidth, Project.PixelHeight, Project.ColorType, SKAlphaType.Unpremul);
            var canvas = new SKCanvas(buffer);

            Project.Render(canvas);

            return buffer;
        }
    }
}
