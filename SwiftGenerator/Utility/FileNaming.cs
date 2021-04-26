using System;

namespace SwiftGenerator.Utility
{
    internal class FileNaming
    {
        public string GetName(int count, Boolean moreThanOnce)
        {
            string str = "" + count;
            const string padding = "000";
            string numCount = "";

            if (moreThanOnce)
            {
                numCount = "-" + padding.Substring(0, padding.Length - str.Length) + str;
            }
            return numCount;
        }
    }
}