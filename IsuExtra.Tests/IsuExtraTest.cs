using Isu.Classes;
using IsuExtra.Classes;
using IsuExtra.Services;
using NUnit.Framework;
using IsuExtra.Tools;
using Isu.Services;

namespace IsuExtra.Tests
{
    public class IsuExtraTest
    {
        private IIsuExtra _isuExtra;
        private IIsuService _isuService;
        private int _maxStudentAmount; 

        [SetUp]
        public void Setup()
        {
            _maxStudentAmount = 20;
            _isuExtra = new Services.IsuExtra(_maxStudentAmount);
            _isuService = new IsuService(_maxStudentAmount);
        }

        [Test]
        public void AddOgnp_RightFacultyName()
        {
            Assert.Catch<IsuExtraException>(() =>
            {
                Ognp ognp = _isuExtra.AddOgnp("Linux&Windows", "NNN", "Linux Systems", "Windows");
            });
        }
        
        [Test]
        public void AddOgnpStudent_CrossingSchedules_ThrowException()
        {
            Group group2 = _isuService.AddGroup("M3205");
            Student student = _isuService.AddStudent(group2, "Boris");

            var studentSchedule = _isuExtra.AddUsualLesson("Maths",2, 3, new StudentSchedule(student.Name, group2.Name.Name, student.Id));
            
            Ognp ognp = _isuExtra.AddOgnp("Linux&Windows", "FTMI",  "Lin", "Win");
            var stream = _isuExtra.AddStream(ognp.GetCourse1(), "Lin1");
            var stream2 = _isuExtra.AddStream(ognp.GetCourse2(), "Win3");
            _isuExtra.AddOgnpLesson(stream, 215, "Mironov", 5, 3);
            _isuExtra.AddOgnpLesson(stream2, 212, "Petrov", 2, 3);
            Assert.Catch<IsuExtraException>(() =>
            { 
                _isuExtra.AddOgnpStudent(ognp, student, studentSchedule);
            });
        }
        
        [Test]
        public void AddOgnpStudent_SameMegafaclties_ThrowException()
        {
            Group group2 = _isuService.AddGroup("M3205");
            Student student = _isuService.AddStudent(group2, "Boris");

            var studentSchedule = _isuExtra.AddUsualLesson("Maths",2, 3, new StudentSchedule(student.Name, group2.Name.Name, student.Id));
            
            Ognp ognp = _isuExtra.AddOgnp("Linux&Windows", "TINT",  "Lin", "Win");
            var stream = _isuExtra.AddStream(ognp.GetCourse1(), "Lin1");
            var stream2 = _isuExtra.AddStream(ognp.GetCourse2(), "Win3");
            _isuExtra.AddOgnpLesson(stream, 215, "Mironov", 5, 3);
            _isuExtra.AddOgnpLesson(stream2, 212, "Petrov", 1, 3);
            Assert.Catch<IsuExtraException>(() =>
            { 
                _isuExtra.AddOgnpStudent(ognp, student, studentSchedule);
            });
        }
        
        
    }
}