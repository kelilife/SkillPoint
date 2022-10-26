using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace KeLi.SkillPoint.Usages
{
    internal class KeyedCollectionUsage : IAnalyzers
    {
        public void ShowResult()
        {
            foreach (var teacher in GetTeachers())
            foreach (var classroom in teacher.Classrooms)
            foreach (var student in teacher.Students.Where(w => w.ClassroomId == classroom.ClassroomId))
                Console.WriteLine(teacher.TeacherId + "\t" + classroom.ClassroomName + "\t" + student.StudentName);
        }

        internal static ValidatableTeacherCollection GetTeachers()
        {
            var cc1 = new BusinessClassroomCollection
            {
                new("101", "Room 101"),
                new("102", "Room 102"),
                new("103", "Room 103")
            };

            var cc2 = new BusinessClassroomCollection
            {
                new("201", "Room 201"),
                new("202", "Room 202"),
                new("203", "Room 203")
            };

            var cc3 = new BusinessClassroomCollection
            {
                new("301", "Room 301"),
                new("302", "Room 302"),
                new("303", "Room 303")
            };

            var sc1 = new BusinessStudentCollection
            {
                new("s101", "s101", "101"),
                new("s102", "s102", "102"),
                new("s103", "s103", "103"),
                new("s104", "s104", "101"),
                new("s105", "s105", "102"),
                new("s106", "s106", "103")
            };

            var sc2 = new BusinessStudentCollection
            {
                new("s201", "s201", "201"),
                new("s202", "s202", "202"),
                new("s203", "s203", "203"),
                new("s204", "s204", "201"),
                new("s205", "s205", "202"),
                new("s206", "s206", "203")
            };

            var sc3 = new BusinessStudentCollection
            {
                new("s301", "s301", "301"),
                new("s302", "s302", "302"),
                new("s303", "s303", "303"),
                new("s304", "s304", "301"),
                new("s305", "s305", "302"),
                new("s306", "s306", "303")
            };

            var tc = new BusinessTeacherCollection
            {
                new("t101", "t101", cc1),
                new("t102", "t102", cc2),
                new("t103", "t103", cc3)
            };

            return new ValidatableTeacherCollection
            {
                new(tc[0].TeacherId, cc1, sc1),
                new(tc[1].TeacherId, cc2, sc2),
                new(tc[2].TeacherId, cc3, sc3)
            };
        }
    }

    internal class ValidatableTeacherCollection : KeyedCollection<string, ValidatableTeacher>
    {
        protected override string GetKeyForItem(ValidatableTeacher item)
        {
            return item.TeacherId;
        }
    }

    internal class ValidatableTeacher
    {
        internal ValidatableTeacher(string teacherId, BusinessClassroomCollection classrooms, BusinessStudentCollection students)
        {
            TeacherId = teacherId;
            Classrooms = classrooms;
            Students = students;
        }

        internal string TeacherId { get; set; }

        internal BusinessClassroomCollection Classrooms { get; set; }

        internal BusinessStudentCollection Students { get; set; }
    }

    internal class BusinessStudentCollection : KeyedCollection<string, BusinessStudent>
    {
        protected override string GetKeyForItem(BusinessStudent item)
        {
            return item.StudentId;
        }
    }

    internal class BusinessTeacherCollection : KeyedCollection<string, BusinessTeacher>
    {
        protected override string GetKeyForItem(BusinessTeacher item)
        {
            return item.TeacherId;
        }
    }

    internal class BusinessClassroomCollection : KeyedCollection<string, BusinessClassroom>
    {
        protected override string GetKeyForItem(BusinessClassroom item)
        {
            return item.ClassroomId;
        }
    }

    internal class BusinessStudent
    {
        internal BusinessStudent(string studentId, string studentName, string classroomId)
        {
            StudentId = studentId;
            StudentName = studentName;
            ClassroomId = classroomId;
        }

        internal string StudentId { get; set; }

        internal string StudentName { get; set; }

        internal string ClassroomId { get; set; }
    }

    internal class BusinessTeacher
    {
        internal BusinessTeacher(string teacherId, string teacherName, BusinessClassroomCollection classrooms)
        {
            TeacherId = teacherId;
            TeacherName = teacherName;
            Classrooms = classrooms;
        }

        internal string TeacherId { get; set; }

        internal string TeacherName { get; set; }

        internal BusinessClassroomCollection Classrooms { get; set; }
    }

    internal class BusinessClassroom
    {
        internal BusinessClassroom(string classroomId, string classroomName)
        {
            ClassroomId = classroomId;
            ClassroomName = classroomName;
        }

        internal string ClassroomId { get; set; }

        internal string ClassroomName { get; set; }
    }
}