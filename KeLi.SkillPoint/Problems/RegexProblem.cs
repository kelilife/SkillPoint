using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace KeLi.SkillPoint.Problems
{
    internal class RegexProblem : IAnalyzers
    {
        public void ShowResult()
        {
            MatchNumbers("333abc");
            ContainsBirthday("19221123");
        }

        internal static List<int> MatchNumbers(string text)
        {
            return Regex.Matches(text, @"\d+").Cast<Match>().Select(s => int.Parse(s.Value)).ToList();
        }

        internal static bool ContainsBirthday(string password)
        {
            var regex1 = new Regex(@"\d{4}");
            var regex2 = new Regex(@"\d{3}");
            var regex3 = new Regex(@"\d{2}");
            var flag1 = regex1.IsMatch(password) && !regex1.Match(password).Value.Contains("000");
            var flag2 = regex2.IsMatch(password) && !regex2.Match(password).Value.Contains("00");
            var flag3 = regex3.IsMatch(password) && !regex3.Match(password).Value.Contains("0");

            return flag1 || flag2 || flag3;
        }
    }
}