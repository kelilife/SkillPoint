using System;
using System.Collections.Generic;
using System.Linq;

namespace KeLi.SkillPoint.Tests
{
    internal class LinqQueryTest
    {
        internal static void QueryData()
        {
            var collection1 = GetNames();
            var collection2 = from n in collection1 where n.StartsWith("J") orderby n select n;
            var collection3 = collection1.Where(n => n.StartsWith("J"));
            var collection4 = collection1.FindAll(n => n.StartsWith("J"));

            collection1.Add("John");
            collection1.Add("Jim");
            collection1.Add("Jack");
            collection1.Add("Denny");

            // Can get new data.
            collection2.ToList().ForEach(Console.WriteLine);

            // Can get new data.
            collection3.ToList().ForEach(Console.WriteLine);

            // Cannot get new data.
            collection4.ToList().ForEach(Console.WriteLine);
        }

        private static List<string> GetNames()
        {
            return new List<string>
            {
                "Nino",
                "Juan",
                "Mike",
                "Phil"
            };
        }
    }
}