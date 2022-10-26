using System;
using System.Threading;

namespace KeLi.SkillPoint.Usages
{
    internal class SemaphoreUsage : IAnalyzers
    {
        private static readonly Semaphore semaphore = new(5, 15);

        public void ShowResult()
        {
            for (var i = 0; i < 10; i++)
            {
                var td = new ParameterizedThreadStart(GoBathroom);

                new Thread(td).Start($"No{i}");
            }
        }

        private static void GoBathroom(object obj)
        {
            semaphore.WaitOne();

            Console.WriteLine("{0} goes to the bathroom, the time is: {1}", obj, DateTime.Now);
            Console.WriteLine();

            Thread.Sleep(2000);
            
            Console.WriteLine("{0} goes to the bathroom, the time is: {1}", obj, DateTime.Now);
            Console.WriteLine();

            semaphore.Release();
        }
    }
}