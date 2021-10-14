using System.Collections;
using System.Collections.Generic;
using Isu.Tools;

namespace Isu.Classes
{
    public class Group
    {
        private int _count;
        public Group(GroupName name)
        {
            Name = name;
            Students = new List<Student>();
        }

        public GroupName Name { get; }
        public List<Student> Students { get; }

        public void DeleteStudent(Student student)
        {
            foreach (Student stud in Students)
            {
                if (stud.Id == student.Id)
                {
                    Students.Remove(stud);
                }
            }
        }

        public int CountStudents()
        {
            ++_count;
            return _count;
        }

        public int GetCountStudents()
        {
            return _count;
        }
    }
}