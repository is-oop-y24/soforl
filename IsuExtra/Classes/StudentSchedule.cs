using System;
using System.Collections.Generic;
using System.Numerics;
using Isu.Classes;

namespace IsuExtra.Classes
{
    public class StudentSchedule
    {
        private Student _student;
        private string _nameStudentGroup;
        private List<UsualLesson> _schedule;
        private List<LessonOgnp> _scheduleOgnp;

        public StudentSchedule(string student, string groupName, BigInteger id)
        {
            _student = new Student(student, id);
            _nameStudentGroup = groupName;
            _schedule = new List<UsualLesson>();
            _scheduleOgnp = new List<LessonOgnp>();
        }

        public void DeleteOgnpSchedule()
        {
            var ognpSchedule = new List<LessonOgnp>();
            _scheduleOgnp = ognpSchedule;
        }

        public Student GetStudent()
        {
            return _student;
        }

        public string GetNameStudentGroup()
        {
            return _nameStudentGroup;
        }

        public List<UsualLesson> GetSchedule()
        {
            return _schedule;
        }

        public List<LessonOgnp> GetScheduleOgnp()
        {
            return _scheduleOgnp;
        }
    }
}