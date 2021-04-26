using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework.Internal;
using System;
using System.Diagnostics;

namespace GeneratorTests
{
    [TestClass]
    public class DateFormatTest
    {
        [TestMethod]
        public void TestDate()
        {
            //  DateFormat dateFormat = new DateFormat();

            Debug.WriteLine(DateTime.Now.ToString("yyyy-MM-dd"));
        }
    }
}