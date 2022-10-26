using System;

namespace KeLi.SkillPoint.Usages
{
    internal class OperatorUsage : IAnalyzers
    {
        public void ShowResult()
        {
            var student1 = new Student(80, 70);
            var student2 = new Student(85, 83);
            var student3 = student1 + student2;

            Console.WriteLine(student3);
        }

        internal class Student
        {
            internal Student(int chinese, int math)
            {
                Chinese = chinese;
                Math = math;
            }

            internal int Chinese { get; set; }

            internal int Math { get; set; }

            public static Student operator +(Student student1, Student student2)
            {
                return new Student(student1.Chinese + student2.Chinese, student1.Math + student2.Math);
            }

            public static implicit operator int(Student student)
            {
                return student.Chinese + student.Math;
            }
        }
    }
}