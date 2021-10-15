using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Isu.Classes;
using Isu.Tools;

namespace Isu.Services
{
    public class IsuService : IIsuService
    {
        private List<Group> _groups = new List<Group>();
        private List<string> _possibleGroupNames = new List<string> { "M3" };
        private int _maxStudent = 0;

        public IsuService(int maxStudent)
        {
            _maxStudent = maxStudent;
        }

        public Group AddGroup(string name)
        {
            foreach (string item in _possibleGroupNames)
            {
                if (name.Substring(0, 2) == item)
                {
                    var group = new Group(new GroupName(name));
                    _groups.Add(group);
                    return group;
                }
            }

            throw new IsuException("Invalid name of group");
        }

        public Student AddStudent(Group group, string name)
        {
            if (group.GetCountStudents() >= _maxStudent)
            {
                throw new IsuException("No place to add new student in this group");
            }

            var student = new Student(name);
            group.Students.Add(student);
            return student;
        }

        public Student GetStudent(int id)
        {
            foreach (Group group in _groups)
            {
                foreach (Student student in group.Students)
                {
                    if (student.Id == id)
                    {
                        return student;
                    }
                }
            }

            throw new IsuException("not found student");
        }

        public Student FindStudent(string name)
        {
            foreach (Group group in _groups)
            {
                foreach (Student student in group.Students)
                {
                    if (student.Name == name)
                    {
                        return student;
                    }
                }
            }

            return null;
        }

        public List<Student> FindStudents(string groupName)
        {
            foreach (Group group in _groups)
            {
                if (group.Name.Name == groupName)
                {
                    return group.Students;
                }
            }

            return null;
        }

        public List<Student> FindStudents(CourseNumber courseNumber)
        {
            var studentCourse = new List<Student>();
            foreach (Group group in _groups)
            {
                if (group.Name.CourseNumber == courseNumber)
                {
                    foreach (Student student in group.Students)
                    {
                        studentCourse.Add(student);
                    }
                }
            }

            return studentCourse;
        }

        public Group FindGroup(string groupName)
        {
            foreach (Group group in _groups)
            {
                if (group.Name.Name == groupName)
                {
                    return group;
                }
            }

            return null;
        }

        public List<Group> FindGroups(CourseNumber courseNumber)
        {
            return _groups.Where(@group => @group.Name.CourseNumber == courseNumber).ToList();
        }

        public void ChangeStudentGroup(Student student, Group newGroup)
        {
            bool checkStudentGroup = false;
            foreach (Group group in _groups)
            {
                if (group.Students.Contains(student))
                {
                    checkStudentGroup = true;
                    group.DeleteStudent(student);
                    newGroup.Students.Add(student);
                }
            }

            if (checkStudentGroup == false)
            {
                throw new IsuException("Invalid operation");
            }
        }
    }
}