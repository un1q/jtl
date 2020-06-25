using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using JsonLT.Parser;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using static JsonLT.Parser.JsonLTParser;

namespace jsonLTParser.interpreter {
    public class JsonLTInterpreter {
        Dictionary<Type, Func<IParseTree, object>> interpreters = new Dictionary<Type, Func<IParseTree, object>>();

        public JsonLTInterpreter() {
            interpreters.Add(typeof(JsonContext        ), InterpretJsonContext         );
            interpreters.Add(typeof(ElementContext     ), InterpretElementContext      );
            interpreters.Add(typeof(ObjContext         ), InterpretObjContext          );
            interpreters.Add(typeof(MemberContext      ), InterpretMemberContext       );
            //interpreters.Add(typeof(RelativePathContext), InterpretRelativePathContext );
            interpreters.Add(typeof(ArrayContext       ), InterpretArrayContext        );
            //interpreters.Add(typeof(AbsolutePathContext), InterpretAbsolutePathContext );
            //interpreters.Add(typeof(DeeperContext      ), InterpretDeeperContext       );
            //interpreters.Add(typeof(PathContext        ), InterpretPathContext         );
            interpreters.Add(typeof(TerminalNodeImpl   ), InterpretTerminalNodeImpl    );
        }

        public string run(string json, string jsonLT) {
            IParseTree tree = prepareTree(jsonLT);
            object result = Interpret(tree);
            return JsonConvert.SerializeObject(result, new JsonTerminalConverter());
        }

        private IParseTree prepareTree(string jsonLT) {
            ICharStream stream = CharStreams.fromstring(jsonLT);
            ITokenSource lexer = new JsonLTLexer(stream);
            ITokenStream tokens = new CommonTokenStream(lexer);
            JsonLTParser parser = new JsonLTParser(tokens);
            parser.BuildParseTree = true;
            //StringWriter writer     = new StringWriter();
            //JsonLTListener listener = new JsonLTListener(writer);
            //JsonLTListener listener = new JsonLTListener();
            //parser.AddParseListener(listener);
            IParseTree tree = parser.json();
            //writer.Flush();
            return tree;
        }

        private Object Interpret(IParseTree tree) {
            Func<IParseTree, object> func;
            if (interpreters.TryGetValue(tree.GetType(), out func))
                return func(tree);
            throw new InterpreterException("Unknown node type: " + tree.GetType().Name);
        }

        private object InterpretMemberContext(IParseTree node) {
            ValidateChildCount(node, 3);
            ValidateToken(node.GetChild(1), ":");
            IParseTree keyNode = node.GetChild(0);
            ValidateType<TerminalNodeImpl>(keyNode);
            object keyObj = Interpret(keyNode);
            if (keyObj == null || keyObj.GetType() != typeof(JsonString))
                throw new InterpreterException("key element of member expected to be string. Key value: " + keyNode.GetText());
            return new KeyValuePair<string, object>(((JsonString)keyObj).Value, Interpret(node.GetChild(2)));
        }

        private object InterpretObjContext(IParseTree node) {
            Dictionary<string, object> result = new Dictionary<string, object>();
            ValidateChildCountMin(node, 2);
            ValidateToken(node.GetChild(0), "{");
            ValidateToken(node.GetChild(node.ChildCount - 1), "}");
            for (int i = 1; i < node.ChildCount - 1; i++) {
                object child = Interpret(node.GetChild(i));
                if (child == null)
                    continue;
                if (child is KeyValuePair<string, object>) {
                    KeyValuePair<string, object> member = (KeyValuePair<string, object>)child;
                    result.Add(member.Key, member.Value);
                } else {
                    throw new InterpreterException("Wrong node type, expected: member, actual: " + child.GetType().Name);
                }
            }
            return result;
        }

        private object InterpretElementContext(IParseTree node) {
            ValidateChildCount(node, 1);
            IParseTree child = node.GetChild(0);
            return Interpret(child);
        }

        private object InterpretJsonContext(IParseTree node) {
            ValidateChildCount(node, 1);
            IParseTree child = node.GetChild(0);
            ValidateType<ElementContext>(child);
            return Interpret(child);
        }

        private object InterpretArrayContext(IParseTree node) {
            List<object> result = new List<object>();
            ValidateChildCountMin(node, 2);
            ValidateToken(node.GetChild(0), "[");
            ValidateToken(node.GetChild(node.ChildCount - 1), "]");
            for (int i = 1; i < node.ChildCount - 1; i++) {
                object child = Interpret(node.GetChild(i));
                if (child == null)
                    continue;
                if (child != null) {
                    result.Add(child);
                } else {
                    throw new InterpreterException("Unexpected tokens in array: " + node.GetChild(i).GetText());
                }
            }
            return result;
        }

        private object InterpretTerminalNodeImpl(IParseTree node) {
            TerminalNodeImpl term = (TerminalNodeImpl)node;
            if (term.Symbol.Type == JsonLTParser.STRING) {
                return new JsonString(term.GetText());
            }
            if (term.Symbol.Type == JsonLTParser.NUMBER) {
                return new JsonNumber(term.GetText());
            }
            if (term.Symbol.Type == JsonLTParser.TRUE) {
                return new JsonBoolean(term.GetText(), true);
            }
            if (term.Symbol.Type == JsonLTParser.FALSE) {
                return new JsonBoolean(term.GetText(), false);
            }
            if (term.Symbol.Type == JsonLTParser.NULL) {
                return new JsonNull(term.GetText());
            }
            return null;
        }

        private void ValidateChildCount(IParseTree node, int count) {
            if (node.ChildCount != count)
                throw new InterpreterException(string.Format("Wrong number of children, expected: {0} actual: {1}", count, node.ChildCount));
        }

        private void ValidateChildCountMin(IParseTree node, int count) {
            if (node.ChildCount < count)
                throw new InterpreterException(string.Format("Wrong number of children, expected at least: {0} actual: {1}", count, node.ChildCount));
        }

        private void ValidateType<T>(IParseTree node) {
            if (!node.GetType().Equals(typeof(T)))
                throw new InterpreterException(string.Format("Wrong node type, expected: {0} actual: {1}", typeof(T).Name, node.GetType().Name));
        }

        private void ValidateToken(IParseTree node, string token) {
            ValidateType<TerminalNodeImpl>(node);
            if (token != node.GetText())
                throw new InterpreterException(string.Format("Wrong node text, expected: {0} actual: {1}", token, node.GetText()));
        }
    }
}
