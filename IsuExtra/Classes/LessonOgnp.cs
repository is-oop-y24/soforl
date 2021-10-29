using System;
using System.Collections.Generic;
using Isu.Classes;

namespace IsuExtra.Classes
{
    public class LessonOgnp
    {
        private string _nameStream;
        private int _classroom;
        private string _teacherLesson;
        private int _numberLesson;
        private int _dayWeek;

        public LessonOgnp(Stream nameStream, int classroom, string teacher, int numberLesson, int dayWeek)
        {
            if ((dayWeek is >= 1 and <= 6) && (numberLesson <= 6))
            {
                _nameStream = nameStream.GetNameStream();
                _classroom = classroom;
                _teacherLesson = teacher;
                _numberLesson = numberLesson;
                _dayWeek = dayWeek;
            }
        }

        public string GetNameStream()
        {
            return _nameStream;
        }

        public int GetClassroom()
        {
            return _classroom;
        }

        public string GetTeacherLesson()
        {
            return _teacherLesson;
        }

        public int GetNumberLesson()
        {
            return _numberLesson;
        }

        public int GetDayWeek()
        {
            return _dayWeek;
        }
    }
}