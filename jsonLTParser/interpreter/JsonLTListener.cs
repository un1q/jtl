using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using JsonLT.Parser;
using System.IO;

namespace jsonLTParser.interpreter {
    class JsonLTListener : IJsonLTListener {
        public void EnterArray([NotNull] JsonLTParser.ArrayContext context) {
            throw new System.NotImplementedException();
        }

        public void EnterBool([NotNull] JsonLTParser.BoolContext context) {
            throw new System.NotImplementedException();
        }

        public void EnterCondition([NotNull] JsonLTParser.ConditionContext context) {
            throw new System.NotImplementedException();
        }

        public void EnterElement([NotNull] JsonLTParser.ElementContext context) {
            throw new System.NotImplementedException();
        }

        public void EnterEveryRule(ParserRuleContext ctx) {
            throw new System.NotImplementedException();
        }

        public void EnterJson([NotNull] JsonLTParser.JsonContext context) {
            throw new System.NotImplementedException();
        }

        public void EnterMember([NotNull] JsonLTParser.MemberContext context) {
            throw new System.NotImplementedException();
        }

        public void EnterObj([NotNull] JsonLTParser.ObjContext context) {
            throw new System.NotImplementedException();
        }

        public void EnterPath([NotNull] JsonLTParser.PathContext context) {
            throw new System.NotImplementedException();
        }

        public void EnterSubpath([NotNull] JsonLTParser.SubpathContext context) {
            throw new System.NotImplementedException();
        }

        public void ExitArray([NotNull] JsonLTParser.ArrayContext context) {
            throw new System.NotImplementedException();
        }

        public void ExitBool([NotNull] JsonLTParser.BoolContext context) {
            throw new System.NotImplementedException();
        }

        public void ExitCondition([NotNull] JsonLTParser.ConditionContext context) {
            throw new System.NotImplementedException();
        }

        public void ExitElement([NotNull] JsonLTParser.ElementContext context) {
            throw new System.NotImplementedException();
        }

        public void ExitEveryRule(ParserRuleContext ctx) {
            throw new System.NotImplementedException();
        }

        public void ExitJson([NotNull] JsonLTParser.JsonContext context) {
            throw new System.NotImplementedException();
        }

        public void ExitMember([NotNull] JsonLTParser.MemberContext context) {
            throw new System.NotImplementedException();
        }

        public void ExitObj([NotNull] JsonLTParser.ObjContext context) {
            throw new System.NotImplementedException();
        }

        public void ExitPath([NotNull] JsonLTParser.PathContext context) {
            throw new System.NotImplementedException();
        }

        public void ExitSubpath([NotNull] JsonLTParser.SubpathContext context) {
            throw new System.NotImplementedException();
        }

        public void VisitErrorNode(IErrorNode node) {
            throw new System.NotImplementedException();
        }

        public void VisitTerminal(ITerminalNode node) {
            throw new System.NotImplementedException();
        }
    }
}
