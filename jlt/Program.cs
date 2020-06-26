using jsonLTParser.interpreter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace jlt
{
    class Program
    {
        private const string JSONSTRING = "jsonString";
        private const string JSONPATH = "jsonPath";
        private const string JLTSTRING = "jltString";
        private const string JLTPATH = "jltPath";

        static Dictionary<string, string> OrganizeArgs(string[] args, string[] available) {
            Dictionary<string, string> options = new Dictionary<string, string>();
            for (int i = 0; i < args.Length; i += 2) {
                string arg = args[i];
                if (!arg.StartsWith("-")) {
                    Console.Error.WriteLine("all parameters should start with -. I'm looking at you: " + arg);
                    return null;
                }
                arg = arg.Substring(1);
                if (!available.Contains(arg)) {
                    Console.Error.WriteLine("Wrong option :" + arg);
                    Console.Error.WriteLine("Only those parameters are valid:");
                    available.ToList().ForEach(o => Console.Error.WriteLine("  -" + o));
                    return null;
                }
                if (i + 1 >= args.Length) {
                    Console.Error.WriteLine("parameter must be followed by something. I'm looking at you: " + arg);
                    return null;
                }
                options.Add(arg, args[i + 1]);
            }
            return options;
        }

        private static string ReadFile(string filePath) {
            string text = null;
            try {
                using (StreamReader sr = new StreamReader(filePath)) {
                    text = sr.ReadToEnd();
                }
            }
            catch (IOException e) {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return text;
        }

        static void Main(string[] args) {
            Dictionary<string, string> options = OrganizeArgs(args, new string[] { JSONSTRING, JSONPATH, JLTSTRING, JLTPATH });
            if (options == null) {
                Usage();
                return;
            }
            string json, jlt;
            if (options.ContainsKey(JSONSTRING)) {
                json = options[JSONSTRING];
            } else if (options.ContainsKey(JSONPATH)) {
                json = ReadFile(options[JSONPATH]);
            } else {
                Console.Error.WriteLine("I need json");
                Usage();
                return;
            }
            if (options.ContainsKey(JLTSTRING)) {
                jlt = options[JLTSTRING];
            } else if (options.ContainsKey(JLTPATH)) {
                jlt = ReadFile(options[JLTPATH]);
            } else {
                Console.Error.WriteLine("I need jlt");
                Usage();
                return;
            }
            JsonLTInterpreter interpreter = new JsonLTInterpreter();
            string result = interpreter.Run(json, jlt);
            Console.WriteLine(result);
        }

        private static void Usage() {
            Console.WriteLine("Usage:");
            Console.WriteLine("  jlt -jsonPath somePath -jltPath somePath");
            Console.WriteLine("  jlt -json \"{json}\" -jlt \"{jlt}\"");
            Console.WriteLine("  jlt -json \"{json}\" -jltPath somePath");
            Console.WriteLine("  jlt -jsonPath somePath -jlt \"{jlt}\"");
        }
    }
}
