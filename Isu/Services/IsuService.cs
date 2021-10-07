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
        private List<Student> _allStudents = new List<Student>();
        private List<string> _possibleGroupNames = new List<string> { "M3" };
        private int _maxStudent = 0;

        public IsuService(int maxStudent)
        {
            _maxStudent = maxStudent;
        }

        public Group AddGroup(string name)
        {
            bool check = false;
            foreach (string item in _possibleGroupNames)
            {
                if (name.Substring(0, 2) == item)
                {
                    check = true;
                }
            }

            if (check == false)
            {
                throw new IsuException("Invalid name of group");
            }

            var group = new Group(new GroupName(name));
            _groups.Add(group);
            return group;
        }

        public Student AddStudent(Group group, string name)
        {
            if (group.GetCountStudents() >= _maxStudent)
                throw new IsuException("No place to add new student in this group");
            var student = new Student(name, group);
            group.CountStudents();
            _allStudents.Add(student);
            return student;
        }

        public Student GetStudent(int id)
        {
            foreach (Student student in _allStudents)
            {
                if (student.Id == id)
                {
                    return student;
                }
            }

            throw new IsuException("not found student");
        }

        public Student FindStudent(string name)
        {
            foreach (Student student in _allStudents)
            {
                if (student.Name == name)
                {
                    return student;
                }
            }

            return null;
        }

        public List<Student> FindStudents(string groupName)
        {
            var groupStudents = new List<Student>();
            foreach (Student student in _allStudents)
            {
                if (student.Group.Name.Name == groupName)
                {
                    groupStudents.Add(student);
                }
            }

            return groupStudents;
        }

        public List<Student> FindStudents(CourseNumber courseNumber)
        {
            var studentsCourse = new List<Student>();
            foreach (Student student in _allStudents)
            {
                if (student.Group.Name.CourseNumber == courseNumber)
                {
                    studentsCourse.Add(student);
                }
            }

            return studentsCourse;
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
            var groupCourse = new List<Group>();
            foreach (Group group in _groups)
            {
                if (group.Name.CourseNumber == courseNumber)
                {
                    groupCourse.Add(group);
                }
            }

            return groupCourse;
        }

        public void ChangeStudentGroup(Student student, Group newGroup)
        {
            student.Group = newGroup;
        }
    }
}