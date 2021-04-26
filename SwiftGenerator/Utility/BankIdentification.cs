using System;
using System.Windows.Controls;

namespace SwiftGenerator.Utility
{
    internal class BankIdentification
    {
        public Enum SetBIC(RadioButton env)
        {
            switch (env.Content.ToString())
            {
                case "ALT":
                case "FLT":
                    return Enums.Bic.CBVILT2X;

                case "ALV":
                case "FLV":
                    return Enums.Bic.UNLALV2X;

                case "AEE":
                case "FEE":
                    return Enums.Bic.EEUHEE2X;
            }
            return null;
        }
    }
}