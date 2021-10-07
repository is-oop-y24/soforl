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
        }

        public GroupName Name { get; }
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