using System.Collections.Generic;

namespace SurveyMobile.Droid.Domain.Send
{
    public class SendQuestionario
    {
        public int Id;
        public string BatteryPct;
        public long Duracao;
        public long Finalizado;
        public string Lat;
        public string Lng;
        public List<SendQuestao> Questoes;
        //private string _batteryPct;
        //private long _duration;
        //private long _finish;
        //private int _id;
        //private string _lat;
        //private string _lng;

        //#region Getters
        //public string getBatteryPct()
        //{
        //    return _batteryPct;
        //}

        //public long getFinish()
        //{
        //    return _finish;
        //}

        //public long getDuration()
        //{
        //    return _duration;
        //}


        //#endregion

        //#region Setters
        //public void setBatteryPct(string batteryPct)
        //{
        //    _batteryPct = batteryPct;
        //}

        //public void setFinish(long finish)
        //{
        //    _finish = finish;
        //}

        //public void setDuration(long duration)
        //{
        //    _duration = duration;
        //}
        //#endregion
    }
}