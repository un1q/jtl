grammar JsonLT;

json
  : element
  ;

obj
  : '{' member (',' member)* '}'
  | '{' '}'
  ;

member
  : STRING ':' element
  ;

array
  : '[' element (',' element)* ']'
  | '[' ']'
  ;

element
  : STRING
  | NUMBER
  | obj
  | array
  | TRUE
  | FALSE
  | NULL
  | path
  ;

TRUE
  : 'true'
  ;

FALSE
  : 'false'
  ;

NULL
  : 'null'
  ;

STRING
  : '"' (ESC | SAFECODEPOINT)* '"'
  ;

fragment ESC
  : '\\' (["\\/bfnrt] | UNICODE)
  ;

fragment UNICODE
  : 'u' HEX HEX HEX HEX
  ;

fragment HEX
  : [0-9a-fA-F]
  ;

fragment SAFECODEPOINT
  : ~ ["\\\u0000-\u001F]
  ;


NUMBER
  : '-'? INT ('.' [0-9] +)? EXP?
  ;

fragment INT
  : [0-9]+
  ;

fragment EXP
  : [Ee] [+\-]? INT
  ;

WS
  : [ \t\n\r] + -> skip
  ;

// 
ROOT
  : '$'
  ;

CURRENT
  : '@'
  ;

TAG
  : '#' [a-zA-Z][a-zA-Z0-9_]*
  ;

path
  : ROOT subpath?
  | CURRENT subpath?
  | TAG subpath?
  ;

subpath
  : '.' NODENAME condition? subpath?
  | '[\'' NODENAME '\']' condition? subpath?
  | '[' NUMBER ']' subpath?
  ;

NODENAME
  : [a-zA-Z][a-zA-Z0-9_]*
  ;

condition
  : '[?(' expresion ')]'
  ;

expresion
  : expresion ('*'|'/') expresion
  | expresion ('+'|'-') expresion
  | expresion ('<'|'>'|'=') expresion
  | expresion ('and'|'or') expresion
  | '(' expresion ')'
  | element
  ;
