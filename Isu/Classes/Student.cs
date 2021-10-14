using Isu.Services;

namespace Isu.Classes
{
    public class Student
    {
        private static int _counterId;
        public Student(string name)
        {
            Name = name;
            Id = GenerateId();
        }

        public string Name { get; }
        public int Id { get; }

        private int GenerateId()
        {
            ++_counterId;
            return _counterId;
        }
    }
}