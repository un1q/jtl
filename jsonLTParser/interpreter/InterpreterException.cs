using Antlr4.Runtime.Tree;
using System;
using System.Runtime.Serialization;

namespace jsonLTParser.interpreter {
    [Serializable]
    internal class InterpreterException : Exception {
        public InterpreterException(IParseTree node, string message) : base(message + "\r\nError in " + node.GetText()) {
        }

        public InterpreterException(IParseTree node, Exception innerException) : base(node.GetText(), innerException) {
        }

        protected InterpreterException(SerializationInfo info, StreamingContext context) : base(info, context) {
        }
    }
}