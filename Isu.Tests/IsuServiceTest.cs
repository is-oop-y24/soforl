using Isu.Classes;
using Isu.Services;
using Isu.Tools;
using NUnit.Framework;

namespace Isu.Tests
{
    public class Tests
    {
        private IIsuService _isuService;

        [SetUp]
        public void Setup()
        {
            _isuService = new IsuService();
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
            Assert.Catch<IsuException>(() =>
            {
                Group group = _isuService.AddGroup("M3210");
                for (int i = 1; i <= 30; ++i)
                {
                    _isuService.AddStudent(group,$"Sasha{i}");
                }
            });
        }

        [Test]
        public void CreateGroupWithInvalidName_ThrowException()
        {
            Assert.Catch<IsuException>(() =>
            {
                Group group = _isuService.AddGroup("M2212");
                Group group1 = _isuService.AddGroup("P3212");
            });
        }

        [Test]
        public void TransferStudentToAnotherGroup_GroupChanged()
        {
            Group group = _isuService.AddGroup("M3107");
                Group group2 = _isuService.AddGroup("M3108");
                Student student = _isuService.AddStudent(group, "Masha");
                _isuService.ChangeStudentGroup(student, group2);
        }
    }
}