using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using PhotoProcessor.Resources;

namespace PhotoProcessor.MarkupExtensions
{
    public class LocalStringExtension : MarkupExtension
    {
        public string? Key { get; set; }

        public LocalStringExtension() { }
        public LocalStringExtension(string key)
        {
            Key = key;
        }

        public override object? ProvideValue(IServiceProvider serviceProvider)
        {
            if (string.IsNullOrWhiteSpace(Key))
            {
                return null;
            }

            var value = Strings.ResourceManager.GetObject(Key);
            if (value is not string stringValue)
            {
                return Key;
            }

            return stringValue;
        }
    }
}
