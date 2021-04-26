using SwiftGenerator.Utility;

namespace SwiftGenerator
{
    internal class PaymentBody
    {
        public string Create(string bic, string date, string name, string account, string amount, string ccy)
        {
            string text = new ReaderAndWriter().ReadFile(ccy);
            RandomString rnd = new RandomString();

            if (amount.Contains("."))
            {
                amount = amount.Replace(".", ",");
            }

            text = text.Replace("!BIC!", bic);
            text = text.Replace("!Random!", rnd.GetAlphaNumeric(20));
            text = text.Replace("!Date!", date);
            text = text.Replace("!Currency!", ccy);
            text = text.Replace("!Amount!", amount);
            text = text.Replace("!CreditorAccount!", account);
            text = text.Replace("!CreditorName!", name);

            return text;
        }
    }
}