using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Isu.Tools;

namespace Isu.Classes
{
    public class Group
    {
        public Group(Group group)
        {
            Name = group.Name;
            Students = new List<Student>(group.Students);
        }

        public Group(GroupName name)
        {
            Name = name;
            Students = new List<Student>();
        }

        public GroupName Name { get; }
        public List<Student> Students { get; }

        public void DeleteStudent(Student student)
        {
            foreach (Student stud in Students.Where(stud => stud.Id == student.Id))
            {
                Students.Remove(stud);
            }
        }

        public void AddStudent(Student student)
        {
            Students.Add(student);
        }

        public int GetCountStudents()
        {
            return Students.Count;
        }
    }
}