using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Janus
{
    [Serializable]
    public class InitializationException : Exception
    {
        public InitializationException()
            : base()
        {
        }

        public InitializationException(string message)
            : base(message)
        {
        }

        public InitializationException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
