using System;

using KeLi.SkillPoint.Usages;

namespace KeLi.SkillPoint
{
    internal class Program
    {
        internal static void Main()
        {
            Console.Title = nameof(SkillPoint);
            Console.WindowWidth = 100;
            Console.WindowHeight = 25;

            try
            {
                new EventUsage().ShowResult();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.ReadKey();
        }
    }
}