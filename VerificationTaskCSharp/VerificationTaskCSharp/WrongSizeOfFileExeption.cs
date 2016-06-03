using System;
using System.Runtime.Serialization;

namespace VerificationTaskCSharp
{
    class WrongSizeOfFileExeption : ApplicationException
    {
        public WrongSizeOfFileExeption() { }

        public WrongSizeOfFileExeption(string message) : base(message) { }

        public WrongSizeOfFileExeption(string message, Exception inner) : base(message, inner) { }

        protected WrongSizeOfFileExeption(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
