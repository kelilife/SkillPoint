using System;

namespace KeLi.SkillPoint.Tests
{
    internal class OperationPriorityTest : IAnalyzers
    {
        public void ShowResult()
        {
            Console.WriteLine("(int)1.1 / 1.0 = {0}", (int)1.1 / 1.1);
            Console.WriteLine();
        }
    }
}