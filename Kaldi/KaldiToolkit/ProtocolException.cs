﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Kaldi
{
    namespace KaldiToolkit
    {
        [Serializable]
        public class ProtocolException : Exception
        {
            public ProtocolException()
                : base()
            {
            }

            public ProtocolException(string message)
                : base(message)
            {
            }

            public ProtocolException(string message, Exception inner)
                : base(message, inner)
            {
            }
        }
    }
}