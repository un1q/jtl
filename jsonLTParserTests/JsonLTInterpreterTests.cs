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
            string result = interpreter.Run(json, jsonLT);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void RootTest() {
            string json = ReadFile("RootTest.json");
            string jsonLT = "$.people";
            string expected = "[{\"name\":\"name1\",\"surname\":\"surname1\",\"sex\":\"male\",\"age\":39},{\"name\":\"name2\",\"surname\":\"surname2\",\"sex\":\"female\",\"age\":39},{\"name\":\"name3\",\"surname\":\"surname3\",\"sex\":\"male\",\"age\":9},{\"name\":\"name4\",\"surname\":\"surname4\",\"sex\":\"female\",\"age\":9},{\"name\":\"name5\",\"surname\":\"surname5\",\"sex\":\"male\",\"age\":29},{\"name\":\"name6\",\"surname\":\"surname6\",\"sex\":\"female\",\"age\":29}]";
            string result = interpreter.Run(json, jsonLT);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void RootTest2() {
            string json = ReadFile("RootTest.json");
            string jsonLT = "$['people']";
            string expected = "[{\"name\":\"name1\",\"surname\":\"surname1\",\"sex\":\"male\",\"age\":39},{\"name\":\"name2\",\"surname\":\"surname2\",\"sex\":\"female\",\"age\":39},{\"name\":\"name3\",\"surname\":\"surname3\",\"sex\":\"male\",\"age\":9},{\"name\":\"name4\",\"surname\":\"surname4\",\"sex\":\"female\",\"age\":9},{\"name\":\"name5\",\"surname\":\"surname5\",\"sex\":\"male\",\"age\":29},{\"name\":\"name6\",\"surname\":\"surname6\",\"sex\":\"female\",\"age\":29}]";
            string result = interpreter.Run(json, jsonLT);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void RootTest3() {
            string json = ReadFile("RootTest.json");
            string jsonLT = "$.people.name";
            string expected = "[\"name1\",\"name2\",\"name3\",\"name4\",\"name5\",\"name6\"]";
            string result = interpreter.Run(json, jsonLT);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void IndexTest() {
            string json = ReadFile("RootTest.json");
            string jsonLT = "$.people[2]";
            string expected = "{\"name\":\"name3\",\"surname\":\"surname3\",\"sex\":\"male\",\"age\":9}";
            string result = interpreter.Run(json, jsonLT);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void IndexTest2() {
            string json = ReadFile("RootTest.json");
            string jsonLT = "$.people[2].surname";
            string expected = "\"surname3\"";
            string result = interpreter.Run(json, jsonLT);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void ConditionTest1() {
            string json = ReadFile("RootTest.json");
            string jsonLT = "$.people[?(@.sex = \"male\")].surname";
            string expected = "[\"surname1\",\"surname3\",\"surname5\"]";
            string result = interpreter.Run(json, jsonLT);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void ConditionTest2() {
            string json = ReadFile("RootTest.json");
            string jsonLT = "$.people[?(@.age > 20 and @.age < 30)]";
            string expected = "[{\"name\":\"name5\",\"surname\":\"surname5\",\"sex\":\"male\",\"age\":29},{\"name\":\"name6\",\"surname\":\"surname6\",\"sex\":\"female\",\"age\":29}]";
            string result = interpreter.Run(json, jsonLT);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void ConcatTest1() {
            string json = "{}";
            string jsonLT = "\"This\" \"is\" \"test\" \"123\"";
            string expected = "\"This is test 123\"";
            string result = interpreter.Run(json, jsonLT);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void ConcatTest2() {
            string json = ReadFile("RootTest.json");
            string jsonLT = "$.people[1].name $.people[1].surname";
            string expected = "\"name2 surname2\"";
            string result = interpreter.Run(json, jsonLT);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void ForEachTest1() {
            string json = ReadFile("RootTest.json");
            string jsonLT = "$.people[1](\"His name is\" @.name @.surname)";
            string expected = "\"His name is name2 surname2\"";
            string result = interpreter.Run(json, jsonLT);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void ForEachTest2() {
            string json = ReadFile("RootTest.json");
            string jsonLT = "$.people[1]#pp(\"His name is\" #pp.name #pp.surname)";
            string expected = "\"His name is name2 surname2\"";
            string result = interpreter.Run(json, jsonLT);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void Trello1() {
            string json = ReadFile("trello.json");
            string jsonLT = "$.name";
            string expected = "\"Gloomheaven\"";
            string result = interpreter.Run(json, jsonLT);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void Trello2()
        {
            string json = ReadFile("trello.json");
            string jsonLT = "$.lists.name";
            string expected = "[\"Odwiedzone\",\"Dostępne?\",\"Już niedostępne\",\"Achievementy\"]";
            string result = interpreter.Run(json, jsonLT);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void Trello3()
        {
            string json = ReadFile("trello.json");
            string jsonLT = "{\"name\" : $.name , \"lists\" : $.lists.name}";
            string expected = "{\"name\":\"Gloomheaven\",\"lists\":[\"Odwiedzone\",\"Dostępne?\",\"Już niedostępne\",\"Achievementy\"]}";
            string result = interpreter.Run(json, jsonLT);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void Trello4()
        {
            string json = ReadFile("trello.json");
            string jsonLT = @"{
                ""name"" : $.name ,
                ""lists"" : $.lists#LIST(
                    {
                        ""name"" : #LIST.name
                    }
                )
            }";
            string expected = "{\"name\":\"Gloomheaven\",\"lists\":[{\"name\":\"Odwiedzone\"},{\"name\":\"Dostępne?\"},{\"name\":\"Już niedostępne\"},{\"name\":\"Achievementy\"}]}";
            string result = interpreter.Run(json, jsonLT);
            Assert.AreEqual(expected, result);
        }


        [TestMethod()]
        public void Trello5() {
            string json = ReadFile("trello.json");
            string jsonLT = @"{
                ""name"" : $.name ,
                ""lists"" : $.lists#LIST(
                    {
                        ""name""  : #LIST.name,
                        ""cards"" : $.cards[?(@.idList = #LIST.id)].name
                    }
                )
            }";
            string expected = ReadFile("expected_trello5.json");
            string result = interpreter.Run(json, jsonLT);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void Trello6() {
            string json = ReadFile("trello.json");
            string jsonLT = @"{
                ""name"" : $.name ,
                ""lists"" : $.lists#LIST(
                    {
                        ""name""  : #LIST.name,
                        ""cards"" : $.cards[?(@.idList = #LIST.id)]#CARD(
                            {
                                ""name"" : #CARD.name,
                                ""url""  : #CARD.shortUrl
                            }
                        )
                    }
                )
            }";
            string expected = ReadFile("expected_trello6.json");
            string result = interpreter.Run(json, jsonLT);
            Assert.AreEqual(expected, result);
        }
    }
}