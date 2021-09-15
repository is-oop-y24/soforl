using System.Collections;
using System.Collections.Generic;

namespace Isu.Classes
{
    public class Group
    {
        public Group(string name)
        {
            Name = new GroupName(name);
            Students = new List<Student>();
        }

        public List<Student> Students { get; } = new List<Student>();
        public GroupName Name { get; }
    }
}