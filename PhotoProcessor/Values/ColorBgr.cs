using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoProcessor.Values
{
    public record struct ColorBgr(byte Blue, byte Green, byte Red);
    public record struct ColorBgra(byte Blue, byte Green, byte Red, byte Alpha);

    public record struct ColorGray(byte Brightness);
}
