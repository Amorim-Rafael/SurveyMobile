using System.Collections.Generic;

namespace SurveyMobile.PCL.BusinessLayer.Model
{
    public class Questionario
    {
        public int QuestionarioId { get; set; }
        public string Descricao { get; set; }
        public List<Questao> Questoes { get; set; }
    }
}
