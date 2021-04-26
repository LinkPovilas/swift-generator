using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwiftGenerator.Utility;

namespace GeneratorTests
{
    [TestClass]
    public class AmountTest
    {
        [TestMethod]
        public void TestAmount()
        {
            NumericAmount numericAmount = new NumericAmount();
            numericAmount.GetAllowedFormat("4098.09");
            numericAmount.GetAllowedFormat("0");
            numericAmount.GetAllowedFormat("380");
            numericAmount.GetAllowedFormat("0.9");
            numericAmount.GetAllowedFormat("0,9");
            //
            numericAmount.GetAllowedFormat("4,098.09");
            numericAmount.GetAllowedFormat("098.09");
            numericAmount.GetAllowedFormat("10,98.09");
            numericAmount.GetAllowedFormat("10,980456");
            numericAmount.GetAllowedFormat("0,0,0");
            numericAmount.GetAllowedFormat("0.0.0");
            numericAmount.GetAllowedFormat("0,000");
            numericAmount.GetAllowedFormat("0.000");
            numericAmount.GetAllowedFormat("0,00");
            numericAmount.GetAllowedFormat("0.00");
            numericAmount.GetAllowedFormat("000.00");
        }
    }
}