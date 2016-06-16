using System;
using System.Runtime.Serialization;

namespace SurveyMobile.Droid.Domain.Survey
{
    [Serializable]
    public class Regra : ISerializable
    {
        private int _regraId { get; set; }
        private int _questaoId { get; set; }
        private Questao _questao { get; set; }
        private string[] _opcoes { get; set; }
        private string _operador { get; set; }


        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }
}