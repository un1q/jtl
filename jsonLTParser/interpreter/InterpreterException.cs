using System;
using System.Runtime.Serialization;

namespace jsonLTParser.interpreter {
    [Serializable]
    internal class InterpreterException : Exception {
        public InterpreterException() {
        }

        public InterpreterException(string message) : base(message) {
        }

        public InterpreterException(string message, Exception innerException) : base(message, innerException) {
        }

        protected InterpreterException(SerializationInfo info, StreamingContext context) : base(info, context) {
        }
    }
}