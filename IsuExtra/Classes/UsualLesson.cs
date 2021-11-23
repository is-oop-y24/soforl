namespace IsuExtra.Classes
{
    public class UsualLesson
    {
        private string _nameSubject;
        private int _numberLesson;
        private int _dayWeek;

        public UsualLesson(string subject, int lessonNumber, int dayWeek)
        {
            _nameSubject = subject;
            _numberLesson = lessonNumber;
            _dayWeek = dayWeek;
        }

        public string GetNameSubject()
        {
            return _nameSubject;
        }

        public int GetNumberLesson()
        {
            return _numberLesson;
        }

        public int GetDayWeek()
        {
            return _dayWeek;
        }
    }
}