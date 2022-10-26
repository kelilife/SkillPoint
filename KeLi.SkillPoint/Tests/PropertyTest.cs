using System;
using System.Collections.Generic;

namespace KeLi.SkillPoint.Tests
{
    /// <summary>
    ///     Property study.
    /// </summary>
    internal class PropertyTest : IAnalyzers
    {
        /// <summary>
        ///     Readonly property, the class inner can modify it.
        /// </summary>
        internal static List<int> Collection1 { get; private set; }

        /// <summary>
        ///     Readonly property, no area can modify it.
        /// </summary>

        // ReSharper disable once UnassignedGetOnlyAutoProperty
        internal static List<int> Collection2 { get; }

        /// <summary>
        ///     Readonly property, the class inner can modify it.
        /// </summary>
        internal static List<int> Collection3 { get; private set; } = new();

        /// <summary>
        ///     Readonly property, init it and no area can modify it.
        /// </summary>
        internal static List<int> Collection4 { get; } = new();

        /// <summary>
        ///     Readonly property, init it and no area can modify it.
        /// </summary>
        internal static List<int> Collection5 => new();

        /// <summary>
        ///     Write only property, no area can read it.
        /// </summary>
        internal static List<int> Collection6 { private get; set; }

        /// <summary>
        ///     Write only property, init it and the class inner can read it.
        /// </summary>
        internal static List<int> Collection7 { private get; set; } = new();

        /// <summary>
        ///     It can get or set value.
        /// </summary>
        internal static List<int> Collection8 { get; set; }

        /// <summary>
        ///     It can get or set value and init value.
        /// </summary>
        internal static List<int> Collection9 { get; set; } = new();

        /// <summary>
        ///     Shows property result.
        /// </summary>
        public void ShowResult()
        {
            TestPropertyMyClass();
            PropertyTestClass.TestPropertyInOtherClass();
        }

        /// <summary>
        ///     Tests property in my class.
        /// </summary>
        internal static void TestPropertyMyClass()
        {
            Collection1 = new List<int>();

            //Uvs2 = new List<int>();
            Collection3 = new List<int>();

            // Uvs4 = new List<int>();
            // Uvs5 = new List<int>();
            Collection6 = new List<int>();
            Collection7 = new List<int>();
            Collection8 = new List<int>();
            Collection9 = new List<int>();

            Console.WriteLine(Collection1);
            Console.WriteLine(Collection2);
            Console.WriteLine(Collection3);
            Console.WriteLine(Collection4);
            Console.WriteLine(Collection5);
            Console.WriteLine(Collection6);
            Console.WriteLine(Collection7);
            Console.WriteLine(Collection8);
            Console.WriteLine(Collection9);
        }
    }

    /// <summary>
    ///     Property access test class.
    /// </summary>
    internal class PropertyTestClass
    {
        /// <summary>
        ///     Tests property in other class.
        /// </summary>
        internal static void TestPropertyInOtherClass()
        {
            // PropertyStudy.Uv1s = new List<int>();
            // PropertyStudy.Uv2s = new List<int>();
            // PropertyStudy.Uv3s = new List<int>();
            // PropertyStudy.Uv4s = new List<int>();
            // PropertyStudy.Uv5s = new List<int>();
            PropertyTest.Collection6 = new List<int>();
            PropertyTest.Collection7 = new List<int>();
            PropertyTest.Collection8 = new List<int>();
            PropertyTest.Collection9 = new List<int>();
            Console.WriteLine(PropertyTest.Collection1);
            Console.WriteLine(PropertyTest.Collection2);
            Console.WriteLine(PropertyTest.Collection3);
            Console.WriteLine(PropertyTest.Collection4);
            Console.WriteLine(PropertyTest.Collection5);

            // Console.WriteLine(PropertyStudy.Uv6s);
            // Console.WriteLine(PropertyStudy.Uv7s);
            Console.WriteLine(PropertyTest.Collection8);
            Console.WriteLine(PropertyTest.Collection9);
        }
    }
}