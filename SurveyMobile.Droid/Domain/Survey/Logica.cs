using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SurveyMobile.Droid.Domain.Survey
{
    [Serializable]
    public class Logica : ISerializable
    {
        public int LogicaId { get; set; }
        public string Acao { get; set; }
        public List<Regra> Regras { get; set; }
        //private int _logicaId { get; set; }
        //private string _acao { get; set; }
        //private List<Regra> _regras { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }
}