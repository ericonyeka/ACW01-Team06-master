using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Utilities;

namespace UnitTests
{
    [TestClass]
    public class UnitTests03
    {
        /*[TestMethod]
        public void TestMethod1()
        {
            Utilities01 utilityObject = new Utilities01();
            var expected = 0;
            var result = utilityObject;
            Assert.AreEqual(expected, result);
        }*/

        private string testData04 = "Turning once again, and this time more generally, to the question of invasion, I would observe that there has never been a period in all these long centuries of which we boast when an absolute guarantee against invasion, still less against serious raids, could have been given to our people. In the days of Napoleon, of which I was speaking just now, the same wind which would have carried his transports across the Channel might have driven away the blockading fleet. There was always the chance, and it is that chance which has excited and befooled the imaginations of many Continental tyrants. Many are the tales that are told. We are assured that novel methods will be adopted, and when we see the originality of malice, the ingenuity of aggression, which our enemy displays, we may certainly prepare ourselves for every kind of novel stratagem and every kind of brutal and treacherous manœuvre. I think that no idea is so outlandish that it should not be considered and viewed with a searching, but at the same time, I hope, with a steady eye. We must never forget the solid assurances of sea power and those which belong to air power if it can be locally exercised.  " +
                "Sir, I have, myself, full confidence that if all do their duty, if nothing is neglected, and if the best arrangements are made, as they are being made, we shall prove ourselves once more able to defend our island home, to ride out the storm of war, and to outlive the menace of tyranny, if necessary for years, if necessary alone.At any rate, that is what we are going to try to do. That is the resolve of His Majesty's Government – every man of them. That is the will of Parliament and the nation. The British Empire and the French Republic, linked together in their cause and in their need, will defend to the death their native soil, aiding each other like good comrades to the utmost of their strength.  " +
                "Even though large tracts of Europe and many old and famous States have fallen or may fall into the grip of the Gestapo and all the odious apparatus of Nazi rule, we shall not flag or fail. We shall go on to the end.We shall fight in France, we shall fight on the seas and oceans, we shall fight with growing confidence and growing strength in the air, we shall defend our island, whatever the cost may be.We shall fight on the beaches, we shall fight on the landing grounds, we shall fight in the fields and in the streets, we shall fight in the hills; we shall never surrender, and if, which I do not for a moment believe, this island or a large part of it were subjugated and starving, then our Empire beyond the seas, armed and guarded by the British Fleet, would carry on the struggle, until, in God's good time, the New World, with all its power and might, steps forth to the rescue and the liberation of the old.";


        [TestMethod]
        public void SortWordsTest1()
        {
            Utilities03 utilityObject = new Utilities03();
            string testString = "The rain in Spain falls mainly in the plain, though often there is also preciptiation in the mountains.";
            string result = utilityObject.SortWords(testString);
            string expected = "also falls in in in is mainly mountains often plain preciptiation rain Spain The the the there though";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void SortWordsTest2()
        {
            Utilities03 utilityObject = new Utilities03();
            string testString = "";
            string result = utilityObject.SortWords(testString);
            string expected = "";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void SortWordsTest3()
        {
            Utilities03 utilityObject = new Utilities03();
            string testString = "My brother Esau was an hairy man";
            string result = utilityObject.SortWords(testString);
            string expected = "an brother Esau hairy man My was";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void SortWordsTest4()
        {
            Utilities03 utilityObject = new Utilities03();
            string testString = null;
            string result = utilityObject.SortWords(testString);
            string expected = null;
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void SortWordsTest5()// ' tested
        {
            Utilities03 utilityObject = new Utilities03();
            string testString = "My brother Esau was an hairy man as I'm.";
            string result = utilityObject.SortWords(testString);
            string expected = "an as brother Esau hairy I'm man My was";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void SortWordsTest6()
        {
            Utilities03 utilityObject = new Utilities03();
            string testString = "My brother Esau-7 was an hairy man as I'm.";
            string result = utilityObject.SortWords(testString);
            string expected = "an as brother Esau hairy I'm man My was";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void SortWordsTest7()
        {
            Utilities03 utilityObject = new Utilities03();
            string testString = "My brother Esau*-7 was an hairy man as I'm.";
            string result = utilityObject.SortWords(testString);
            string expected = "an as brother Esau hairy I'm man My was";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void SentencesTest1()
        {
            Utilities03 utilityObject = new Utilities03();
            string testString = "Turning once again, and this time more generally, to the question of invasion, I would observe that there has never been a period in all these long centuries of which we boast when an absolute guarantee against invasion, still less against serious raids, could have been given to our people. In the days of Napoleon, of which I was speaking just now, the same wind which would have carried his transports across the Channel might have driven away the blockading fleet. There was always the chance, and it is that chance which has excited and befooled the imaginations of many Continental tyrants. ";
            List<string> result = utilityObject.Sentences(testString);
            List<string> expected = new List<string>() { "Turning once again, and this time more generally, to the question of invasion, I would observe that there has never been a period in all these long centuries of which we boast when an absolute guarantee against invasion, still less against serious raids, could have been given to our people.", "In the days of Napoleon, of which I was speaking just now, the same wind which would have carried his transports across the Channel might have driven away the blockading fleet.", "There was always the chance, and it is that chance which has excited and befooled the imaginations of many Continental tyrants." };
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void SentencesTest2()
        {
            Utilities03 utilityObject = new Utilities03();
            string testString = "Turning once again, and this time more generally, to the question of invasion, I would observe that there has never been a period in all these long centuries of which we boast when an absolute guarantee against invasion, still less against serious raids, could have been given to our people. in the days of Napoleon, of which I was speaking just now, the same wind which would have carried his transports across the Channel might have driven away the blockading fleet. There was always the chance, and it is that chance which has excited and befooled the imaginations of many Continental tyrants. ";
            List<string> result = utilityObject.Sentences(testString);
            List<string> expected = new List<string>() { "Turning once again, and this time more generally, to the question of invasion, I would observe that there has never been a period in all these long centuries of which we boast when an absolute guarantee against invasion, still less against serious raids, could have been given to our people.",  "There was always the chance, and it is that chance which has excited and befooled the imaginations of many Continental tyrants." };
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void SentencesTest3()
        {
            Utilities03 utilityObject = new Utilities03();
            string testString = "asdasd";
            List<string> result = utilityObject.Sentences(testString);
            List<string> expected = null;
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void SentencesTest4()
        {
            Utilities03 utilityObject = new Utilities03();
            string testString = "Asdasd";
            List<string> result = utilityObject.Sentences(testString);
            List<string> expected = null;
            CollectionAssert.AreEqual(expected, result); //A1a '223##bCcdDdDd
        }

        [TestMethod]
        public void SentencesTest5()
        {
            Utilities03 utilityObject = new Utilities03();
            string testString = "A1a '223##bCcdDdDd";
            List<string> result = utilityObject.Sentences(testString);
            List<string> expected = null;
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void SentencesTest6()
        {
            Utilities03 utilityObject = new Utilities03();
            string testString = "Asdasd.";
            List<string> result = utilityObject.Sentences(testString);
            List<string> expected = new List<string>() {"Asdasd." };
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void SentencesTest7()
        {
            Utilities03 utilityObject = new Utilities03();
            string testString = "sdasd.";
            List<string> result = utilityObject.Sentences(testString);
            List<string> expected = null;
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void WordLengthTest1()
        {
            Utilities03 utilityObject = new Utilities03();
            string testString = "The rain in Spain falls mainly in the plain.";
            Dictionary<int, int> result = utilityObject.WordLengths(testString);
            Dictionary<int, int> expected = new Dictionary<int, int>() { { 2, 2 }, { 3, 2 }, { 4, 1 }, { 5, 3 }, { 6, 1 } };
            CollectionAssert.AreEquivalent(expected, result);
        }

        [TestMethod]
        public void WordLengthTest2()
        {
            Utilities03 utilityObject = new Utilities03();
            string testString = "The.";
            Dictionary<int, int> result = utilityObject.WordLengths(testString);
            Dictionary<int, int> expected = new Dictionary<int, int>() { {3,1 } };
            CollectionAssert.AreEquivalent(expected, result);
        }
        
        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void WordLengthTest3()
        {
            Utilities03 utilityObject = new Utilities03();
            string testString = "";
            Dictionary<int, int> result = utilityObject.WordLengths(testString);
            Dictionary<int, int> expected = new Dictionary<int, int>() {};
            CollectionAssert.AreEquivalent(expected, result);
        }

        [TestMethod]
        public void AddHeadingsTest1()
        {
            Utilities03 utilityObject = new Utilities03();
            string testString = "asdasdasdas\nnagyyal\n====";
            string result = utilityObject.AddHeadings(testString);
            string expected = "asdasdasdas\n<h2>nagyyal</h2>";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void AddHeadingsTest2()
        {
            Utilities03 utilityObject = new Utilities03();
            string testString = "";
            string result = utilityObject.AddHeadings(testString);
            string expected = "";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void AddHeadingsTest3()//can handle empty line?
        {
            Utilities03 utilityObject = new Utilities03();
            string testString = "asdasdasdas\nnagyyal\n====\n\nasdasd";
            string result = utilityObject.AddHeadings(testString);
            string expected = "asdasdasdas\n<h2>nagyyal</h2>\n\nasdasd";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void AddHeadingsTest4()//nothing change
        {
            Utilities03 utilityObject = new Utilities03();
            string testString = "asdasdasdas\nnagyyal\nasdasd";
            string result = utilityObject.AddHeadings(testString);
            string expected = "asdasdasdas\nnagyyal\nasdasd";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void AddHeadingsTest5()//no lines
        {
            Utilities03 utilityObject = new Utilities03();
            string testString = "asdasdasdas nagyyal asdasd";
            string result = utilityObject.AddHeadings(testString);
            string expected = "asdasdasdas nagyyal asdasd";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetSentimenTest1()
        {
            Utilities03 utilityObject = new Utilities03();
            string testString = "I'm very happy!";
            string testGoodWordsString = "happy big";
            string testBadWordsString = "sad small";
            double result = utilityObject.GetSentiment(testString, testGoodWordsString, testBadWordsString);
            double expected = 1;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetSentimenTest2()
        {
            Utilities03 utilityObject = new Utilities03();
            string testString = "I'm very happy small!";
            string testGoodWordsString = "happy big";
            string testBadWordsString = "sad small";
            double result = utilityObject.GetSentiment(testString, testGoodWordsString, testBadWordsString);
            double expected = 0;
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void GetSentimenTest3()//testing with only bad words
        {
            Utilities03 utilityObject = new Utilities03();
            string testString = "I'm very sad sad small boy!";
            string testGoodWordsString = "happy big";
            string testBadWordsString = "sad small";
            double result = utilityObject.GetSentiment(testString, testGoodWordsString, testBadWordsString);
            double expected = -1;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetSentimenTest4()//no special words
        {
            Utilities03 utilityObject = new Utilities03();
            string testString = "I'm very nothing!";
            string testGoodWordsString = "happy big";
            string testBadWordsString = "sad small";
            double result = utilityObject.GetSentiment(testString, testGoodWordsString, testBadWordsString);
            double expected = 0;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void GetSentimenTest5()
        {
            Utilities03 utilityObject = new Utilities03();
            string testString = "";
            string testGoodWordsString = "";
            string testBadWordsString = "";
            double result = utilityObject.GetSentiment(testString, testGoodWordsString, testBadWordsString);
            double expected = 0;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetSentimenTest6()//testing with a long string which has no word in it
        {
            Utilities03 utilityObject = new Utilities03();
            string testString = testData04;
            string testGoodWordsString = "happy big";
            string testBadWordsString = "sad small";
            double result = utilityObject.GetSentiment(testString, testGoodWordsString, testBadWordsString);
            double expected = 0;
            Assert.AreEqual(expected, result);
        }
    }
}
