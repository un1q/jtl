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
        public void JsonAsJltTest() {
            string json = "{}";
            string jsonLT = ReadFile("JsonAsJltTest.jlt");
            string expected = "{\"description\":\"this jlt is just json\",\"someArray\":[\"str1\",\"str3\",\"str5\"],\"someObject\":{\"int\":123,\"bool\":true,\"string\":\"sdfsdfsdf\",\"null\":null}}";
            string result = interpreter.run(json, jsonLT);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void RootTest() {
            string json = ReadFile("RootTest.json");
            string jsonLT = "$.people";
            string expected = "[{\"name\":\"name1\",\"surname\":\"surname1\",\"sex\":\"male\",\"age\":39},{\"name\":\"name2\",\"surname\":\"surname2\",\"sex\":\"female\",\"age\":39},{\"name\":\"name3\",\"surname\":\"surname3\",\"sex\":\"male\",\"age\":9},{\"name\":\"name4\",\"surname\":\"surname4\",\"sex\":\"female\",\"age\":9},{\"name\":\"name5\",\"surname\":\"surname5\",\"sex\":\"male\",\"age\":29},{\"name\":\"name6\",\"surname\":\"surname6\",\"sex\":\"female\",\"age\":29}]";
            string result = interpreter.run(json, jsonLT);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void RootTest2() {
            string json = ReadFile("RootTest.json");
            string jsonLT = "$['people']";
            string expected = "[{\"name\":\"name1\",\"surname\":\"surname1\",\"sex\":\"male\",\"age\":39},{\"name\":\"name2\",\"surname\":\"surname2\",\"sex\":\"female\",\"age\":39},{\"name\":\"name3\",\"surname\":\"surname3\",\"sex\":\"male\",\"age\":9},{\"name\":\"name4\",\"surname\":\"surname4\",\"sex\":\"female\",\"age\":9},{\"name\":\"name5\",\"surname\":\"surname5\",\"sex\":\"male\",\"age\":29},{\"name\":\"name6\",\"surname\":\"surname6\",\"sex\":\"female\",\"age\":29}]";
            string result = interpreter.run(json, jsonLT);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void RootTest3() {
            string json = ReadFile("RootTest.json");
            string jsonLT = "$.people.name";
            string expected = "[\"name1\",\"name2\",\"name3\",\"name4\",\"name5\",\"name6\"]";
            string result = interpreter.run(json, jsonLT);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void IndexTest() {
            string json = ReadFile("RootTest.json");
            string jsonLT = "$.people[2]";
            string expected = "{\"name\":\"name3\",\"surname\":\"surname3\",\"sex\":\"male\",\"age\":9}";
            string result = interpreter.run(json, jsonLT);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void IndexTest2() {
            string json = ReadFile("RootTest.json");
            string jsonLT = "$.people[2].surname";
            string expected = "\"surname3\"";
            string result = interpreter.run(json, jsonLT);
            Assert.AreEqual(expected, result);
        }
    }
}