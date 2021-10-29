using System;
using System.Collections.Generic;
using Isu.Classes;

namespace IsuExtra.Classes
{
    public class Ognp
    {
        private string _nameOgnp;
        private string _facultyOgnp;
        private Course _course1;
        private Course _course2;
        private List<Course> _courses;

        public Ognp(string nameOgnp, string facultyOgnp, Course course1, Course course2)
        {
            var courses = new List<Course>() { course1, course2 };
            _course1 = course1;
            _course2 = course2;
            _courses = courses;
            _nameOgnp = nameOgnp;
            _facultyOgnp = facultyOgnp;
        }

        public string GetNameOgnp()
        {
            return _nameOgnp;
        }

        public Course GetCourse1()
        {
            return _course1;
        }

        public Course GetCourse2()
        {
            return _course2;
        }

        public string GetFaculty()
        {
            return _facultyOgnp;
        }

        public List<Course> GetCourses()
        {
            return _courses;
        }
    }
}