using System;
using System.Runtime.Serialization;

namespace VerificationTaskCSharp 
{
    [Serializable]
    class WrongPathToFileExeption : ApplicationException
    {
        public WrongPathToFileExeption() { }

        public WrongPathToFileExeption(string message) : base(message) { }

        public WrongPathToFileExeption(string message, Exception inner) : base(message, inner) { }

        protected WrongPathToFileExeption(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
