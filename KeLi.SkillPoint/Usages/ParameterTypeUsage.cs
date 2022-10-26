using System;

namespace KeLi.SkillPoint.Usages
{
    internal class ParameterTypeUsage : IAnalyzers
    {
        public void ShowResult()
        {
            var number1 = 1;
            var number2 = 2;

            SwapNumberByRef(ref number1, ref number2);
            SwapNumberByOut(out number1, out number2);

            ShowInputParameters<object>(1, 3, 2, 5);
        }

        private static void SwapNumberByRef(ref int number1, ref int number2)
        {
            var tempNumber = number1;

            number1 = number2;
            number2 = tempNumber;
        }

        private static void SwapNumberByOut(out int number1, out int number2)
        {
            number1 = 5;
            number2 = 3;

            var tempNumber = number1;

            number1 = number2;
            number2 = tempNumber;
        }

        private static void ShowInputParameters<T>(params T[] parameters)
        {
            if (parameters is null)
                return;

            if (parameters.Length <= 0)
                return;

            foreach (var parameter in parameters)
                Console.Write(parameter + " ");
        }
    }
}