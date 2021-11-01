using System.Collections.Generic;
using System.Numerics;
using Isu.Classes;

namespace Isu.Services
{
    public interface IIsuService
    {
        Group AddGroup(string name);
        Student AddStudent(Group group, string name);

        Student GetStudent(BigInteger id);
        Student FindStudent(string name);
        List<Student> FindStudents(string groupName);

        List<Student> FindStudents(CourseNumber courseNumber);

        Group FindGroup(string groupName);
        List<Group> FindGroups(CourseNumber courseNumber);

        void ChangeStudentGroup(Student student, Group newGroup);
    }
}