using System;

namespace KeLi.SkillPoint.Problems
{
    internal class NumberPyramidProblem : IAnalyzers
    {
        public void ShowResult()
        {
            Console.Write("Please input number: ");

            var input = Console.ReadLine();
            var results = GetNumberLines(input);

            if (results.Length == 0)
                return;

            foreach (var result in results)
                Console.WriteLine(result);
        }

        private static string[] GetNumberLines(string inputNumber)
        {
            var results = default(string[]);

            if (int.TryParse(inputNumber, out var number) && number <= 30)
            {
                number += 1;
                results = new string[number];

                for (var i = 0; i < number; i++)
                {
                    var tempNumber = string.Empty;
                    var tempSpace = string.Empty;

                    for (var j = 0; j < i; j++)
                        tempNumber += $"{i,2} ";

                    for (var j = 0; j < number - i; j++)
                        tempSpace += "   ";

                    results[i] = tempSpace + tempNumber + $"{i,2} " + tempNumber + tempSpace;
                }
            }

            else
                results = Array.Empty<string>();

            return results;
        }
    }
}