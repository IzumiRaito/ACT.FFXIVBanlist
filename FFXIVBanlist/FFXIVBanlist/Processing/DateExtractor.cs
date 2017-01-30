using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FFXIVBanlist.Processing
{
    public class DateExtractor
    {
        string dateRegexString = "[[].+?[]]";

        public string GetCurrentDate(string line)
        {
            Regex regex = new Regex(dateRegexString, RegexOptions.IgnoreCase);
            Match match = regex.Match(line);
            string dateWithBrackets = match.Groups[0].Value;
            return dateWithBrackets.Substring(1, dateWithBrackets.Length-2);
        }

        public string RemoveDate(string line)
        {
            int spaceIndex = line.IndexOf(' ');
            return line.Substring(spaceIndex + 1);
        }
    }
}
