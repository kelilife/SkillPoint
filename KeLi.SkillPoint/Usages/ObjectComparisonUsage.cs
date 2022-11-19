using System;
using System.Text;

#pragma warning disable CS0252, CS0253

// ReSharper disable All

namespace KeLi.SkillPoint.Usages
{
    internal class ObjectComparisonUsage : IAnalyzers
    {
        public void ShowResult()
        {
            Test1();
            Test2();
            Test3();
            Test4();
            Test5();
            Test6();
            Test7();
            Test8();
            Test9();
            Test10();
        }

        public static void Test1()
        {
            Console.WriteLine(nameof(Test1));

            object obj = "11";
            string str = "11";

            Console.WriteLine(ReferenceEquals(obj, str)); // True
            Console.WriteLine(obj.Equals(str)); // True
            Console.WriteLine(obj == str); // True
        }

        public static void Test2()
        {
            Console.WriteLine(nameof(Test2));

            object obj = "22";
            string str = "2" + "2";

            Console.WriteLine(ReferenceEquals(obj, str)); // True
            Console.WriteLine(obj.Equals(str)); // True
            Console.WriteLine(obj == str); // True
        }

        public static void Test3()
        {
            Console.WriteLine(nameof(Test3));

            object obj1 = "33";
            object obj2 = "3" + "3";

            Console.WriteLine(ReferenceEquals(obj1, obj2)); // True
            Console.WriteLine(obj1.Equals(obj2)); // True
            Console.WriteLine(obj1 == obj2); // True
        }

        public static void Test4()
        {
            Console.WriteLine(nameof(Test4));

            string str = "44";
            object obj = new StringBuilder("44").ToString();

            Console.WriteLine(ReferenceEquals(obj, str)); // False
            Console.WriteLine(obj.Equals(str)); // True
            Console.WriteLine(str == obj); // False
        }

        public static void Test5()
        {
            Console.WriteLine(nameof(Test5));

            string str1 = "55";
            string str2 = new StringBuilder("55").ToString();

            Console.WriteLine(ReferenceEquals(str1, str2)); // False
            Console.WriteLine(str1.Equals(str2)); // True
            Console.WriteLine(str1 == str2); // True
        }

        public static void Test6()
        {
            Console.WriteLine(nameof(Test6));

            object obj1 = "66";
            object obj2 = new StringBuilder("66").ToString();

            Console.WriteLine(ReferenceEquals(obj1, obj2)); // False
            Console.WriteLine(obj1.Equals(obj2)); // True
            Console.WriteLine(obj1 == obj2); // False
        }

        public static void Test7()
        {
            Console.WriteLine(nameof(Test7));

            object obj1 = 77;
            object obj2 = 77;

            Console.WriteLine(ReferenceEquals(obj1, obj2)); // False
            Console.WriteLine(obj1.Equals(obj2)); // True
            Console.WriteLine(obj1 == obj2); // False
        }

        public static void Test8()
        {
            Console.WriteLine(nameof(Test8));

            object obj = 8.0;
            double number = 8.0;

            Console.WriteLine(ReferenceEquals(obj, number)); // False
            Console.WriteLine(obj.Equals(number)); // True
            //Console.WriteLine(obj == number);
        }

        public static void Test9()
        {
            Console.WriteLine(nameof(Test9));

            double number1 = 9.0;
            float number2 = 9.0f;

            Console.WriteLine(ReferenceEquals(number1, number2)); // False
            Console.WriteLine(number1.Equals(number2)); // True
            Console.WriteLine(number1 == number2); // True
        }

        public static void Test10()
        {
            Console.WriteLine(nameof(Test10));

            object obj = 10.0;
            object number = 10.0f;

            Console.WriteLine(ReferenceEquals(obj, number)); // False
            Console.WriteLine(obj.Equals(number)); // False
            Console.WriteLine(obj == number); // False
        }
    }
}
