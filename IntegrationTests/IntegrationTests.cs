using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiUtility;
using System;
using System.Runtime.InteropServices.ComTypes;
using Utilities;

namespace IntegrationTests
{
    // Students must not edit this file

    [TestClass]
    public class IntegrationTests
    {

        private ExtraUtilities testObject;
        private string testData01 = "The rain in Spain falls mainly in the plain.";
        private string testData02 = "The rain in Spain falls mainly in the plain, though often there is also preciptiation in the mountains.";
        private string testData03 = "Even if cases are brought under control today, deaths would be expected to rise for another month due to the time between when some somebody is infected, when they need hospital care and when they die.";
        private string testData04 = "Turning once again, and this time more generally, to the question of invasion, I would observe that there has never been a period in all these long centuries of which we boast when an absolute guarantee against invasion, still less against serious raids, could have been given to our people. In the days of Napoleon, of which I was speaking just now, the same wind which would have carried his transports across the Channel might have driven away the blockading fleet. There was always the chance, and it is that chance which has excited and befooled the imaginations of many Continental tyrants. Many are the tales that are told. We are assured that novel methods will be adopted, and when we see the originality of malice, the ingenuity of aggression, which our enemy displays, we may certainly prepare ourselves for every kind of novel stratagem and every kind of brutal and treacherous manœuvre. I think that no idea is so outlandish that it should not be considered and viewed with a searching, but at the same time, I hope, with a steady eye. We must never forget the solid assurances of sea power and those which belong to air power if it can be locally exercised.  " +
                "Sir, I have, myself, full confidence that if all do their duty, if nothing is neglected, and if the best arrangements are made, as they are being made, we shall prove ourselves once more able to defend our island home, to ride out the storm of war, and to outlive the menace of tyranny, if necessary for years, if necessary alone.At any rate, that is what we are going to try to do. That is the resolve of His Majesty's Government – every man of them. That is the will of Parliament and the nation. The British Empire and the French Republic, linked together in their cause and in their need, will defend to the death their native soil, aiding each other like good comrades to the utmost of their strength.  " +
                "Even though large tracts of Europe and many old and famous States have fallen or may fall into the grip of the Gestapo and all the odious apparatus of Nazi rule, we shall not flag or fail. We shall go on to the end.We shall fight in France, we shall fight on the seas and oceans, we shall fight with growing confidence and growing strength in the air, we shall defend our island, whatever the cost may be.We shall fight on the beaches, we shall fight on the landing grounds, we shall fight in the fields and in the streets, we shall fight in the hills; we shall never surrender, and if, which I do not for a moment believe, this island or a large part of it were subjugated and starving, then our Empire beyond the seas, armed and guarded by the British Fleet, would carry on the struggle, until, in God's good time, the New World, with all its power and might, steps forth to the rescue and the liberation of the old.";
        private string testData05 = "It is further against us that we are not, in the strictest sense, specialists in the fields which came primarily to be concerned. As a geologist my object in leading the Miskatonic University Expedition was wholly that of securing deep-level specimens of rock and soil from various parts of the antarctic continent, aided by the remarkable drill devised by Prof. Frank H. Pabodie of our engineering department. I had no wish to be a pioneer in any other field than this; but I did hope that the use of this new mechanical appliance at different points along previously explored paths would bring to light materials of a sort hitherto unreached by the ordinary methods of collection. Pabodie’s drilling apparatus, as the public already knows from our reports, was unique and radical in its lightness, portability, and capacity to combine the ordinary artesian drill principle with the principle of the small circular rock drill in such a way as to cope quickly with strata of varying hardness. Steel head, jointed rods, gasoline motor, collapsible wooden derrick, dynamiting paraphernalia, cording, rubbish-removal auger, and sectional piping for bores five inches wide and up to 1000 feet deep all formed, with needed accessories, no greater load than three seven-dog sledges could carry; this being made possible by the clever aluminum alloy of which most of the metal objects were fashioned. Four large Dornier aëroplanes, designed especially for the tremendous altitude flying necessary on the antarctic plateau and with added fuel-warming and quick-starting devices worked out by Pabodie, could transport our entire expedition from a base at the edge of the great ice barrier to various suitable inland points, and from these points a sufficient quota of dogs would serve us.";
        private string testData06 = "My brother Esau was an hairy man";

        public IntegrationTests()
        {
            testObject = new ExtraUtilities();
        }

        [TestMethod]
        public void TestSortWords01()
        {
            var source = testData06;
            var expected = "an brother Esau hairy man My was";
            var subTestObject = new Utilities03();
            var result = subTestObject.SortWords(source);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestReverseSortWords01()
        {
            var source = testData06;
            var expected = "was My man hairy Esau brother an";
            var result = testObject.ReverseSortWords(source);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestGetNthSentence01()
        {
            var source = testData05;
            var expected = "As a geologist my object in leading the Miskatonic University Expedition was wholly that of securing deep-level specimens of rock and soil from various parts of the antarctic continent, aided by the remarkable drill devised by Prof.";
            var result = testObject.GetNthSentence(source,2);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestGetNthSentence02()
        {
            var source = testData01;
            var result = testObject.GetNthSentence(source,5);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void TestGetNthSentence03()
        {
            var source = testData04;
            var expected = "There was always the chance, and it is that chance which has excited and befooled the imaginations of many Continental tyrants.";
            var result = testObject.GetNthSentence(source,3);
            Assert.AreEqual(expected,result);
        }

        [TestMethod]
        public void TestGetNthSentence04()
        {
            var source = testData04;
            var expected = "In the days of Napoleon, of which I was speaking just now, the same wind which would have carried his transports across the Channel might have driven away the blockading fleet.";
            var result = testObject.GetNthSentence(source, 2);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestGetNthLine01()
        {
            var source = testData04;
            var expected = "question of";
            var result = testObject.GetNthLine(source, 20, 3);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestGetNthLine02()
        {
            var source = testData04;
            var expected = "absolute guarantee against invasion,";
            var result = testObject.GetNthLine(source, 40, 5);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestHighlightCommonWords01()
        {
            var source = testData04;
            var expected = "Turning once again, <b>and</b> this time more generally, to <b>the</b> question <b>of</b> invasion, I would observe that there has never been a period in all these long centuries <b>of</b> which <b>we</b> boast when an absolute guarantee against invasion, still less against serious raids, could have been given to our people. In <b>the</b> days <b>of</b> Napoleon, <b>of</b> which I was speaking just now, <b>the</b> same wind which would have carried his transports across <b>the</b> Channel might have driven away <b>the</b> blockading fleet. There was always <b>the</b> chance, <b>and</b> it is that chance which has excited <b>and</b> befooled <b>the</b> imaginations <b>of</b> many Continental tyrants. Many are <b>the</b> tales that are told. <b>We</b> are assured that novel methods will be adopted, <b>and</b> when <b>we</b> see <b>the</b> originality <b>of</b> malice, <b>the</b> ingenuity <b>of</b> aggression, which our enemy displays, <b>we</b> may certainly prepare ourselves for every kind <b>of</b> novel stratagem <b>and</b> every kind <b>of</b> brutal <b>and</b> treacherous manœuvre. I think that no idea is so outlandish that it should not be considered <b>and</b> viewed with a searching, but at <b>the</b> same time, I hope, with a steady eye. <b>We</b> must never forget <b>the</b> solid assurances <b>of</b> sea power <b>and</b> those which belong to air power if it can be locally exercised.  Sir, I have, myself, full confidence that if all do their duty, if nothing is neglected, <b>and</b> if <b>the</b> best arrangements are made, as they are being made, <b>we</b> shall prove ourselves once more able to defend our island home, to ride out <b>the</b> storm <b>of</b> war, <b>and</b> to outlive <b>the</b> menace <b>of</b> tyranny, if necessary for years, if necessary alone.At any rate, that is what <b>we</b> are going to try to do. That is <b>the</b> resolve <b>of</b> His Majesty's Government – every man <b>of</b> them. That is <b>the</b> will <b>of</b> Parliament <b>and</b> <b>the</b> nation. <b>The</b> British Empire <b>and</b> <b>the</b> French Republic, linked together in their cause <b>and</b> in their need, will defend to <b>the</b> death their native soil, aiding each other like good comrades to <b>the</b> utmost <b>of</b> their strength.  Even though large tracts <b>of</b> Europe <b>and</b> many old <b>and</b> famous States have fallen or may fall into <b>the</b> grip <b>of</b> <b>the</b> Gestapo <b>and</b> all <b>the</b> odious apparatus <b>of</b> Nazi rule, <b>we</b> shall not flag or fail. <b>We</b> shall go on to <b>the</b> end.We shall fight in France, <b>we</b> shall fight on <b>the</b> seas <b>and</b> oceans, <b>we</b> shall fight with growing confidence <b>and</b> growing strength in <b>the</b> air, <b>we</b> shall defend our island, whatever <b>the</b> cost may be.We shall fight on <b>the</b> beaches, <b>we</b> shall fight on <b>the</b> landing grounds, <b>we</b> shall fight in <b>the</b> fields <b>and</b> in <b>the</b> streets, <b>we</b> shall fight in <b>the</b> hills; <b>we</b> shall never surrender, <b>and</b> if, which I do not for a moment believe, this island or a large part <b>of</b> it were subjugated <b>and</b> starving, then our Empire beyond <b>the</b> seas, armed <b>and</b> guarded by <b>the</b> British Fleet, would carry on <b>the</b> struggle, until, in God's good time, <b>the</b> New World, with all its power <b>and</b> might, steps forth to <b>the</b> rescue <b>and</b> <b>the</b> liberation <b>of</b> <b>the</b> old.";
            var result  = testObject.HighlightTopWords(source, 4);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestCheckComplexity01()
        {
            var source = testData04;
            var expected = 731.3;
            var result = Math.Round((double) testObject.CheckComplexity(source),1);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestJustification01()
        {
            var source = testData05;
            var lineLength = 30;
            var expected = "It  is further against us that|we  are  not, in the strictest|sense,   specialists   in  the|fields which came primarily to|be  concerned.  As a geologist|my   object   in  leading  the|Miskatonic          University|Expedition  was wholly that of|securing  deep-level specimens|of  rock and soil from various|parts    of    the   antarctic|continent,    aided   by   the|remarkable  drill  devised  by|Prof.  Frank H. Pabodie of our|engineering  department. I had|no wish to be a pioneer in any|other  field  than this; but I|did  hope that the use of this|new  mechanical  appliance  at|different     points     along|previously    explored   paths|would bring to light materials|of  a  sort hitherto unreached|by  the  ordinary  methods  of|collection. Pabodie’s drilling|apparatus,   as   the   public|already    knows    from   our|reports,    was   unique   and|radical   in   its  lightness,|portability,  and  capacity to|combine  the ordinary artesian|drill   principle   with   the|principle    of    the   small|circular  rock drill in such a|way  as  to  cope quickly with|strata  of  varying  hardness.|Steel   head,   jointed  rods,|gasoline   motor,  collapsible|wooden   derrick,   dynamiting|paraphernalia,        cording,|rubbish-removal   auger,   and|sectional   piping  for  bores|five  inches  wide  and  up to|1000  feet  deep  all  formed,|with  needed  accessories,  no|greater    load   than   three|seven-dog sledges could carry;|this  being  made  possible by|the  clever  aluminum alloy of|which   most   of   the  metal|objects  were  fashioned. Four|large    Dornier   aëroplanes,|designed  especially  for  the|tremendous   altitude   flying|necessary   on  the  antarctic|plateau    and    with   added|fuel-warming               and|quick-starting  devices worked|out    by    Pabodie,    could|transport      our      entire|expedition  from a base at the|edge  of the great ice barrier|to   various  suitable  inland|points,  and from these points|a  sufficient  quota  of  dogs|would         serve        us.";
            var result = testObject.GetJustifiedText(source, lineLength);
            Assert.AreEqual(expected, result);
        }



    }
}
