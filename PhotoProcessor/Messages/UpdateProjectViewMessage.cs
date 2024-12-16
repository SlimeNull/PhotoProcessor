using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoProcessor.Messages
{
    public class UpdateProjectViewMessage
    {
        private UpdateProjectViewMessage() { }

        public static UpdateProjectViewMessage Instance { get; } = new();
    }
}
