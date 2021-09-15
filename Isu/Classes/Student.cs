using Isu.Services;

namespace Isu.Classes
{
    public class Student
    {
        private static int _counterId;
        public Student(string name)
        {
            Name = name;
            Id = ++_counterId;
        }

        public string Name { get; }
        public int Id { get; }
    }
}