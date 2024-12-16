using PhotoProcessor.Abstraction;
using PhotoProcessor.Editing.Masking;
using SkiaSharp;

namespace PhotoProcessor.Editing.Layers
{
    public abstract class Layer : IChild<Project>, IRenderable
    {
        public Project Owner { get; }

        public string Name { get; set; } = "Layer";
        public Mask? Mask { get; set; }

        public Layer(Project owner)
        {
            Owner = owner;
        }

        public abstract void Render(SKCanvas canvas);
    }
}