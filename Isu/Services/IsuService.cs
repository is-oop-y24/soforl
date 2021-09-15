using System;
using System.Collections.Generic;
using System.Linq;
using Isu.Classes;
using Isu.Tools;

namespace Isu.Services
{
    public class IsuService : IIsuService
    {
        private List<Group> Groups { get; } = new List<Group>();
        public Group AddGroup(string name)
        {
            if (name[0] != 'M')
                throw new IsuException("Invalid name of the group");
            if (name[1] != '3')
                throw new IsuException("Invalid name of the group");
            Group group = new Group(name);
            Groups.Add(group);
            return group;
        }

        public Student AddStudent(Group group, string name)
        {
            if (group.Students.Count >= 28)
                throw new IsuException("No place to add new student in this group");
            Student student = new Student(name);
            group.Students.Add(student);
            return student;
        }

        public Student GetStudent(int id)
        {
            foreach (Group group in Groups)
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
            foreach (Group group in Groups)
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
            foreach (Group group in Groups)
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
            List<Student> studentsCourse = new List<Student>();
            foreach (Group group in Groups)
            {
                if (group.Name.CourseNumber == courseNumber)
                {
                    foreach (Student student in group.Students)
                    {
                        studentsCourse.Add(student);
                    }
                }
            }

            return studentsCourse;
        }

        public Group FindGroup(string groupName)
        {
            foreach (Group group in Groups)
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
            List<Group> groupCourse = new List<Group>();
            foreach (Group group in Groups)
            {
                if (group.Name.CourseNumber.NumberCourse == courseNumber.NumberCourse)
                {
                    groupCourse.Add(group);
                }
            }

            return groupCourse;
        }

        public void ChangeStudentGroup(Student student, Group newGroup)
        {
            foreach (Group group in Groups)
            {
                foreach (Student st in group.Students.ToList())
                {
                    if (student.Id == st.Id)
                    {
                        group.Students.Remove(student);
                        newGroup.Students.Add(student);
                    }
                }
            }
        }
    }
}