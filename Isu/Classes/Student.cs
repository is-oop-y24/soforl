using Isu.Services;

namespace Isu.Classes
{
    public class Student
    {
        private static int _counterId;
        public Student(string name, Group studentGroup)
        {
            Name = name;
            Group = studentGroup;
            Id = GenerateId();
        }

        public string Name { get; }
        public int Id { get; }
        public Group Group { get; set; }

        private int GenerateId()
        {
            ++_counterId;
            return _counterId;
        }
    }
}