using System;
using System.Runtime.Serialization;

namespace SurveyMobile.Droid.Domain.Survey
{
    [Serializable]
    public class Resposta : ISerializable
    {
        public int RespostaId { get; set; }
        public string Descricao { get; set; }
        //private int _respostaId { get; set; }
        //private string _descricao { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }
}