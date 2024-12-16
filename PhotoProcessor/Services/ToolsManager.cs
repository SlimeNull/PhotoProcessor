using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoProcessor.Editing.Tools;

namespace PhotoProcessor.Services
{
    public class ToolsManager
    {
        public IReadOnlyList<Tool> Tools { get; } = new List<Tool>()
        {
            new PencilTool(),
        };
    }
}
