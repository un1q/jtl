# $test = ".\test.jlt"
# if ($args[0]) {
#   $test = $args[0]
# }
$oldCP = $env:CLASSPATH
$path = (Get-Location).Path
Set-Location "..\parser"
$env:CLASSPATH = ".;..\tools\antlr-4.7.2-complete.jar"
java -jar ..\tools\antlr-4.7.2-complete.jar JsonLT.g4
javac JsonLT*.java
java org.antlr.v4.gui.TestRig JsonLT json -gui .\test.jlt
$env:CLASSPATH = $oldCP
Remove-Item JsonLT*.java
Remove-Item JsonLT*.class
Set-Location $path