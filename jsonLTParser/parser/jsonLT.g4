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
  | 'true'
  | 'false'
  | 'null'
  | path
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
  : '0' | [1-9] [0-9]*
  ;

fragment EXP
  : [Ee] [+\-]? INT
  ;

WS
  : [ \t\n\r] + -> skip
  ;

// 
path
  : ROOT deeper?
  ;

deeper
  : '.' NODE deeper?
  ;


ROOT
  : '$'
  ;

NODE
  : [a-zA-Z][a-zA-Z0-9_]*
  ;