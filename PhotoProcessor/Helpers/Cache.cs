using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoProcessor.Helpers
{
    internal class Cache<TInput, TOutput>
    {
        private TInput? _lastInput;
        private TOutput? _lastOutput;

        private readonly Func<TInput, TOutput> _factory;

        public Cache(Func<TInput, TOutput> factory)
        {
            ArgumentNullException.ThrowIfNull(factory);
            this._factory = factory;
        }

        public TOutput GetValue(TInput input)
        {
            if (_lastInput is not null &&
                _lastOutput is not null &&
                Equals(input, _lastInput))
            {
                return _lastOutput;
            }

            if (_lastOutput is IDisposable disposableOutput)
            {
                disposableOutput.Dispose();
            }

            _lastInput = input;
            _lastOutput = _factory.Invoke(input);
            return _lastOutput;
        }
    }
}
