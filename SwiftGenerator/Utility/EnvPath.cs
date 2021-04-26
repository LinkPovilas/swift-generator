namespace SwiftGenerator.Utility
{
    internal class EnvPath
    {
        public string GetNetPath(string env)
        {
            switch (env)
            {
                case "ALT":
                    return @"\\links.alt\sebsfiles\swift\in";

                case "ALV":
                    return @"\\links.alv\sebsfiles\swift\in";

                case "AEE":
                    return @"\\links.aee\swift\in";

                case "FLT":
                    return @"\\links.flt\sebsfiles\swift\in";

                case "FLV":
                    return @"\\links.flv\swift\in";

                case "FEE":
                    return @"\\links.fee\swift\in";
            }
            return null;
        }
    }
}