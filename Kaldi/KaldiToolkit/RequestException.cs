using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Kaldi
{
    namespace KaldiToolkit
    {
        [Serializable]
        public class RequestException : Exception
        {
            public RequestException()
                : base()
            {
            }

            public RequestException(string message)
                : base(message)
            {
            }

            public RequestException(string message, Exception inner)
                : base(message, inner)
            {
            }
        }
    }
}