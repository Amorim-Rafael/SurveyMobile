using System;
using System.Runtime.Serialization;

namespace SurveyMobile.Droid.Domain.Survey
{
    [Serializable]
    public class Regra : ISerializable
    {
        public int RegraId { get; set; }
        public int QuestaoId { get; set; }
        public virtual Questao Questao { get; set; }
        public int[] Opcoes { get; set; }
        public string Operador { get; set; }
        public int Compativel { get; set; }
        //private int _regraId { get; set; }
        //private int _questaoId { get; set; }
        //private Questao _questao { get; set; }
        //private string[] _opcoes { get; set; }
        //private string _operador { get; set; }


        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }
}