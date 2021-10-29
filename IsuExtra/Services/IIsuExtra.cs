using System.Collections.Generic;
using Isu.Classes;
using IsuExtra.Classes;

namespace IsuExtra.Services
{
    public interface IIsuExtra
    {
        Ognp AddOgnp(string nameOgnp, string faculty, string course1, string course2);
        Stream AddStream(Course courseOgnp, string nameStream);
        StudentSchedule AddUsualLesson(string subject, int numberLesson, int dayWeek, StudentSchedule student);
        Stream AddStudentStream(Stream stream, StudentSchedule studentSchedule);
        Stream AddOgnpLesson(Stream stream, int classroom, string teacher, int numberLesson, int dayWeek);
        bool AddStudentCourse(Course course, StudentSchedule studentSchedule);
        StudentSchedule AddOgnpStudent(Ognp ognp, Student student, StudentSchedule studentSchedule);
        void DeleteStudentOgnp(Ognp ognp, StudentSchedule studentSchedule);
        List<Stream> GetStreams(Course course);
        List<Student> GetStudentsStream(Stream stream);
        List<Student> GetNotSignedStudents();
    }
}