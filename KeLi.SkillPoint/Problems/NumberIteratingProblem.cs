using System;
using System.Collections.Generic;
using System.Linq;

namespace KeLi.SkillPoint.Problems
{
    internal class NumberIteratingProblem : IAnalyzers
    {
        private static int index;

        public void ShowResult()
        {
            Console.WriteLine(IterateCollectionByFor().Max());
            Console.WriteLine(IterateCollectionByDelegate().Max());
        }

        private static List<int> IterateCollectionByFor()
        {
            var results = new List<int>();
            var random = new Random();

            for (var i = 10; i-- > 0;)
                results.Add(random.Next(0, 10));

            return results;
        }

        private static List<int> IterateCollectionByDelegate()
        {
            var results = new List<int>();
            var handler = (IteratingHandler)GetNumber;

            for (var i = 0; i < 10; i++)
                results.Add(handler.Invoke(ref index));

            return results;
        }

        private static int GetNumber(ref int number)
        {
            return number++;
        }

        private delegate int IteratingHandler(ref int number);
    }
}