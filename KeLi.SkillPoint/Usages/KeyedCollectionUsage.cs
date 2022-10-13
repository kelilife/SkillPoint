using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace KeLi.SkillPoint.Usages
{
    internal class KeyedCollectionUsage : IAnalyzers
    {
        public void ShowResult()
        {
            foreach (var tm in GetTeacherModels())
            {
                foreach (var classroom in tm.Classrooms)
                {
                    foreach (var student in tm.Students.Where(w => w.ClassroomId == classroom.ClassroomId))
                        Console.WriteLine(tm.TeacherId + "\t" + classroom.ClassroomName + "\t" + student.StudentName);
                }
            }
        }

        internal static TeacherModelCollection GetTeacherModels()
        {
            var cc1 = new ClassroomDataModelCollection
            {
                new ClassroomDataModel("101", "Room 101"),
                new ClassroomDataModel("102", "Room 102"),
                new ClassroomDataModel("103", "Room 103")
            };

            var cc2 = new ClassroomDataModelCollection
            {
                new ClassroomDataModel("201", "Room 201"),
                new ClassroomDataModel("202", "Room 202"),
                new ClassroomDataModel("203", "Room 203")
            };

            var cc3 = new ClassroomDataModelCollection
            {
                new ClassroomDataModel("301", "Room 301"),
                new ClassroomDataModel("302", "Room 302"),
                new ClassroomDataModel("303", "Room 303")
            };

            var sc1 = new StudentDataModelCollection
            {
                new StudentDataModel("s101", "s101", "101"),
                new StudentDataModel("s102", "s102", "102"),
                new StudentDataModel("s103", "s103", "103"),
                new StudentDataModel("s104", "s104", "101"),
                new StudentDataModel("s105", "s105", "102"),
                new StudentDataModel("s106", "s106", "103")
            };

            var sc2 = new StudentDataModelCollection
            {
                new StudentDataModel("s201", "s201", "201"),
                new StudentDataModel("s202", "s202", "202"),
                new StudentDataModel("s203", "s203", "203"),
                new StudentDataModel("s204", "s204", "201"),
                new StudentDataModel("s205", "s205", "202"),
                new StudentDataModel("s206", "s206", "203")
            };

            var sc3 = new StudentDataModelCollection
            {
                new StudentDataModel("s301", "s301", "301"),
                new StudentDataModel("s302", "s302", "302"),
                new StudentDataModel("s303", "s303", "303"),
                new StudentDataModel("s304", "s304", "301"),
                new StudentDataModel("s305", "s305", "302"),
                new StudentDataModel("s306", "s306", "303")
            };

            var tc = new TeacherDataModelCollection
            {
                new TeacherDataModel("t101", "t101", cc1),
                new TeacherDataModel("t102", "t102", cc2),
                new TeacherDataModel("t103", "t103", cc3)
            };

            return new TeacherModelCollection
            {
                new TeacherBusinessModel(tc[0].TeacherId, cc1, sc1),
                new TeacherBusinessModel(tc[1].TeacherId, cc2, sc2),
                new TeacherBusinessModel(tc[2].TeacherId, cc3, sc3)
            };
        }
    }

    internal class TeacherModelCollection : KeyedCollection<string, TeacherBusinessModel>
    {
        protected override string GetKeyForItem(TeacherBusinessModel item)
        {
            return item.TeacherId;
        }
    }

    internal class TeacherBusinessModel
    {
        internal TeacherBusinessModel(string teacherId, ClassroomDataModelCollection classrooms, StudentDataModelCollection students)
        {
            TeacherId = teacherId;
            Classrooms = classrooms;
            Students = students;
        }

        internal string TeacherId { get; set; }

        internal ClassroomDataModelCollection Classrooms { get; set; }

        internal StudentDataModelCollection Students { get; set; }
    }

    internal class StudentDataModelCollection : KeyedCollection<string, StudentDataModel>
    {
        protected override string GetKeyForItem(StudentDataModel item)
        {
            return item.StudentId;
        }
    }

    internal class TeacherDataModelCollection : KeyedCollection<string, TeacherDataModel>
    {
        protected override string GetKeyForItem(TeacherDataModel item)
        {
            return item.TeacherId;
        }
    }

    internal class ClassroomDataModelCollection : KeyedCollection<string, ClassroomDataModel>
    {
        protected override string GetKeyForItem(ClassroomDataModel item)
        {
            return item.ClassroomId;
        }
    }

    internal class StudentDataModel
    {
        internal StudentDataModel(string studentId, string studentName, string classroomId)
        {
            StudentId = studentId;
            StudentName = studentName;
            ClassroomId = classroomId;
        }

        internal string StudentId { get; set; }

        internal string StudentName { get; set; }

        internal string ClassroomId { get; set; }
    }

    internal class TeacherDataModel
    {
        internal TeacherDataModel(string teacherId, string teacherName, ClassroomDataModelCollection belongClassrooms)
        {
            TeacherId = teacherId;
            TeacherName = teacherName;
            BelongClassrooms = belongClassrooms;
        }

        internal string TeacherId { get; set; }

        internal string TeacherName { get; set; }

        internal ClassroomDataModelCollection BelongClassrooms { get; set; }
    }

    internal class ClassroomDataModel
    {
        internal ClassroomDataModel(string classroomId, string classroomName)
        {
            ClassroomId = classroomId;
            ClassroomName = classroomName;
        }

        internal string ClassroomId { get; set; }

        internal string ClassroomName { get; set; }
    }
}