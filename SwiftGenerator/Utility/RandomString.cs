using System;

namespace SwiftGenerator.Utility
{
    internal class RandomString
    {
        public string GetAlphaNumeric(int size)
        {
            string guidString = Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Substring(0, size);
            return guidString.Replace("=", "").Replace("+", "").Replace("/", "");
        }
    }
}