using System.Diagnostics;
using System.Text.RegularExpressions;

namespace SwiftGenerator.Utility
{
    public class NumericAmount
    {
        public void GetAllowedFormat(string e)
        {
            Regex regex = new Regex("^(([1-9]\\d*)?\\d)((\\.|\\,)(\\d|\\d\\d))?$");
            if (!regex.IsMatch(e))
            {
                Debug.WriteLine(e + " - is wrong format");
            }
            else
            {
                Debug.WriteLine(e + " - Printed this");
            }
        }
    }
}