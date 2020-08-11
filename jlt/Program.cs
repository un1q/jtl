using CommandLine;
using jsonLTParser.interpreter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace jlt
{
    class Program
    {
        public class Options {
            [Option('p', "pretty", Required = false, HelpText = "Pretty print.")]
            public bool Pretty { get; set; }

            [Option('s', "asString", Required = false, HelpText = "Returns string instead of json.")]
            public bool AsString { get; set; }

            [Option("jltPath", Group = "jlt source")]
            public string JltPath { get; set; }

            [Option("jltString", Group = "jlt source")]
            public string JltString { get; set; }

            [Option("jsonPath", Group = "json source")]
            public string JsonPath { get; set; }

            [Option("jsonString", Group = "json source")]
            public string JsonString { get; set; }

            [Option('v', "verbose", Required = false, HelpText = "Verbose (prints out jltString and jsonString).")]
            public bool Verbose { get; set; }
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
            String json = null;
            String jlt = null;
            Parser.Default.ParseArguments<Options>(args).WithParsed<Options>(o => {
                if (o.JltPath != null) {
                    jlt = ReadFile(o.JltPath);
                } else if (o.JltString != null) {
                    jlt = o.JltString;
                    if (o.Verbose) {
                        Console.WriteLine("jlt:");
                        Console.WriteLine(jlt);
                    }
                }
                if (o.JsonPath != null) {
                    json = ReadFile(o.JsonPath);
                } else if (o.JsonString != null) {
                    json = o.JsonString;
                    if (o.Verbose) {
                        Console.WriteLine("json:");
                        Console.WriteLine(json);
                    }
                }
                JsonLTInterpreter interpreter = new JsonLTInterpreter();
                string result = interpreter.Run(json, jlt, o.AsString, o.Pretty);
                Console.WriteLine(result);
            });
        }
    }
}
