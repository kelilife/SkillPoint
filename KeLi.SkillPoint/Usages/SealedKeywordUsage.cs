using System;

namespace KeLi.SkillPoint.Usages
{
    internal class SealedKeywordUsage
    {
        private class Fruit
        {
            protected virtual string Name { get; set; }

            protected virtual void Eat()
            {
                Console.WriteLine(nameof(Fruit));
            }
        }

        private sealed class Apple : Fruit
        {
            protected override string Name { get; set; }

            protected override void Eat()
            {
                Console.WriteLine(nameof(Apple));
            }
        }
    }
}