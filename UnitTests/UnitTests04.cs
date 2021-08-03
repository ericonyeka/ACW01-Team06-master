using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities;
using System.Collections.Generic;


namespace UnitTests
{
    [TestClass]
    public class UnitTests04
    {
        [TestMethod]
        public void TestAddParaHTML1()
        {
            var utilityObject = new Utilities04();
            string data = "i.";
            string expected = "<p>I.</p>";
            string result = utilityObject.AddParaHtml(data);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestAddParaHTML2()
        {
            var utilityObject = new Utilities04();
            string data = "i. i. i.";
            string expected = "<p>I.</p><p>I.</p><p>I.</p>";
            string result = utilityObject.AddParaHtml(data);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestAddParaHTML3()
        {
            var utilityObject = new Utilities04();
            string data = "Hello world. how are you. Hopefully well.";
            string expected = "<p>Hello world.</p><p>How are you.</p><p>Hopefully well.</p>";
            string result = utilityObject.AddParaHtml(data);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestAddParaHTML4()
        {
            var utilityObject = new Utilities04();
            string data = "ABC£$. w$£. D%.";
            string expected = "<p>ABC£$.</p><p>W$£.</p><p>D%.</p>";
            string result = utilityObject.AddParaHtml(data);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void TestAddParaHTML5()
        {
            var utilityObject = new Utilities04();
            string data = "";
            string result = utilityObject.AddParaHtml(data);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void TestAddParaHTML6()
        {
            var utilityObject = new Utilities04();
            string data = null;
            string result = utilityObject.AddParaHtml(data);
        }


        [TestMethod]
        public void TestParagraphs1()
        {
            var utilityObject = new Utilities04();
            string data = "A.";
            List<string> expected = new List<string>();
            expected.Add("A.");
            List<string> result = utilityObject.Paragraphs(data);
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestParagraphs2()
        {
            var utilityObject = new Utilities04();
            string data = "a. a. a.";
            List<string> expected = new List<string>();
            expected.Add("A.");
            expected.Add("A.");
            expected.Add("A.");
            List<string> result = utilityObject.Paragraphs(data);
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestParagraphs3()
        {
            var utilityObject = new Utilities04();
            string data = "Hello, there everyone. these are my paragraphs. Hopefully it is formatted properly.";
            List<string> expected = new List<string>();
            expected.Add("Hello, there everyone.");
            expected.Add("These are my paragraphs.");
            expected.Add("Hopefully it is formatted properly.");
            List<string> result = utilityObject.Paragraphs(data);
            CollectionAssert.AreEqual(expected, result);
        }

        public void TestParagraphs4()
        {
            var utilityObject = new Utilities04();
            string data = "H3l!o there. T*%$L.Hopefully it is f0rmatt£d prop3rly.";
            List<string> expected = new List<string>();
            expected.Add("H3l!o there.");
            expected.Add("T*%$L.");
            expected.Add("Hopefully it is f0rmatt£d prop3rly.");
            List<string> result = utilityObject.Paragraphs(data);
            CollectionAssert.AreEqual(expected, result);
        }


        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void TestParagraphs5()
        {
            var utilityObject = new Utilities04();
            string data = "";
            List<string> result = utilityObject.Paragraphs(data);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void TestParagraphs6()
        {
            var utilityObject = new Utilities04();
            string data = null;
            List<string> result = utilityObject.Paragraphs(data);
        }

        [TestMethod]
        public void TestReverseWords1()
        {
            var utilityObject = new Utilities04();
            string data = "hello.";
            string expected = "Hello.";
            string result = utilityObject.ReverseWords(data);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestReverseWords2()
        {
            var utilityObject = new Utilities04();
            string data = "Hello there.";
            string expected = "There hello.";
            string result = utilityObject.ReverseWords(data);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestReverseWords3()
        {
            var utilityObject = new Utilities04();
            string data = "hello there.";
            string expected = "There hello.";
            string result = utilityObject.ReverseWords(data);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestReverseWords4()
        {
            var utilityObject = new Utilities04();
            string data = "Hello there this is checking my method in an extended sentence.";
            string expected = "Sentence extended an in method my checking is this there hello.";
            string result = utilityObject.ReverseWords(data);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestReverseWords5()
        {
            var utilityObject = new Utilities04();
            string data = "H3llo there this is checking my meth0d in an ext3nd3d sentence.";
            string expected = "Sentence ext3nd3d an in meth0d my checking is this there h3llo.";
            string result = utilityObject.ReverseWords(data);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestReverseWords6()
        {
            var utilityObject = new Utilities04();
            string data = "Hello there this is check%ing my method in an exte$nded sentence.";
            string expected = "Sentence exte$nded an in method my check%ing is this there hello.";
            string result = utilityObject.ReverseWords(data);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void TestReverseWords7()
        {
            var utilityObject = new Utilities04();
            string data = "";
            string result = utilityObject.ReverseWords(data);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void TestReverseWords8()
        {
            var utilityObject = new Utilities04();
            string data = null;
            string result = utilityObject.ReverseWords(data);
        }

        [TestMethod]
        public void TestTranslate1()
        {
            var utilityObject = new Utilities04();
            string data = "here is the news brought to you over the internet";
            string expected = "erehay isyay ethay ewsnay oughtbray otay youyay overyay ethay internetyay";
            string result = utilityObject.Translate(data);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestTranslate2()
        {
            var utilityObject = new Utilities04();
            string data = "here is the news, brought to you over the internet";
            string expected = "erehay isyay ethay ewsnay, oughtbray otay youyay overyay ethay internetyay";
            string result = utilityObject.Translate(data);
            Assert.AreEqual(expected, result);
        }


        [TestMethod]
        public void TestTranslate3()
        {
            var utilityObject = new Utilities04();
            string data = "Here is the news, brought to you over the internet";
            string expected = "Erehay isyay ethay ewsnay, oughtbray otay youyay overyay ethay internetyay";
            string result = utilityObject.Translate(data);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestTranslate4()
        {
            var utilityObject = new Utilities04();
            string data = "Here is the news, brought to you over the internet.";
            string expected = "Erehay isyay ethay ewsnay, oughtbray otay youyay overyay ethay internetyay.";
            string result = utilityObject.Translate(data);
            Assert.AreEqual(expected, result);
        }


        [TestMethod]
        public void TestTranslate5()
        {
            var utilityObject = new Utilities04();
            string data = "Here is the News, Brought to you Over the internet.";
            string expected = "Erehay isyay ethay Ewsnay, Oughtbray otay youyay Overyay ethay internetyay.";
            string result = utilityObject.Translate(data);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void TestTranslate6()
        {
            var utilityObject = new Utilities04();
            string data = "";
            string result = utilityObject.Translate(data);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void TestTranslate7()
        {
            var utilityObject = new Utilities04();
            string data = null;
            string result = utilityObject.Translate(data);
        }

        [TestMethod]
        public void TestSentenceLengths1()
        {
            var utilityObject = new Utilities04();
            string source = "Hello World.";

            Dictionary<int, int> expected = new Dictionary<int, int>();
            expected.Add(2, 1);

            Dictionary<int, int> result = utilityObject.SentenceLengths(source);
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestSentenceLengths2()
        {
            var utilityObject = new Utilities04();
            string source = "Hello World. Hello World";

            Dictionary<int, int> expected = new Dictionary<int, int>();
            expected.Add(2, 2);

            Dictionary<int, int> result = utilityObject.SentenceLengths(source);
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestSentenceLengths3()
        {
            var utilityObject = new Utilities04();
            string source = "Hello World. Hope you are well today.";

            Dictionary<int, int> expected = new Dictionary<int, int>();
            expected.Add(2, 1);
            expected.Add(5, 1);

            Dictionary<int, int> result = utilityObject.SentenceLengths(source);
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestSentenceLengths4()
        {
            var utilityObject = new Utilities04();
            string source = "Hello World. Hope you are well today. Hello World. Hope you are well today.";

            Dictionary<int, int> expected = new Dictionary<int, int>();
            expected.Add(2, 2);
            expected.Add(5, 2);

            Dictionary<int, int> result = utilityObject.SentenceLengths(source);
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestSentenceLengths5()
        {
            var utilityObject = new Utilities04();
            string source = "Hello World. Hope you are well today. What a nice day it is today. Hello World. Hope you are well today.";

            Dictionary<int, int> expected = new Dictionary<int, int>();
            expected.Add(2, 2);
            expected.Add(5, 2);
            expected.Add(7, 1);

            Dictionary<int, int> result = utilityObject.SentenceLengths(source);
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestSentenceLengths6()
        {
            var utilityObject = new Utilities04();
            string source = "H3ll0 WoRld. H0pe You ar3 w3Ll t0day.";

            Dictionary<int, int> expected = new Dictionary<int, int>();
            expected.Add(2, 1);
            expected.Add(5, 1);

            Dictionary<int, int> result = utilityObject.SentenceLengths(source);
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestSentenceLengths7()
        {
            var utilityObject = new Utilities04();
            string source = "H£llo Wor*ld. Hope you ar£ we%l today.";

            Dictionary<int, int> expected = new Dictionary<int, int>();
            expected.Add(2, 1);
            expected.Add(5, 1);

            Dictionary<int, int> result = utilityObject.SentenceLengths(source);
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void TestSentenceLengths8()
        {
            var utilityObject = new Utilities04();
            string data = null;
            Dictionary<int, int> result = utilityObject.SentenceLengths(data);


        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void TestSentenceLengths9()
        {
            var utilityObject = new Utilities04();
            string data = "";
            Dictionary<int, int> result = utilityObject.SentenceLengths(data);
        }
    }
}

    


