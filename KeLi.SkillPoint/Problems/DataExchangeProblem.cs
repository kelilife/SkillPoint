namespace KeLi.SkillPoint.Problems
{
    internal class DataExchangeProblem : IAnalyzers
    {
        public void ShowResult()
        {
            var number1 = 10;
            var number2 = 20;

            SwapDataByCoordinate(ref number1, ref number2);

            var number3 = 30;
            var number4 = 40;

            SwapDataByPosition(ref number3, ref number4);
        }

        internal static void SwapDataByCoordinate(ref int number1, ref int number2)
        {
            number1 = number2 - number1;
            number2 -= number1;
            number1 = number2 + number1;
        }

        internal static void SwapDataByPosition(ref int number1, ref int number2)
        {
            number1 ^= number2;
            number2 = number1 ^ number2;
            number1 ^= number2;
        }
    }
}