﻿using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using JsonLT.Parser;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using static JsonLT.Parser.JsonLTParser;

namespace jsonLTParser.interpreter {
    public class JsonLTInterpreter {
        private Dictionary<Type, Func<IParseTree, object>> interpreters = new Dictionary<Type, Func<IParseTree, object>>();
        private Dictionary<string, Func<object, object, object>> binaryOperatorInterpreters = new Dictionary<string, Func<object, object, object>>();
        private JToken jsonObj;
        private JToken jsonCurrent;
        private Dictionary<string, JToken> jsonAliases;

        public JsonLTInterpreter() {
            interpreters.Add(typeof(JsonContext        ), InterpretJsonContext         );
            interpreters.Add(typeof(ElementsContext    ), InterpretElementsContext     );
            interpreters.Add(typeof(ElementContext     ), InterpretElementContext      );
            interpreters.Add(typeof(ObjContext         ), InterpretObjContext          );
            interpreters.Add(typeof(MemberContext      ), InterpretMemberContext       );
            //interpreters.Add(typeof(RelativePathContext), InterpretRelativePathContext );
            interpreters.Add(typeof(ArrayContext       ), InterpretArrayContext        );
            //interpreters.Add(typeof(AbsolutePathContext), InterpretAbsolutePathContext );
            //interpreters.Add(typeof(DeeperContext      ), InterpretDeeperContext       );
            interpreters.Add(typeof(SubpathContext     ), InterpretSubpathContext      );
            interpreters.Add(typeof(PathContext        ), InterpretPathContext         );
            interpreters.Add(typeof(TerminalNodeImpl   ), InterpretTerminalNodeImpl    );
            interpreters.Add(typeof(ExpresionContext   ), InterpretExpresionContext    );
            binaryOperatorInterpreters.Add("*", EvalMul);
            binaryOperatorInterpreters.Add("/", EvalDiv);
            binaryOperatorInterpreters.Add("+", EvalPlus);
            binaryOperatorInterpreters.Add("-", EvalMinus);
            binaryOperatorInterpreters.Add("and", EvalAnd);
            binaryOperatorInterpreters.Add("or", EvalOr);
            binaryOperatorInterpreters.Add("<", EvalLt);
            binaryOperatorInterpreters.Add(">", EvalGt);
            binaryOperatorInterpreters.Add("=", EvalEq);
        }

        private object EvalEq(object left, object right) {
            return Comparer.Default.Compare(left, right) == 0;
        }

        private object EvalGt(object left, object right) {
            return Comparer.Default.Compare(left, right) > 0;
        }

        private object EvalLt(object left, object right) {
            return Comparer.Default.Compare(left, right) < 0;
        }

        private object EvalOr(object left, object right) {
            if (left is bool l && right is bool r)
                return l || r;
            throw new InterpreterException("Only booleans can be compared with and/or operator");
        }

        private object EvalAnd(object left, object right) {
            if (left is bool l && right is bool r)
                return l && r;
            throw new InterpreterException("Only booleans can be compared with and/or operator");
        }

        private object EvalMinus(object left, object right) {
            if (left is double || right is double) {
                return (double)left - (double)right;
            }
            return (long)left - (long)right;
        }

        private object EvalPlus(object left, object right) {
            if (left is double || right is double) {
                return (double)left + (double)right;
            }
            return (long)left + (long)right;
        }

        private object EvalDiv(object left, object right) {
            return (double)left / (double)right;
        }

        private object EvalMul(object left, object right) {
            if (left is double || right is double) {
                return (double)left * (double)right;
            }
            return (long)left * (long)right;
        }

        public string Run(string json, string jsonLT) {
            jsonObj = (JToken)JsonConvert.DeserializeObject(json);
            jsonAliases = new Dictionary<string, JToken>();
            IParseTree tree = PrepareTree(jsonLT);
            object result = Interpret(tree);
            return JsonConvert.SerializeObject(result);
        }

        private IParseTree PrepareTree(string jsonLT) {
            ICharStream stream = CharStreams.fromstring(jsonLT);
            ITokenSource lexer = new JsonLTLexer(stream);
            ITokenStream tokens = new CommonTokenStream(lexer);
            JsonLTParser parser = new JsonLTParser(tokens);
            parser.BuildParseTree = true;
            IParseTree tree = parser.json();
            return tree;
        }

        private Object Interpret(IParseTree tree) {
            Func<IParseTree, object> func;
            if (interpreters.TryGetValue(tree.GetType(), out func))
                return func(tree);
            throw new InterpreterException("Unknown node type: " + tree.GetType().Name);
        }
        private object InterpretBinaryOperator(string oper, object left, object right) {
            if (binaryOperatorInterpreters.TryGetValue(oper, out Func<object, object, object> func)) {
                if (left is JValue leftJV)
                    left = leftJV.Value;
                if (right is JValue rightJV)
                    right = rightJV.Value;
                return func(left, right);
            }
            throw new InterpreterException("Unknown binary operator: " + oper);
        }

        private object InterpretMemberContext(IParseTree node) {
            ValidateChildCount(node, 3);
            ValidateToken(node.GetChild(1), ":");
            IParseTree keyNode = node.GetChild(0);
            ValidateType<TerminalNodeImpl>(keyNode);
            object keyObj = Interpret(keyNode);
            return new KeyValuePair<string, object>(keyObj.ToString(), Interpret(node.GetChild(2)));
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

        private object InterpretElementsContext(IParseTree node) {
            if (node.ChildCount == 1)
                return Interpret(node.GetChild(0));
            List<String> list = new List<string>();
            for (int i = 0; i < node.ChildCount; i++) {
                object r = Interpret(node.GetChild(i));
                if (r != null) {
                    list.Add(r.ToString());
                }
            }
            return string.Join(" ", list); 
        }

        private object InterpretElementContext(IParseTree node) {
            ValidateChildCount(node, 1);
            return Interpret(node.GetChild(0));
        }

        private object InterpretJsonContext(IParseTree node) {
            ValidateChildCount(node, 1);
            IParseTree child = node.GetChild(0);
            ValidateType<ElementsContext>(child);
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
                string text = term.GetText();
                return text.Substring(1, text.Length-2);
            }
            if (term.Symbol.Type == JsonLTParser.NUMBER) {
                string text = term.GetText();
                if (text.Contains(".") || text.Contains("E") || text.Contains("e"))
                    return Convert.ToDouble(text);
                else
                    return Convert.ToInt64(text);
            }
            if (term.Symbol.Type == JsonLTParser.TRUE) {
                return true;
            }
            if (term.Symbol.Type == JsonLTParser.FALSE) {
                return false;
            }
            if (term.Symbol.Type == JsonLTParser.NULL) {
                return null;
            }
            return null;
        }

        private object InterpretPathContext(IParseTree node) {
            ValidateChildCount(node, 2);
            IParseTree aliasChild = node.GetChild(0);
            ValidateType<TerminalNodeImpl>(aliasChild);
            int aliasType = ((TerminalNodeImpl)aliasChild).Symbol.Type;
            if (aliasType == ROOT) {
                JToken jsonCurrentBackup = jsonCurrent;
                jsonCurrent = jsonObj;
                object result = Interpret(node.GetChild(1));
                jsonCurrent = jsonCurrentBackup;
                return result;
            } else if (aliasType == CURRENT) {
                JToken jsonCurrentBackup = jsonCurrent;
                object result = Interpret(node.GetChild(1));
                jsonCurrent = jsonCurrentBackup;
                return result;
            } else {
                throw new InterpreterException("Unknown path alias type: " + aliasChild.GetText());
            }
        }

        private object InterpretSubpathContext(IParseTree node) {
            ValidateChildCountMin(node, 2);
            if ("[".Equals(node.GetChild(0).GetText())) {
                int index = Convert.ToInt32(node.GetChild(1).GetText());
                jsonCurrent = jsonCurrent[index];
            } else {
                if (jsonCurrent is JArray array) {
                    List<object> result = new List<object>();
                    for (int i = 0; i < array.Count; i++) {
                        jsonCurrent = array[i];
                        object subpathObj = InterpretSubpathContext(node);
                        if (subpathObj != null) {
                            result.Add(subpathObj);
                        }
                    }
                    return result;
                } else {
                    jsonCurrent = jsonCurrent[node.GetChild(1).GetText()];
                }
            }
            
            ConditionContext condition = null;
            if (node.GetChild(2) is ConditionContext)
                condition = (ConditionContext)node.GetChild(2);
            else if (node.GetChild(3) is ConditionContext)
                condition = (ConditionContext)node.GetChild(3);
            
            SubpathContext subPath = node.GetChild(node.ChildCount - 1) as SubpathContext;

            if (condition != null && jsonCurrent is JArray array2) {
                List<object> result = new List<object>();
                foreach (JToken elem in array2) {
                    jsonCurrent = elem;
                    if (condition == null || CheckCondition(condition)) {
                        if (subPath != null) {
                            result.Add(Interpret(subPath));
                        } else {
                            result.Add(elem);
                        }
                    }
                }
                return result;
            } else {
                if (condition == null || CheckCondition(condition)) {
                    if (subPath != null) {
                        return Interpret(subPath);
                    } else {
                        return jsonCurrent;
                    }
                } else {
                    return null;
                }
            }
        }

        private bool CheckCondition(ConditionContext condition) {
            ValidateChildCount(condition, 3);
            object result = Interpret(condition.GetChild(1));
            if (result is bool boolResult) {
                return boolResult;
            }
            throw new InterpreterException("Condition should be evaluated to boolean, not " + result.GetType() + " : " + condition.GetText());
        }

        private object InterpretExpresionContext(IParseTree node) {
            if (node.ChildCount == 1)
                return Interpret(node.GetChild(0));
            if (node.ChildCount == 3 && "(".Equals(node.GetChild(0).GetText()))
                return Interpret(node.GetChild(1));
            ValidateChildCount(node, 3);
            string oper = node.GetChild(1).GetText();
            object left = Interpret(node.GetChild(0));
            object right = Interpret(node.GetChild(2));
            try {
                return InterpretBinaryOperator(oper, left, right);
            }
            catch (Exception ex) {
                throw new InterpreterException("Error in : " + node.GetText(), ex);
            }
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
