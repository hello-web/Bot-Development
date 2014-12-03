using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kaldi
{
    namespace KaldiToolkit
    {
        public class RequestMessage : Message
        {
            public RequestMessage(params string[] parameters)
                : base("REQUEST", parameters)
            {
            }
        }
    }
}