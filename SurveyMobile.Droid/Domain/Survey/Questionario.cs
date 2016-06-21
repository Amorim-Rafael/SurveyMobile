using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SurveyMobile.Droid.Domain.Survey
{
    [Serializable]
    public class Questionario : ISerializable
    {
        //private int _questionarioId { get; set; }
        //private string _descricao { get; set; }
        //private List<Questao> _questoes { get; set; }
        public int QuestionarioId { get; set; }
        public string Descricao { get; set; }
        public List<Questao> Questoes { get; set; }

        public void setQuestoes(List<Questionario> questionario)
        {
            foreach (var item in questionario)
            {
                //_questoes.Add(item.)
                //_questionarioId = item._questionarioId;
                //_descricao = item._descricao;
                //_questoes = item._questoes;
            }
        }


        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("questionarioId", QuestionarioId);
            info.AddValue("descricao", Descricao);
            info.AddValue("questoes", Questoes.ToArray());
        }
    }
}