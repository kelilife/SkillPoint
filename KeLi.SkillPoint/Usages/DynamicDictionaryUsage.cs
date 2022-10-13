using System;
using System.Collections.Generic;
using System.Dynamic;

namespace KeLi.SkillPoint.Usages
{
    internal class DynamicDictionaryUsage : DynamicObject, IAnalyzers
    {
        private readonly Dictionary<string, object> dict = new Dictionary<string, object>();

        internal int Count => dict.Count;

        public void ShowResult()
        {
            TestExpandoObject();
            TestDynamicObject();
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            return dict.TryGetValue(binder.Name.ToLower(), out result);
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            dict[binder.Name.ToLower()] = value;

            return true;
        }

        internal static void TestExpandoObject()
        {
            dynamic dyn = new ExpandoObject();

            dyn.Number = 20;
            dyn.Method = new Func<int, string>(i => (i + 20).ToString());

            Console.WriteLine(dyn.Number);
            Console.WriteLine(dyn.Method(dyn.Number));
        }

        internal static void TestDynamicObject()
        {
            dynamic person = new DynamicDictionaryUsage();

            person.FirstName = "Ellen";
            person.LastName = "Adams";

            Console.WriteLine(person.firstname + " " + person.lastname);
        }
    }
}