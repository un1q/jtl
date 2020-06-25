// Generated from c:\Users\u005Cun1q\projekty\jsonLT\jsonLTParser\parser\JsonLT.g4 by ANTLR 4.8
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.misc.*;
import org.antlr.v4.runtime.tree.*;
import java.util.List;
import java.util.Iterator;
import java.util.ArrayList;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class JsonLTParser extends Parser {
	static { RuntimeMetaData.checkVersion("4.8", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, T__7=8, T__8=9, 
		T__9=10, T__10=11, T__11=12, T__12=13, T__13=14, STRING=15, NUMBER=16, 
		WS=17, ROOT=18, CURRENT=19, TAG=20, NODENAME=21, OPERATOR=22;
	public static final int
		RULE_json = 0, RULE_obj = 1, RULE_member = 2, RULE_array = 3, RULE_element = 4, 
		RULE_path = 5, RULE_subpath = 6, RULE_condition = 7, RULE_bool = 8;
	private static String[] makeRuleNames() {
		return new String[] {
			"json", "obj", "member", "array", "element", "path", "subpath", "condition", 
			"bool"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, "'{'", "','", "'}'", "':'", "'['", "']'", "'true'", "'false'", 
			"'null'", "'.'", "'[''", "'']'", "'[?('", "')]'", null, null, null, "'$'", 
			"'@'"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, null, null, null, null, null, null, null, null, null, null, null, 
			null, null, null, "STRING", "NUMBER", "WS", "ROOT", "CURRENT", "TAG", 
			"NODENAME", "OPERATOR"
		};
	}
	private static final String[] _SYMBOLIC_NAMES = makeSymbolicNames();
	public static final Vocabulary VOCABULARY = new VocabularyImpl(_LITERAL_NAMES, _SYMBOLIC_NAMES);

	/**
	 * @deprecated Use {@link #VOCABULARY} instead.
	 */
	@Deprecated
	public static final String[] tokenNames;
	static {
		tokenNames = new String[_SYMBOLIC_NAMES.length];
		for (int i = 0; i < tokenNames.length; i++) {
			tokenNames[i] = VOCABULARY.getLiteralName(i);
			if (tokenNames[i] == null) {
				tokenNames[i] = VOCABULARY.getSymbolicName(i);
			}

			if (tokenNames[i] == null) {
				tokenNames[i] = "<INVALID>";
			}
		}
	}

	@Override
	@Deprecated
	public String[] getTokenNames() {
		return tokenNames;
	}

	@Override

	public Vocabulary getVocabulary() {
		return VOCABULARY;
	}

	@Override
	public String getGrammarFileName() { return "JsonLT.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public ATN getATN() { return _ATN; }

	public JsonLTParser(TokenStream input) {
		super(input);
		_interp = new ParserATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	public static class JsonContext extends ParserRuleContext {
		public ElementContext element() {
			return getRuleContext(ElementContext.class,0);
		}
		public JsonContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_json; }
	}

	public final JsonContext json() throws RecognitionException {
		JsonContext _localctx = new JsonContext(_ctx, getState());
		enterRule(_localctx, 0, RULE_json);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(18);
			element();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ObjContext extends ParserRuleContext {
		public List<MemberContext> member() {
			return getRuleContexts(MemberContext.class);
		}
		public MemberContext member(int i) {
			return getRuleContext(MemberContext.class,i);
		}
		public ObjContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_obj; }
	}

	public final ObjContext obj() throws RecognitionException {
		ObjContext _localctx = new ObjContext(_ctx, getState());
		enterRule(_localctx, 2, RULE_obj);
		int _la;
		try {
			setState(33);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,1,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(20);
				match(T__0);
				setState(21);
				member();
				setState(26);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==T__1) {
					{
					{
					setState(22);
					match(T__1);
					setState(23);
					member();
					}
					}
					setState(28);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				setState(29);
				match(T__2);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(31);
				match(T__0);
				setState(32);
				match(T__2);
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class MemberContext extends ParserRuleContext {
		public TerminalNode STRING() { return getToken(JsonLTParser.STRING, 0); }
		public ElementContext element() {
			return getRuleContext(ElementContext.class,0);
		}
		public MemberContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_member; }
	}

	public final MemberContext member() throws RecognitionException {
		MemberContext _localctx = new MemberContext(_ctx, getState());
		enterRule(_localctx, 4, RULE_member);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(35);
			match(STRING);
			setState(36);
			match(T__3);
			setState(37);
			element();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ArrayContext extends ParserRuleContext {
		public List<ElementContext> element() {
			return getRuleContexts(ElementContext.class);
		}
		public ElementContext element(int i) {
			return getRuleContext(ElementContext.class,i);
		}
		public ArrayContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_array; }
	}

	public final ArrayContext array() throws RecognitionException {
		ArrayContext _localctx = new ArrayContext(_ctx, getState());
		enterRule(_localctx, 6, RULE_array);
		int _la;
		try {
			setState(52);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,3,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(39);
				match(T__4);
				setState(40);
				element();
				setState(45);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==T__1) {
					{
					{
					setState(41);
					match(T__1);
					setState(42);
					element();
					}
					}
					setState(47);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				setState(48);
				match(T__5);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(50);
				match(T__4);
				setState(51);
				match(T__5);
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ElementContext extends ParserRuleContext {
		public TerminalNode STRING() { return getToken(JsonLTParser.STRING, 0); }
		public TerminalNode NUMBER() { return getToken(JsonLTParser.NUMBER, 0); }
		public ObjContext obj() {
			return getRuleContext(ObjContext.class,0);
		}
		public ArrayContext array() {
			return getRuleContext(ArrayContext.class,0);
		}
		public PathContext path() {
			return getRuleContext(PathContext.class,0);
		}
		public ElementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_element; }
	}

	public final ElementContext element() throws RecognitionException {
		ElementContext _localctx = new ElementContext(_ctx, getState());
		enterRule(_localctx, 8, RULE_element);
		try {
			setState(62);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case STRING:
				enterOuterAlt(_localctx, 1);
				{
				setState(54);
				match(STRING);
				}
				break;
			case NUMBER:
				enterOuterAlt(_localctx, 2);
				{
				setState(55);
				match(NUMBER);
				}
				break;
			case T__0:
				enterOuterAlt(_localctx, 3);
				{
				setState(56);
				obj();
				}
				break;
			case T__4:
				enterOuterAlt(_localctx, 4);
				{
				setState(57);
				array();
				}
				break;
			case T__6:
				enterOuterAlt(_localctx, 5);
				{
				setState(58);
				match(T__6);
				}
				break;
			case T__7:
				enterOuterAlt(_localctx, 6);
				{
				setState(59);
				match(T__7);
				}
				break;
			case T__8:
				enterOuterAlt(_localctx, 7);
				{
				setState(60);
				match(T__8);
				}
				break;
			case ROOT:
			case CURRENT:
			case TAG:
				enterOuterAlt(_localctx, 8);
				{
				setState(61);
				path();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class PathContext extends ParserRuleContext {
		public TerminalNode ROOT() { return getToken(JsonLTParser.ROOT, 0); }
		public SubpathContext subpath() {
			return getRuleContext(SubpathContext.class,0);
		}
		public TerminalNode CURRENT() { return getToken(JsonLTParser.CURRENT, 0); }
		public TerminalNode TAG() { return getToken(JsonLTParser.TAG, 0); }
		public PathContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_path; }
	}

	public final PathContext path() throws RecognitionException {
		PathContext _localctx = new PathContext(_ctx, getState());
		enterRule(_localctx, 10, RULE_path);
		int _la;
		try {
			setState(76);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case ROOT:
				enterOuterAlt(_localctx, 1);
				{
				setState(64);
				match(ROOT);
				setState(66);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__4) | (1L << T__9) | (1L << T__10))) != 0)) {
					{
					setState(65);
					subpath();
					}
				}

				}
				break;
			case CURRENT:
				enterOuterAlt(_localctx, 2);
				{
				setState(68);
				match(CURRENT);
				setState(70);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__4) | (1L << T__9) | (1L << T__10))) != 0)) {
					{
					setState(69);
					subpath();
					}
				}

				}
				break;
			case TAG:
				enterOuterAlt(_localctx, 3);
				{
				setState(72);
				match(TAG);
				setState(74);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__4) | (1L << T__9) | (1L << T__10))) != 0)) {
					{
					setState(73);
					subpath();
					}
				}

				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class SubpathContext extends ParserRuleContext {
		public TerminalNode NODENAME() { return getToken(JsonLTParser.NODENAME, 0); }
		public ConditionContext condition() {
			return getRuleContext(ConditionContext.class,0);
		}
		public SubpathContext subpath() {
			return getRuleContext(SubpathContext.class,0);
		}
		public TerminalNode NUMBER() { return getToken(JsonLTParser.NUMBER, 0); }
		public SubpathContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_subpath; }
	}

	public final SubpathContext subpath() throws RecognitionException {
		SubpathContext _localctx = new SubpathContext(_ctx, getState());
		enterRule(_localctx, 12, RULE_subpath);
		int _la;
		try {
			setState(101);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case T__9:
				enterOuterAlt(_localctx, 1);
				{
				setState(78);
				match(T__9);
				setState(79);
				match(NODENAME);
				setState(81);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==T__12) {
					{
					setState(80);
					condition();
					}
				}

				setState(84);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__4) | (1L << T__9) | (1L << T__10))) != 0)) {
					{
					setState(83);
					subpath();
					}
				}

				}
				break;
			case T__10:
				enterOuterAlt(_localctx, 2);
				{
				setState(86);
				match(T__10);
				setState(87);
				match(NODENAME);
				setState(88);
				match(T__11);
				setState(90);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==T__12) {
					{
					setState(89);
					condition();
					}
				}

				setState(93);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__4) | (1L << T__9) | (1L << T__10))) != 0)) {
					{
					setState(92);
					subpath();
					}
				}

				}
				break;
			case T__4:
				enterOuterAlt(_localctx, 3);
				{
				setState(95);
				match(T__4);
				setState(96);
				match(NUMBER);
				setState(97);
				match(T__5);
				setState(99);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__4) | (1L << T__9) | (1L << T__10))) != 0)) {
					{
					setState(98);
					subpath();
					}
				}

				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ConditionContext extends ParserRuleContext {
		public BoolContext bool() {
			return getRuleContext(BoolContext.class,0);
		}
		public ConditionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_condition; }
	}

	public final ConditionContext condition() throws RecognitionException {
		ConditionContext _localctx = new ConditionContext(_ctx, getState());
		enterRule(_localctx, 14, RULE_condition);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(103);
			match(T__12);
			setState(104);
			bool();
			setState(105);
			match(T__13);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class BoolContext extends ParserRuleContext {
		public List<ElementContext> element() {
			return getRuleContexts(ElementContext.class);
		}
		public ElementContext element(int i) {
			return getRuleContext(ElementContext.class,i);
		}
		public TerminalNode OPERATOR() { return getToken(JsonLTParser.OPERATOR, 0); }
		public BoolContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_bool; }
	}

	public final BoolContext bool() throws RecognitionException {
		BoolContext _localctx = new BoolContext(_ctx, getState());
		enterRule(_localctx, 16, RULE_bool);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(107);
			element();
			setState(108);
			match(OPERATOR);
			setState(109);
			element();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static final String _serializedATN =
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\3\30r\4\2\t\2\4\3\t"+
		"\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\3\2\3\2\3\3"+
		"\3\3\3\3\3\3\7\3\33\n\3\f\3\16\3\36\13\3\3\3\3\3\3\3\3\3\5\3$\n\3\3\4"+
		"\3\4\3\4\3\4\3\5\3\5\3\5\3\5\7\5.\n\5\f\5\16\5\61\13\5\3\5\3\5\3\5\3\5"+
		"\5\5\67\n\5\3\6\3\6\3\6\3\6\3\6\3\6\3\6\3\6\5\6A\n\6\3\7\3\7\5\7E\n\7"+
		"\3\7\3\7\5\7I\n\7\3\7\3\7\5\7M\n\7\5\7O\n\7\3\b\3\b\3\b\5\bT\n\b\3\b\5"+
		"\bW\n\b\3\b\3\b\3\b\3\b\5\b]\n\b\3\b\5\b`\n\b\3\b\3\b\3\b\3\b\5\bf\n\b"+
		"\5\bh\n\b\3\t\3\t\3\t\3\t\3\n\3\n\3\n\3\n\3\n\2\2\13\2\4\6\b\n\f\16\20"+
		"\22\2\2\2\177\2\24\3\2\2\2\4#\3\2\2\2\6%\3\2\2\2\b\66\3\2\2\2\n@\3\2\2"+
		"\2\fN\3\2\2\2\16g\3\2\2\2\20i\3\2\2\2\22m\3\2\2\2\24\25\5\n\6\2\25\3\3"+
		"\2\2\2\26\27\7\3\2\2\27\34\5\6\4\2\30\31\7\4\2\2\31\33\5\6\4\2\32\30\3"+
		"\2\2\2\33\36\3\2\2\2\34\32\3\2\2\2\34\35\3\2\2\2\35\37\3\2\2\2\36\34\3"+
		"\2\2\2\37 \7\5\2\2 $\3\2\2\2!\"\7\3\2\2\"$\7\5\2\2#\26\3\2\2\2#!\3\2\2"+
		"\2$\5\3\2\2\2%&\7\21\2\2&\'\7\6\2\2\'(\5\n\6\2(\7\3\2\2\2)*\7\7\2\2*/"+
		"\5\n\6\2+,\7\4\2\2,.\5\n\6\2-+\3\2\2\2.\61\3\2\2\2/-\3\2\2\2/\60\3\2\2"+
		"\2\60\62\3\2\2\2\61/\3\2\2\2\62\63\7\b\2\2\63\67\3\2\2\2\64\65\7\7\2\2"+
		"\65\67\7\b\2\2\66)\3\2\2\2\66\64\3\2\2\2\67\t\3\2\2\28A\7\21\2\29A\7\22"+
		"\2\2:A\5\4\3\2;A\5\b\5\2<A\7\t\2\2=A\7\n\2\2>A\7\13\2\2?A\5\f\7\2@8\3"+
		"\2\2\2@9\3\2\2\2@:\3\2\2\2@;\3\2\2\2@<\3\2\2\2@=\3\2\2\2@>\3\2\2\2@?\3"+
		"\2\2\2A\13\3\2\2\2BD\7\24\2\2CE\5\16\b\2DC\3\2\2\2DE\3\2\2\2EO\3\2\2\2"+
		"FH\7\25\2\2GI\5\16\b\2HG\3\2\2\2HI\3\2\2\2IO\3\2\2\2JL\7\26\2\2KM\5\16"+
		"\b\2LK\3\2\2\2LM\3\2\2\2MO\3\2\2\2NB\3\2\2\2NF\3\2\2\2NJ\3\2\2\2O\r\3"+
		"\2\2\2PQ\7\f\2\2QS\7\27\2\2RT\5\20\t\2SR\3\2\2\2ST\3\2\2\2TV\3\2\2\2U"+
		"W\5\16\b\2VU\3\2\2\2VW\3\2\2\2Wh\3\2\2\2XY\7\r\2\2YZ\7\27\2\2Z\\\7\16"+
		"\2\2[]\5\20\t\2\\[\3\2\2\2\\]\3\2\2\2]_\3\2\2\2^`\5\16\b\2_^\3\2\2\2_"+
		"`\3\2\2\2`h\3\2\2\2ab\7\7\2\2bc\7\22\2\2ce\7\b\2\2df\5\16\b\2ed\3\2\2"+
		"\2ef\3\2\2\2fh\3\2\2\2gP\3\2\2\2gX\3\2\2\2ga\3\2\2\2h\17\3\2\2\2ij\7\17"+
		"\2\2jk\5\22\n\2kl\7\20\2\2l\21\3\2\2\2mn\5\n\6\2no\7\30\2\2op\5\n\6\2"+
		"p\23\3\2\2\2\21\34#/\66@DHLNSV\\_eg";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}