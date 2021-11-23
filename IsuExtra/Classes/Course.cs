using System.Collections.Generic;
using Isu.Classes;

namespace IsuExtra.Classes
{
    public class Course
    {
        private string _nameCourse;
        private List<Stream> _courseStreams;

        public Course(string nameCourse)
        {
            _nameCourse = nameCourse;
            _courseStreams = new List<Stream>();
        }

        public List<Stream> GetStreamCourse()
        {
            return _courseStreams;
        }

        public string GetNameCourse()
        {
            return _nameCourse;
        }
    }
}