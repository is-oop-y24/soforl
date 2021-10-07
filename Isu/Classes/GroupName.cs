namespace Isu.Classes
{
    public class GroupName
    {
        public GroupName(string name)
        {
            Name = name;
            CourseNumber = (CourseNumber)int.Parse(name.Substring(2, 1));
            GroupNumber = int.Parse(name.Substring(3, 2));
        }

        public string Name { get; }
        public CourseNumber CourseNumber { get; }
        public int GroupNumber { get; }
    }
}