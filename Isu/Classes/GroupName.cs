using Isu.Tools;

namespace Isu.Classes
{
    public class GroupName
    {
        private int _minCourse = 1;
        private int _maxCourse = 4;
        private int _minGroup = 0;
        private int _maxGroup = 99;
        public GroupName(string name)
        {
            if (CheckGroupName(name))
            {
                Name = name;
                CourseNumber = (CourseNumber)int.Parse(name.Substring(2, 1));
                GroupNumber = int.Parse(name.Substring(3, 2));
            }
        }

        public string Name { get; }
        public CourseNumber CourseNumber { get; }
        public int GroupNumber { get; }

        private bool CheckGroupName(string name)
        {
            if (!int.TryParse(name.Substring(2, 1), out int courseNumber))
            {
                throw new IsuException("Invalid name of group, incorrect course");
            }

            if (courseNumber < _minCourse || courseNumber > _maxCourse)
            {
                throw new IsuException("Invalid name of group, incorrect course");
            }

            if (!int.TryParse(name.Substring(3, 2), out int groupNumber))
            {
                throw new IsuException("Invalid name of group, incorrect group");
            }

            if (groupNumber < _minGroup || groupNumber > _maxGroup)
            {
                throw new IsuException("Invalid name of group, incorrect group");
            }

            return true;
        }
    }
}