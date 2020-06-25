using jsonLTParser.interpreter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace jsonLTParser.Tests {
    [TestClass()]
    public class JsonLTInterpreterTests {
        private JsonLTInterpreter interpreter = new JsonLTInterpreter();

        public string ReadFile(string fileName) {
            string text = null;
            try {
                using (StreamReader sr = new StreamReader("TestData\\" + fileName)) {
                    text = sr.ReadToEnd();
                }
            }
            catch (IOException e) {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return text;
        }

        [TestMethod()]
        public void MyParseMethodTest() {
            string json = ReadFile("test1.json");
            string jsonLT = ReadFile("test1.jlt");
            string result = interpreter.run(json, jsonLT);
            Assert.AreEqual("whatever", result);
        }
    }
}