using System;
using System.Collections.Generic;
using System.Linq;
using Isu.Classes;
using IsuExtra.Tools;

namespace IsuExtra.Classes
{
    public class Stream
    {
        private string _nameStream;
        private int _numberStream;
        private List<Student> _studentsStream;
        private List<LessonOgnp> _streamSchedule;

        public Stream(string nameStream)
        {
            if (CheckNameStream(nameStream))
            {
                _nameStream = nameStream;
                _numberStream = int.Parse(nameStream.Substring(3, 1));
                _streamSchedule = new List<LessonOgnp>();
                _studentsStream = new List<Student>();
            }
        }

        public void DeleteStudent(Student stud)
        {
            var students = new List<Student>(_studentsStream);
            students.Remove(stud);
            _studentsStream = new List<Student>(students);
        }

        public string GetNameStream()
        {
            return _nameStream;
        }

        public List<Student> GetStudentsStream()
        {
            return _studentsStream;
        }

        public List<LessonOgnp> GetLessonOgnp()
        {
            return _streamSchedule;
        }

        public int GetCountStudents()
        {
            return GetStudentsStream().Count;
        }

        private bool CheckNameStream(string nameStream)
        {
            int numberStream = int.Parse(nameStream.Substring(3, 1));
            if (nameStream.Count() == 4 && numberStream is >= 1 and <= 6)
            {
                return true;
            }

            throw new IsuExtraException("Invalid name of Stream");
        }
    }
}