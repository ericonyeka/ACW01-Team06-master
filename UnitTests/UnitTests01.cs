using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Utilities;

namespace UnitTests
{
    [TestClass]
    public class UnitTests01
    {
        [TestMethod]
        public void RemovePunctuationTest01()
        {
            Utilities01 TestData = new Utilities01();
            string Result = TestData.RemovePunctuation("The Eject Button (Japanese: Break-Out Button) " +
                "is a type of consumable held item introduced in Generation V. " +
                "It switches out the holder if it is hit by a damaging move.");
            Assert.AreEqual("The Eject Button Japanese BreakOut Button is a type of consumable held item" +
                " introduced in Generation V It switches out the holder if it is hit by a damaging move", Result);//expected vs actual
        }//Passed
        [TestMethod]
        public void RemovePunctuationTest02()
        {
            Utilities01 TestData = new Utilities01();
            string Result = TestData.RemovePunctuation("It isn't so bad, is it?");
            Assert.AreEqual("It isnt so bad is it", Result);//expected vs actual
        }//Passed

        [TestMethod]
        public void TextLinedTest01()
        {
            Utilities01 TestData = new Utilities01();
            string Result = TestData.Textlined("the quick brown fox jumps over the lazy dog", 17);
            Assert.AreEqual("the quick brown f\nox jumps over the\n lazy dog", Result);
        }//pass
        [TestMethod]
        public void TextLinedTest02()
        {
            Utilities01 TestData = new Utilities01();
            string Result = TestData.Textlined("the quick brown fox jumps over the lazy dog", 6);
            Assert.AreEqual("", Result);
        }//Pass
        [TestMethod]
        public void TextLinedTest03()
        {
            Utilities01 TestData = new Utilities01();
            string Result = TestData.Textlined("the quick brown fox jumps over the lazy dog", -7);
            Assert.AreEqual("", Result);
        }//Pass

        [TestMethod]
        public void EmboldenWordsTest01()
        {
            Utilities01 TestData = new Utilities01();
            string Result = TestData.EmboldenWords("I think therefore I am", "I");
            Assert.AreEqual("<b>I</b> think therefore <b>I</b> am", Result);
        }//Pass
        [TestMethod]
        public void EmboldenWordsTest02()
        {
            Utilities01 TestData = new Utilities01();
            string Result = TestData.EmboldenWords("Danny, please can you come up with sentence that has a variety of punctuation?", "danny punctuation" );
            Assert.AreEqual("<b>Danny</b>, please can you come up with sentence that has a variety of <b>punctuation</b>?", Result);
        }//Pass
        [TestMethod]
        public void EmboldenWordsTest03()
        {
            Utilities01 TestData = new Utilities01();
            string Result = TestData.EmboldenWords("I wasn't sure you heard me.", "wasn't");
            Assert.AreEqual("I <b>wasn't</b> sure you heard me.", Result);
        }//Pass
        

        [TestMethod]
        public void WordFrequenciesTest01()
        {
            Utilities01 TestData = new Utilities01();
            Dictionary<string,int> Result = TestData.WordFrequencies("random words in front of other random words create a random sentence");
            string[,] Expected = new string[,]{ {"random", "3" }, { "words", "2" }, { "in", "1" }, { "front", "1" }, { "of", "1" }, { "other", "1" }, { "create", "1" }, { "a", "1" }, { "sentence", "1" } };
            for (int i = 0; i < Expected.GetLength(0); i++)
            {
                int found;
                Result.TryGetValue(Expected[i, 0], out found);
                Assert.IsTrue(found == int.Parse(Expected[i,1]));
            }
        }//pass
        [TestMethod]
        public void WordFrequenciesTest02()
        {
            Utilities01 TestData = new Utilities01();
            Dictionary<string, int> Result = TestData.WordFrequencies("Random words in front of other random words create a random sentence.");
            string[,] Expected = new string[,] { { "random", "3" }, { "words", "2" }, { "in", "1" }, { "front", "1" }, { "of", "1" }, { "other", "1" }, { "create", "1" }, { "a", "1" }, { "sentence", "1" } };
            for (int i = 0; i < Expected.GetLength(0); i++)
            {
                int found;
                Result.TryGetValue(Expected[i, 0], out found);
                Assert.IsTrue(found == int.Parse(Expected[i, 1]));
            }
        }//pass
        [TestMethod]
        public void WordFrequenciesTest03()
        {
            Utilities01 TestData = new Utilities01();
            Dictionary<string, int> Result = TestData.WordFrequencies("The Lion, The Witch and The Wardrobe.");
            string[,] Expected = new string[,] { { "the", "3" }, { "lion", "1" }, { "witch", "1" }, { "and", "1" }, { "wardrobe", "1" }};
            for (int i = 0; i < Expected.GetLength(0); i++)
            {
                int found;
                Result.TryGetValue(Expected[i, 0], out found);
                Assert.IsTrue(found == int.Parse(Expected[i, 1]));
            }
        }

        [TestMethod]
        public void GetComplexityTest01()
        {
            Utilities01 TestData = new Utilities01();
            double Result = TestData.GetComplexity("Random words in front of other random words create a random sentence");
            Assert.AreEqual(56, Result);
        }//pass
        [TestMethod]
        public void GetComplexityTest02()
        {
            Utilities01 TestData = new Utilities01();
            double Result = TestData.GetComplexity("Random words in front of other random words create a random sentence. " +
                "He had decided to accept his fate of accepting his fate. The irony of the situation wasn't lost on anyone in the room.");
            Assert.AreEqual(50, Result);//pass
        }//188 characters //35 words // 3 sentences //34 spaces //4 punctuation // average word length 150/35 //sentence length 35/3
        [TestMethod]
        public void GetComplexityTest03()
        {
            Utilities01 TestData = new Utilities01();
            double Result = TestData.GetComplexity("Where are you? And I'm so sorry. I cannot sleep, I cannot dream tonight.");
            Assert.AreEqual(18, Result);//pass
        }
        [TestMethod]
        public void GetComplexityTest04()
        {
            Utilities01 TestData = new Utilities01();
            double Result = TestData.GetComplexity("I don't know… I'm not sure. What should I do?");
            Assert.AreEqual(15.5, Result);//pass
        }
    }
}
