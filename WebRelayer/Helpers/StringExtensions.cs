using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRelayer.Helpers
{
    public static class StringExtensions
    {
        public static string FirstCharToUpper(this string input)
        {
            switch (input)
            {
                case null:
                case "":
                    return string.Empty;
                default:
                    return input.First().ToString().ToUpper() + input.Substring(1);
            }
        }

        public static DateTime StringISO8601ToDateTime(this string input)
        {
            if(string.IsNullOrWhiteSpace(input))
            {
                return DateTime.MinValue;
            }

            return DateTime.Parse(input, null, System.Globalization.DateTimeStyles.RoundtripKind);
        }
    }
}
