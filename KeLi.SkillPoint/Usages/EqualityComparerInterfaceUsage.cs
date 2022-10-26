using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable ReturnValueOfPureMethodIsNotUsed

namespace KeLi.SkillPoint.Usages
{
    internal class EqualityComparerInterfaceUsage : IAnalyzers
    {
        public void ShowResult()
        {
            Test1();
            Test2();
        }

        internal void Test1()
        {
            var comparer = new AppleComparer();

            GetFruit1().GroupBy(g => g.Id, comparer).ToDictionary(k => k.Key, v => v, comparer);
            GetFruit2().GroupBy(g => g.Id, comparer).ToDictionary(k => k.Key, v => v, comparer);
        }

        internal void Test2()
        {
            var comparer = new AppleComparer();

            GetFruit1().ToDictionary(k => k.Id, v => v, comparer);
            GetFruit2().ToDictionary(k => k.Id, v => v, comparer);
        }

        private static List<Fruit> GetFruit1()
        {
            return new List<Fruit>
            {
                new(new Apple(1)),
                new(new Apple(2)),
                new(new Apple(3)),
                new(new Apple(4)),
                new(new Apple(5))
            };
        }

        private static List<Fruit> GetFruit2()
        {
            return new List<Fruit>
            {
                new(new Apple(1)),
                new(new Apple(2)),
                new(new Apple(1)),
                new(new Apple(4)),
                new(new Apple(5))
            };
        }

        private class Fruit
        {
            internal Fruit(Apple id)
            {
                Id = id;
            }

            internal Apple Id { get; }
        }

        private class Apple
        {
            internal Apple(int id)
            {
                Id = id;
            }

            internal int Id { get; }
        }

        private class AppleComparer : IEqualityComparer<Apple>
        {
            public bool Equals(Apple x, Apple y)
            {
                if (x is null)
                    throw new ArgumentNullException(nameof(x));

                if (y is null)
                    throw new ArgumentNullException(nameof(y));

                return x.Id == y.Id;
            }

            public int GetHashCode(Apple obj)
            {
                return obj.Id;
            }
        }
    }
}