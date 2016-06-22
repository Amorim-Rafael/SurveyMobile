namespace SurveyMobile.Droid.Domain.Send
{
    public class SendQuestionario
    {
        private long _finish;
        private long _duration;

        public long getFinish()
        {
            return _finish;
        }

        public long getDuration()
        {
            return _duration;
        }

        public void setFinish(long finish)
        {
            _finish = finish;
        }

        public void setDuration(long duration)
        {
            _duration = duration;
        }
    }
}