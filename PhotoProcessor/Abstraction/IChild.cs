using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoProcessor.Abstraction
{
    public interface IChild<T>
    {
        public T Owner { get; }
    }
}
