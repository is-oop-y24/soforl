using System;
using System.Collections.Generic;
using System.Linq;
using Isu.Classes;
using Isu.Services;
using IsuExtra.Classes;
using IsuExtra.Tools;

namespace IsuExtra.Services
{
    public class IsuExtra : IIsuExtra
    {
        private List<Ognp> _allOgnp = new ();

        private List<Student> _signedUpStudents = new ();
        private int _maxStudent = 0;

        private Dictionary<string, string> _facultyNameGroup = new Dictionary<string, string>()
        {
            { "TINT", "M3" },
            { "FTMI", "L3" },
        };

        private IsuService _isuService = new IsuService(20);

        public IsuExtra(int maxStudent)
        {
            _maxStudent = maxStudent;
        }

        public Ognp AddOgnp(string nameOgnp, string faculty, string course1, string course2)
        {
            var newCourse1 = new Course(course1);
            var newCourse2 = new Course(course2);
            foreach (string newFaculty in _facultyNameGroup.Keys)
            {
                if (newFaculty == faculty)
                {
                    var newOgnp = new Ognp(nameOgnp, faculty, newCourse1, newCourse2);
                    _allOgnp.Add(newOgnp);
                    return newOgnp;
                }
            }

            throw new IsuExtraException("Invalid name of faculty");
        }

        public Stream AddStream(Course courseOgnp, string nameStream)
        {
            foreach (Ognp ognp in _allOgnp)
            {
                foreach (Course course in ognp.GetCourses())
                {
                    if (courseOgnp == course)
                    {
                        var stream = new Stream(nameStream);
                        course.GetStreamCourse().Add(stream);
                        return stream;
                    }
                }
            }

            throw new IsuExtraException("Invalid name of course");
        }

        public StudentSchedule AddUsualLesson(string subject, int numberLesson, int dayWeek, StudentSchedule student)
        {
            foreach (UsualLesson lesson in student.GetSchedule())
            {
                if (lesson.GetDayWeek() == dayWeek && lesson.GetNumberLesson() == numberLesson)
                {
                    throw new IsuExtraException("Invalid lesson");
                }
            }

            student.GetSchedule().Add(new UsualLesson(subject, numberLesson, dayWeek));
            return student;
        }

        public Stream AddStudentStream(Stream stream, StudentSchedule studentSchedule)
        {
            if (stream.GetCountStudents() <= _maxStudent)
            {
                foreach (LessonOgnp lessonOgnp in stream.GetLessonOgnp())
                {
                    foreach (UsualLesson usualLesson in studentSchedule.GetSchedule())
                    {
                        if (usualLesson.GetDayWeek() == lessonOgnp.GetDayWeek()
                            && usualLesson.GetNumberLesson() == lessonOgnp.GetNumberLesson())
                        {
                            return stream;
                        }
                    }
                }
            }

            return null;
        }

        public Stream AddOgnpLesson(Stream stream, int classroom, string teacher, int numberLesson, int dayWeek)
        {
            stream.GetLessonOgnp().Add(new LessonOgnp(stream, classroom, teacher, numberLesson, dayWeek));
            return stream;
        }

        public bool AddStudentCourse(Course course, StudentSchedule studentSchedule)
        {
            foreach (var stream in course.GetStreamCourse())
            {
                if (AddStudentStream(stream, studentSchedule) != null)
                {
                    foreach (var lesson in stream.GetLessonOgnp())
                    {
                        studentSchedule.GetScheduleOgnp().Add(lesson);
                        stream.GetStudentsStream().Add(studentSchedule.GetStudent());
                        return true;
                    }
                }
            }

            return false;
        }

        public StudentSchedule AddOgnpStudent(Ognp ognp, Student student, StudentSchedule studentSchedule)
        {
            if (studentSchedule.GetScheduleOgnp().Count > 0)
            {
                throw new IsuExtraException("Invalid operation");
            }

            foreach (KeyValuePair<string, string> faculty in _facultyNameGroup)
            {
                if (ognp.GetFaculty() == faculty.Key)
                {
                    if (studentSchedule.GetNameStudentGroup().Substring(0, 2) == faculty.Value)
                    {
                        throw new IsuExtraException("Invalid faculty");
                    }
                }
            }

            foreach (var course in ognp.GetCourses())
            {
                if (AddStudentCourse(course, studentSchedule))
                {
                    if (!_signedUpStudents.Contains(student))
                    {
                        _signedUpStudents.Add(student);
                        return studentSchedule;
                    }
                }
            }

            throw new IsuExtraException("Can not sign up student to course");
        }

        public void DeleteStudentOgnp(Ognp ognp, StudentSchedule studentSchedule)
        {
            foreach (var course in ognp.GetCourses())
            {
                foreach (var stream in course.GetStreamCourse())
                {
                    if (stream.GetStudentsStream().Contains(studentSchedule.GetStudent()))
                    {
                        stream.DeleteStudent(studentSchedule.GetStudent());
                    }
                }
            }

            studentSchedule.DeleteOgnpSchedule();
        }

        public List<Stream> GetStreams(Course course)
        {
            List<Stream> streamsCourse = course.GetStreamCourse();
            return streamsCourse;
        }

        public List<Student> GetStudentsStream(Stream stream)
        {
            return stream.GetStudentsStream();
        }

        public List<Student> GetNotSignedStudents()
        {
            var notSignedUpStudents = new List<Student>();
            foreach (var group in _isuService.GetGroups())
            {
                foreach (var stud in group.Students)
                {
                    foreach (var studOgnp in _signedUpStudents)
                    {
                        if (stud != studOgnp)
                        {
                            notSignedUpStudents.Add(stud);
                        }
                    }
                }
            }

            return notSignedUpStudents;
        }
    }
}