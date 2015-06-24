using System;
using NUnit.Framework;
using System.Threading;
using System.Globalization;

namespace STM.Tests
{
    [TestFixture]
    public class TestExample
    {
        [Test]
        public void EmptyTest()
        {

        }

        [Test]
        public void Translation_resurces_test()
        {
            var testStringPL = "TestString_PL";
            var testStringDefault = "TestString_DEFAULT";
            
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
            Assert.AreEqual(STM.Resources.Translations.Translation.Test_TestString, testStringDefault);

            var ci = new CultureInfo("pl");
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
            Assert.AreEqual(STM.Resources.Translations.Translation.Test_TestString, testStringPL);
        }
    }
}
