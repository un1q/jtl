// Generated from c:\Users\u005Cun1q\projekty\jsonLT\jsonLTParser\parser\JsonLT.g4 by ANTLR 4.8
import org.antlr.v4.runtime.Lexer;
import org.antlr.v4.runtime.CharStream;
import org.antlr.v4.runtime.Token;
import org.antlr.v4.runtime.TokenStream;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.misc.*;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class JsonLTLexer extends Lexer {
	static { RuntimeMetaData.checkVersion("4.8", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, T__7=8, T__8=9, 
		T__9=10, T__10=11, T__11=12, T__12=13, T__13=14, STRING=15, NUMBER=16, 
		WS=17, ROOT=18, CURRENT=19, TAG=20, NODENAME=21, OPERATOR=22;
	public static String[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static String[] modeNames = {
		"DEFAULT_MODE"
	};

	private static String[] makeRuleNames() {
		return new String[] {
			"T__0", "T__1", "T__2", "T__3", "T__4", "T__5", "T__6", "T__7", "T__8", 
			"T__9", "T__10", "T__11", "T__12", "T__13", "STRING", "ESC", "UNICODE", 
			"HEX", "SAFECODEPOINT", "NUMBER", "INT", "EXP", "WS", "ROOT", "CURRENT", 
			"TAG", "NODENAME", "OPERATOR"
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


	public JsonLTLexer(CharStream input) {
		super(input);
		_interp = new LexerATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	@Override
	public String getGrammarFileName() { return "JsonLT.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public String[] getChannelNames() { return channelNames; }

	@Override
	public String[] getModeNames() { return modeNames; }

	@Override
	public ATN getATN() { return _ATN; }

	public static final String _serializedATN =
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\2\30\u00b5\b\1\4\2"+
		"\t\2\4\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4"+
		"\13\t\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22"+
		"\t\22\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\4\31"+
		"\t\31\4\32\t\32\4\33\t\33\4\34\t\34\4\35\t\35\3\2\3\2\3\3\3\3\3\4\3\4"+
		"\3\5\3\5\3\6\3\6\3\7\3\7\3\b\3\b\3\b\3\b\3\b\3\t\3\t\3\t\3\t\3\t\3\t\3"+
		"\n\3\n\3\n\3\n\3\n\3\13\3\13\3\f\3\f\3\f\3\r\3\r\3\r\3\16\3\16\3\16\3"+
		"\16\3\17\3\17\3\17\3\20\3\20\3\20\7\20j\n\20\f\20\16\20m\13\20\3\20\3"+
		"\20\3\21\3\21\3\21\5\21t\n\21\3\22\3\22\3\22\3\22\3\22\3\22\3\23\3\23"+
		"\3\24\3\24\3\25\5\25\u0081\n\25\3\25\3\25\3\25\6\25\u0086\n\25\r\25\16"+
		"\25\u0087\5\25\u008a\n\25\3\25\5\25\u008d\n\25\3\26\6\26\u0090\n\26\r"+
		"\26\16\26\u0091\3\27\3\27\5\27\u0096\n\27\3\27\3\27\3\30\6\30\u009b\n"+
		"\30\r\30\16\30\u009c\3\30\3\30\3\31\3\31\3\32\3\32\3\33\3\33\3\33\7\33"+
		"\u00a8\n\33\f\33\16\33\u00ab\13\33\3\34\3\34\7\34\u00af\n\34\f\34\16\34"+
		"\u00b2\13\34\3\35\3\35\2\2\36\3\3\5\4\7\5\t\6\13\7\r\b\17\t\21\n\23\13"+
		"\25\f\27\r\31\16\33\17\35\20\37\21!\2#\2%\2\'\2)\22+\2-\2/\23\61\24\63"+
		"\25\65\26\67\279\30\3\2\f\n\2$$\61\61^^ddhhppttvv\5\2\62;CHch\5\2\2!$"+
		"$^^\3\2\62;\4\2GGgg\4\2--//\5\2\13\f\17\17\"\"\4\2C\\c|\6\2\62;C\\aac"+
		"|\3\2>@\2\u00ba\2\3\3\2\2\2\2\5\3\2\2\2\2\7\3\2\2\2\2\t\3\2\2\2\2\13\3"+
		"\2\2\2\2\r\3\2\2\2\2\17\3\2\2\2\2\21\3\2\2\2\2\23\3\2\2\2\2\25\3\2\2\2"+
		"\2\27\3\2\2\2\2\31\3\2\2\2\2\33\3\2\2\2\2\35\3\2\2\2\2\37\3\2\2\2\2)\3"+
		"\2\2\2\2/\3\2\2\2\2\61\3\2\2\2\2\63\3\2\2\2\2\65\3\2\2\2\2\67\3\2\2\2"+
		"\29\3\2\2\2\3;\3\2\2\2\5=\3\2\2\2\7?\3\2\2\2\tA\3\2\2\2\13C\3\2\2\2\r"+
		"E\3\2\2\2\17G\3\2\2\2\21L\3\2\2\2\23R\3\2\2\2\25W\3\2\2\2\27Y\3\2\2\2"+
		"\31\\\3\2\2\2\33_\3\2\2\2\35c\3\2\2\2\37f\3\2\2\2!p\3\2\2\2#u\3\2\2\2"+
		"%{\3\2\2\2\'}\3\2\2\2)\u0080\3\2\2\2+\u008f\3\2\2\2-\u0093\3\2\2\2/\u009a"+
		"\3\2\2\2\61\u00a0\3\2\2\2\63\u00a2\3\2\2\2\65\u00a4\3\2\2\2\67\u00ac\3"+
		"\2\2\29\u00b3\3\2\2\2;<\7}\2\2<\4\3\2\2\2=>\7.\2\2>\6\3\2\2\2?@\7\177"+
		"\2\2@\b\3\2\2\2AB\7<\2\2B\n\3\2\2\2CD\7]\2\2D\f\3\2\2\2EF\7_\2\2F\16\3"+
		"\2\2\2GH\7v\2\2HI\7t\2\2IJ\7w\2\2JK\7g\2\2K\20\3\2\2\2LM\7h\2\2MN\7c\2"+
		"\2NO\7n\2\2OP\7u\2\2PQ\7g\2\2Q\22\3\2\2\2RS\7p\2\2ST\7w\2\2TU\7n\2\2U"+
		"V\7n\2\2V\24\3\2\2\2WX\7\60\2\2X\26\3\2\2\2YZ\7]\2\2Z[\7)\2\2[\30\3\2"+
		"\2\2\\]\7)\2\2]^\7_\2\2^\32\3\2\2\2_`\7]\2\2`a\7A\2\2ab\7*\2\2b\34\3\2"+
		"\2\2cd\7+\2\2de\7_\2\2e\36\3\2\2\2fk\7$\2\2gj\5!\21\2hj\5\'\24\2ig\3\2"+
		"\2\2ih\3\2\2\2jm\3\2\2\2ki\3\2\2\2kl\3\2\2\2ln\3\2\2\2mk\3\2\2\2no\7$"+
		"\2\2o \3\2\2\2ps\7^\2\2qt\t\2\2\2rt\5#\22\2sq\3\2\2\2sr\3\2\2\2t\"\3\2"+
		"\2\2uv\7w\2\2vw\5%\23\2wx\5%\23\2xy\5%\23\2yz\5%\23\2z$\3\2\2\2{|\t\3"+
		"\2\2|&\3\2\2\2}~\n\4\2\2~(\3\2\2\2\177\u0081\7/\2\2\u0080\177\3\2\2\2"+
		"\u0080\u0081\3\2\2\2\u0081\u0082\3\2\2\2\u0082\u0089\5+\26\2\u0083\u0085"+
		"\7\60\2\2\u0084\u0086\t\5\2\2\u0085\u0084\3\2\2\2\u0086\u0087\3\2\2\2"+
		"\u0087\u0085\3\2\2\2\u0087\u0088\3\2\2\2\u0088\u008a\3\2\2\2\u0089\u0083"+
		"\3\2\2\2\u0089\u008a\3\2\2\2\u008a\u008c\3\2\2\2\u008b\u008d\5-\27\2\u008c"+
		"\u008b\3\2\2\2\u008c\u008d\3\2\2\2\u008d*\3\2\2\2\u008e\u0090\t\5\2\2"+
		"\u008f\u008e\3\2\2\2\u0090\u0091\3\2\2\2\u0091\u008f\3\2\2\2\u0091\u0092"+
		"\3\2\2\2\u0092,\3\2\2\2\u0093\u0095\t\6\2\2\u0094\u0096\t\7\2\2\u0095"+
		"\u0094\3\2\2\2\u0095\u0096\3\2\2\2\u0096\u0097\3\2\2\2\u0097\u0098\5+"+
		"\26\2\u0098.\3\2\2\2\u0099\u009b\t\b\2\2\u009a\u0099\3\2\2\2\u009b\u009c"+
		"\3\2\2\2\u009c\u009a\3\2\2\2\u009c\u009d\3\2\2\2\u009d\u009e\3\2\2\2\u009e"+
		"\u009f\b\30\2\2\u009f\60\3\2\2\2\u00a0\u00a1\7&\2\2\u00a1\62\3\2\2\2\u00a2"+
		"\u00a3\7B\2\2\u00a3\64\3\2\2\2\u00a4\u00a5\7%\2\2\u00a5\u00a9\t\t\2\2"+
		"\u00a6\u00a8\t\n\2\2\u00a7\u00a6\3\2\2\2\u00a8\u00ab\3\2\2\2\u00a9\u00a7"+
		"\3\2\2\2\u00a9\u00aa\3\2\2\2\u00aa\66\3\2\2\2\u00ab\u00a9\3\2\2\2\u00ac"+
		"\u00b0\t\t\2\2\u00ad\u00af\t\n\2\2\u00ae\u00ad\3\2\2\2\u00af\u00b2\3\2"+
		"\2\2\u00b0\u00ae\3\2\2\2\u00b0\u00b1\3\2\2\2\u00b18\3\2\2\2\u00b2\u00b0"+
		"\3\2\2\2\u00b3\u00b4\t\13\2\2\u00b4:\3\2\2\2\17\2iks\u0080\u0087\u0089"+
		"\u008c\u0091\u0095\u009c\u00a9\u00b0\3\b\2\2";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}