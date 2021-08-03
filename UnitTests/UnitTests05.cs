using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities;

namespace UnitTests
{
    [TestClass]
    public class UnitTests05
    {
        [TestMethod]
        public void TestDistinctWords1()
        {
            var utilityObj = new Utilities05();
            string data = "Haha Haha Haha Aha Test Word Word Word Words Test Test2";
            string expected = "Haha Aha Test Word Words Test2";
            var result = utilityObj.DistinctWords(data);
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestDistinctWords2()
        {
            var utilityObj = new Utilities05();
            string data = "Haha Haha, Haha Aha Test Word Word Word Words Test Test2 Contempt";
            string expected = "Haha Haha, Aha Test Word Words Test2 Contempt";
            var result = utilityObj.DistinctWords(data);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestLineCentre1()
        {
            var utilityObj = new Utilities05();
            string data = "word words haha";
            int number = 17;
            string expected = " word words haha ";
            var result = utilityObj.LineCentre(data, number);
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestLineCentre2()
        {
            var utilityObj = new Utilities05();
            string data = "word words haha";
            int number = 18;
            string expected = " word words haha  ";
            var result = utilityObj.LineCentre(data, number);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestProperNouns1()
        {
            var utilityObj = new Utilities05();
            string data = "Eric loves football, but Andreas does not like it.";
            string expected = "Andreas";
            var results = utilityObj.ProperNouns(data);
            Assert.AreEqual(expected, results);
        }
        [TestMethod]
        public void TestProperNouns2()
        {
            var utilityObj = new Utilities05();
            string data = "Eric loves football, but Andreas or Ileana does not like it.";
            string expected = "Andreas Ileana";
            var results = utilityObj.ProperNouns(data);
            Assert.AreEqual(expected, results);
        }
        [TestMethod]
        public void TestProperNouns3()
        {
            var utilityObj = new Utilities05();
            string data = "Did you know that Eric loves football, but Andreas or Ileana does not like it.";
            string expected = "Eric Andreas Ileana";
            var results = utilityObj.ProperNouns(data);
            Assert.AreEqual(expected, results);
        }
        [TestMethod]
        public void TestTableHTML()
        {
            var utilityObj = new Utilities05();
            string data = "Did you know that Eric loves football?";
            var words = data.Split(" ");
            var dict = new Dictionary<string, int>();
            for (var index = 0; index < words.Length; index++)
            {
                dict.Add(words[index], index);
            }
            string expected = "<table><tr><td>Did</td></tr><tr><td>you</td></tr><tr><td>know</td></tr><tr><td>that</td></tr><tr><td>Eric</td></tr><tr><td>loves</td></tr><tr><td>football?</td></tr></table>";
            var results = utilityObj.MakeTable(dict);
            Assert.AreEqual(expected, results);
        }
    }
}
