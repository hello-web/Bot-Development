using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kaldi
{
    namespace KaldiToolkit
    {
        public class ReplyMessage : Message
        {
            private static readonly string ReplyCommand = "REPLY";

            private static readonly string GrantedParameter = "GRANTED";
            private static readonly string ErrorParameter = "ERROR";
            private static readonly string DeclinedParameter = "DECLINED";

            public bool IsGranted
            {
                get
                {
                    return Parameters[0] == GrantedParameter;
                }
            }

            public bool IsError
            {
                get
                {
                    return Parameters[0] == ErrorParameter;
                }
            }

            public string ErrorMessage
            {
                get
                {
                    return Parameters[1];
                }
            }

            public bool IsDeclined
            {
                get
                {
                    return Parameters[0] == DeclinedParameter;
                }
            }

            public string DeclineReason
            {
                get
                {
                    return Parameters[1];
                }
            }

            public ReplyMessage(string command, params string[] parameters)
                : base(command, parameters)
            {
                if (Command != ReplyCommand)
                {
                    throw new ArgumentException("The given message string does not contain a REPLY command", "messageString");
                }

                if (Parameters.Count == 0)
                {
                    throw new ArgumentException("The given REPLY message string does not contain any parameters", "messageString");
                }

                if (Parameters[0] == GrantedParameter && Parameters.Count > 1)
                {
                    throw new ArgumentException("The given GRANTED REPLY message string has more than one parameter", "messageString");
                }

                if ((Parameters[0] == ErrorParameter || Parameters[0] == DeclinedParameter) && Parameters.Count > 2)
                {
                    throw new ArgumentException("The given REPLY message string did not have exactly two parameters", "messageString");
                }
            }

            public ReplyMessage(Message message)
                : this(message.Command, message.Parameters.ToArray<string>())
            {
            }
        }
    }
}
