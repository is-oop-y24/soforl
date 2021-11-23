using System;
using System.Collections.Generic;
using System.Numerics;
using Isu.Classes;

namespace IsuExtra.Classes
{
    public class StudentSchedule
    {
        private Student _student;
        private GroupName _nameStudentGroup;
        private List<UsualLesson> _schedule;
        private List<LessonOgnp> _scheduleOgnp;

        public StudentSchedule(string student, GroupName groupName, BigInteger id)
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
            return _nameStudentGroup.Name;
        }

        public List<UsualLesson> GetSchedule()
        {
            return _schedule;
        }

        public string GetStudentFaculty()
        {
            return _nameStudentGroup.Name.Substring(0, 2);
        }

        public List<LessonOgnp> GetScheduleOgnp()
        {
            return _scheduleOgnp;
        }

        public Stream CrossingSchedules(Stream stream)
        {
            foreach (LessonOgnp lessonOgnp in stream.GetLessonOgnp())
            {
                foreach (UsualLesson usualLesson in _schedule)
                {
                    if (usualLesson.GetDayWeek() == lessonOgnp.GetDayWeek()
                        && usualLesson.GetNumberLesson() == lessonOgnp.GetNumberLesson())
                    {
                        return null;
                    }
                }
            }

            return stream;
        }
    }
}