using System;
using System.Numerics;
using Isu.Services;

namespace Isu.Classes
{
    public class Student
    {
        public Student(string name, BigInteger id)
        {
            Name = name;
            Id = id;
        }

        public string Name { get; }
        public BigInteger Id { get; }
    }
}