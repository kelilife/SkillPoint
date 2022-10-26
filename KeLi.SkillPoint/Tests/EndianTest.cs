using System;
using System.Linq;

namespace KeLi.SkillPoint.Tests
{
    internal class EndianTest
    {
        public void ShowResult()
        {
            var result = string.Empty;

            if (BitConverter.GetBytes(0x1020).First() != 0x10)
                result = "LittleEndian";

            else
                result = "BigEndian";

            Console.WriteLine(result);
            Console.WriteLine();
        }
    }
}