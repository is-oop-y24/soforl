using System.Collections;
using System.Collections.Generic;

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