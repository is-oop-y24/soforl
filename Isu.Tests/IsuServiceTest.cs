using System.Numerics;
using Isu.Classes;
using Isu.Services;
using Isu.Tools;
using NUnit.Framework;

namespace Isu.Tests
{
    public class Tests
    {
        private IIsuService _isuService;
        private int _maxStudentAmount; 

        [SetUp]
        public void Setup()
        {
            _maxStudentAmount = 20;
            _isuService = new IsuService(_maxStudentAmount);
        }
        

        [Test]
        public void AddStudentToGroup_StudentHasGroupAndGroupContainsStudent()
        {
            Group group = _isuService.AddGroup("M3209");
            Student student = _isuService.AddStudent(group, "Fedor");
            
            Assert.Contains(student, group.Students);

        }

        [Test]
        public void ReachMaxStudentPerGroup_ThrowException()
        {
            Group group = _isuService.AddGroup("M3210");
            Assert.Catch<IsuException>(() =>
            {
                
                for (int i = 1; i <= (_maxStudentAmount + 1); ++i)
                {
                    _isuService.AddStudent(group,$"Sasha{i}");
                }
            });
        }

        [TestCase("M212")]
        [TestCase("P32fghj12")]
        
        public void CreateGroupWithInvalidName_ThrowException(string value)
        {
            Assert.Catch<IsuException>(() =>
            {
                Group group = _isuService.AddGroup(value);
            });
        }

        [Test]
        public void TransferStudentToAnotherGroup_GroupChanged()
        {
            Group group = _isuService.AddGroup("M3209");
            Student student = _isuService.AddStudent(group, "Masha");
            Student student2 = new Student("Misha", GenerateId.Id);
            Assert.Catch<IsuException>(() =>
            {
                _isuService.ChangeStudentGroup(student2, group);
            });
        }
    }
}