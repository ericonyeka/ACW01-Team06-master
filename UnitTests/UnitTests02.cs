using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Utilities;

namespace UnitTests
{
    [TestClass]
    public class UnitTests02
    {
        [TestMethod]
        public void TestMethod2()
        {
            var utilityObject = new Utilities02();
            var data = 3;
            var expected = 0;
            var result = utilityObject.SampleMethod(data);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestReverseString1()
        {
            var utilityObject = new Utilities02();
            string data = "a";
            string expected = "a";
            string result = utilityObject.ReverseString(data);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestReverseString2()
        {
            var utilityObject = new Utilities02();
            string data = "abcdefghijklmnopqrstuvwxyz";
            string expected = "zyxwvutsrqponmlkjihgfedcba";
            string result = utilityObject.ReverseString(data);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestReverseString3()
        {
            var utilityObject = new Utilities02();
            string data = "HeLL0! A1B2@C/*-=! ";
            string expected = " !=-*/C@2B1A !0LLeH";
            string result = utilityObject.ReverseString(data);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestReverseString4()
        {
            var utilityObject = new Utilities02();
            string data = " ";
            string expected = " ";
            string result = utilityObject.ReverseString(data);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void TestReverseString5()
        {
            var utilityObject = new Utilities02();
            string data = "";
            string result = utilityObject.ReverseString(data);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void TestReverseString6()
        {
            var utilityObject = new Utilities02();
            string data = null;
            string result = utilityObject.ReverseString(data);
        }

        [TestMethod]
        public void TestLetterFrequencies1()
        {
            var utilityObject = new Utilities02();
            string source = "a";

            Dictionary<string, int> expected = new Dictionary<string, int>();
            expected.Add("a", 1);

            Dictionary<string, int> result = utilityObject.LetterFrequencies(source);
            CollectionAssert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestLetterFrequencies2()
        {
            var utilityObject = new Utilities02();
            string source = "AAaaa";

            Dictionary<string, int> expected = new Dictionary<string, int>();
            expected.Add("a", 5);

            Dictionary<string, int> result = utilityObject.LetterFrequencies(source);
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestLetterFrequencies3()
        {
            var utilityObject = new Utilities02();
            string source = "A1a '223##bCcdDdDd";

            Dictionary<string, int> expected = new Dictionary<string, int>();
            expected.Add("a", 2);
            expected.Add("b", 1);
            expected.Add("c", 2);
            expected.Add("d", 5);

            Dictionary<string, int> result = utilityObject.LetterFrequencies(source);
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestLetterFrequencies4()
        {
            var utilityObject = new Utilities02();
            string source = "1, 2, 3, 4, 5";

            Dictionary<string, int> expected = new Dictionary<string, int>();

            Dictionary<string, int> result = utilityObject.LetterFrequencies(source);
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestLetterFrequencies5()
        {
            var utilityObject = new Utilities02();
            string source = "That's one small step for a man, one giant leap for mankind.";

            //Adds entries not in alphabetical order, rather in the first to last occuraces e.g. 't' comes first in the quote then 'h' etc.
            Dictionary<string, int> expected = new Dictionary<string, int>()
        {
                {"t", 4},
                {"h", 1},
                {"a", 7},
                {"s", 3},
                {"o", 4},
                {"n", 6},
                {"e", 4},
                {"m", 3},
                {"l", 3},
                {"p", 2},
                {"f", 2},
                {"r", 2},
                {"g", 1},
                {"i", 2},
                {"k", 1},
                {"d", 1}
        };

            Dictionary<string, int> result = utilityObject.LetterFrequencies(source);
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void TestLetterFrequencies6()
        {
            var utilityObject = new Utilities02();
            string source = "";
            Dictionary<string, int> result = utilityObject.LetterFrequencies(source);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void TestLetterFrequencies7()
        {
            var utilityObject = new Utilities02();
            string source = null;
            Dictionary<string, int> result = utilityObject.LetterFrequencies(source);
        }

        [TestMethod]
        public void TestLineJustify1()
        {
            var utilityObject = new Utilities02();
            string source = "Hello World!";
            int lineLength = 13;
            string expected = "Hello  World!";
            string result = utilityObject.LineJustify(source, lineLength);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestLineJustify2()
        {
            var utilityObject = new Utilities02();
            string source = "It is sunny today.";
            int lineLength = 19;
            string expected = "It  is sunny today.";
            string result = utilityObject.LineJustify(source, lineLength);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestLineJustify3()
        {
            var utilityObject = new Utilities02();
            string source = "ABC  D  E    FG";
            int lineLength = 16;
            string expected = "ABC   D  E    FG";
            string result = utilityObject.LineJustify(source, lineLength);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestLineJustify4()
        {
            var utilityObject = new Utilities02();
            string source = "a b c d e f g h";
            int lineLength = 24;
            string expected = "a   b   c  d  e  f  g  h";
            string result = utilityObject.LineJustify(source, lineLength);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestLineJustify5()
        {
            var utilityObject = new Utilities02();
            string source = "If life were predictable it would cease to be life, and be without flavor.";
            int lineLength = 90;
            string expected = "If   life   were   predictable  it  would  cease  to  be  life,  and  be  without  flavor.";
            string result = utilityObject.LineJustify(source, lineLength);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestLineJustify6()
        {
            var utilityObject = new Utilities02();
            string source = "ABCDEF";
            int lineLength = 6;
            string expected = "ABCDEF";
            string result = utilityObject.LineJustify(source, lineLength);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentOutOfRangeException))]
        public void TestLineJustify7()
        {
            var utilityObject = new Utilities02();
            string source = "Hello World!";
            int lineLength = 3;
            string result = utilityObject.LineJustify(source, lineLength);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void TestLineJustify8()
        {
            var utilityObject = new Utilities02();
            string source = "";
            int lineLength = 1;
            string result = utilityObject.LineJustify(source, lineLength);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void TestLineJustify9()
        {
            var utilityObject = new Utilities02();
            string source = null;
            int lineLength = 1;
            string result = utilityObject.LineJustify(source, lineLength);
        }
        [TestMethod]
        public void TestGetBigrams1()
        {
            var utilityObject = new Utilities02();
            string source = "This is a description about the rain in Spain. The rain in Spain was very bad.";

            Dictionary<string, int> expected = new Dictionary<string, int>();
            expected.Add("the rain", 2);
            expected.Add("rain in", 2);
            expected.Add("in spain", 2);
            Dictionary<string, int> result = utilityObject.GetBigrams(source);
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestGetBigrams2()
        {
            var utilityObject = new Utilities02();
            string source = "The rain,    the rain, in spain.";
            Dictionary<string, int> expected = new Dictionary<string, int>();
            expected.Add("the rain", 2);
            Dictionary<string, int> result = utilityObject.GetBigrams(source);
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestGetBigrams3()
        {
            var utilityObject = new Utilities02();
            string source = "I...;'[] *-ju*st bOught a really fast car. My fast   /*           car can go over 200mph. I just boUght it from the CAR dealership.";
            Dictionary<string, int> expected = new Dictionary<string, int>();
            expected.Add("i just", 2);
            expected.Add("just bought", 2);
            expected.Add("fast car", 2);
            Dictionary<string, int> result = utilityObject.GetBigrams(source);
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestGetBigrams4()
        {
            var utilityObject = new Utilities02();
            string source = "Hello                   World. Hello World.";
            Dictionary<string, int> expected = new Dictionary<string, int>();
            expected.Add("hello world", 2);
            Dictionary<string, int> result = utilityObject.GetBigrams(source);
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestGetBigrams5()
        {
            var utilityObject = new Utilities02();
            string source = "Last year, I went on holiday to France. The year before I went on holiday to Florida. The year before I went on holiday to Greece. The year before that I didn't go on holiday.";
            Dictionary<string, int> expected = new Dictionary<string, int>();
            expected.Add("i went", 3);
            expected.Add("went on", 3);
            expected.Add("on holiday", 4);
            expected.Add("holiday to", 3);
            expected.Add("the year", 3);
            expected.Add("year before", 3);
            expected.Add("before i", 2);
            Dictionary<string, int> result = utilityObject.GetBigrams(source);
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void TestGetBigrams6()
        {
            var utilityObject = new Utilities02();
            string source = "";
            Dictionary<string, int> result = utilityObject.GetBigrams(source);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void TestGetBigrams7()
        {
            var utilityObject = new Utilities02();
            string source = null;
            Dictionary<string, int> result = utilityObject.GetBigrams(source);
        }

        [TestMethod]
        public void TestItalicize1()
        {
            var utilityObject = new Utilities02();
            string source = "/Hello World/ how are you doing?";
            string expected = "<em>Hello World</em> how are you doing?";
            string result = utilityObject.Italicize(source);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestItalicize2()
        {
            var utilityObject = new Utilities02();
            string source = "/Hello World /.";
            string expected = source;
            string result = utilityObject.Italicize(source);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestItalicize3()
        {
            var utilityObject = new Utilities02();
            string source = "/ Hello World/?";
            string expected = source;
            string result = utilityObject.Italicize(source);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestItalicize4()
        {
            var utilityObject = new Utilities02();
            string source = "/ Hello World /!";
            string expected = source;
            string result = utilityObject.Italicize(source);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestItalicize5()
        {
            var utilityObject = new Utilities02();
            string source = "It /is/ very /sunny/ today in /Spain/!";
            string expected = "It <em>is</em> very <em>sunny</em> today in <em>Spain</em>!";
            string result = utilityObject.Italicize(source);
            Assert.AreEqual(expected, result);
        }

       
        [TestMethod]
        public void TestItalicize6()
        {
            var utilityObject = new Utilities02();
            string source = "In /Spain/ it is very /sunny/today. Yesterday it was/raining/. The day before it was freezing/cold.";
            string expected = "In <em>Spain</em> it is very /sunny/today. Yesterday it was/raining/. The day before it was freezing/cold.";
            string result = utilityObject.Italicize(source);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestItalicize7()
        {
            var utilityObject = new Utilities02();
            string source = "/Spain/ /sunny/!";
            string expected = "<em>Spain</em> <em>sunny</em>!";
            string result = utilityObject.Italicize(source);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestItalicize8()
        {
            var utilityObject = new Utilities02();
            string source = "This /method/ will add '/em/' tags in place of '/'. It works by finding two '/' which are in the /correct/ format. It /returns/ a /string/.";
            string expected = "This <em>method</em> will add '/em/' tags in place of '/'. It works by finding two '/' which are in the <em>correct</em> format. It <em>returns</em> a <em>string</em>.";
            string result = utilityObject.Italicize(source);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestItalicize9()
        {
            var utilityObject = new Utilities02();
            string source = "///////////.";
            string expected = source;
            string result = utilityObject.Italicize(source);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void TestItalicize10()
        {
            var utilityObject = new Utilities02();
            string source = "";
            string result = utilityObject.Italicize(source);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void TestItalicize11()
        {
            var utilityObject = new Utilities02();
            string source = null;
            string result = utilityObject.Italicize(source);
        }
    }
}