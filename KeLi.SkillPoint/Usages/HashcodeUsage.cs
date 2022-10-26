using System;
using System.Collections.Generic;

namespace KeLi.SkillPoint.Usages
{
    internal class HashcodeUsage : IAnalyzers
    {
        public void ShowResult()
        {
            const int number = 123456789;

            var point1 = new Point(1, 2);
            var point2 = new Point(1, 4);
            var dict = new Dictionary<object, int>();

            Console.WriteLine(number.GetHashCode());
            Console.WriteLine();

            dict.Add(point1, 1);
            dict.Add(point2, 2);

            Console.WriteLine(dict[new Point(1, 2)]);
            Console.WriteLine();
            Console.WriteLine(dict.ContainsKey(new Point(1, 2)));
            Console.WriteLine();
            Console.WriteLine(point1.GetHashCode());
            Console.WriteLine();
            Console.WriteLine(point2.GetHashCode());
            Console.WriteLine();
        }

        internal class Point
        {
            internal Point(int x, int y)
            {
                X = x;
                Y = y;
            }

            internal int X { get; }

            internal int Y { get; }

            public override bool Equals(object obj)
            {
                return obj is Point hashcode && hashcode.X == X && hashcode.Y == Y;
            }

            protected bool Equals(Point other)
            {
                return X == other.X && Y == other.Y;
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return (X * 397) ^ Y;
                }
            }
        }
    }
}