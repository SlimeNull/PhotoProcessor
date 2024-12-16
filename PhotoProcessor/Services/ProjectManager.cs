using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoProcessor.Editing;

namespace PhotoProcessor.Services
{
    public class ProjectManager
    {
        public Project CreateDefault()
        {
            var project = new Project(512, 512, SkiaSharp.SKColorType.Bgra8888);
            project.Layers.AddNewNormalLayer();

            return project;
        }
    }
}
