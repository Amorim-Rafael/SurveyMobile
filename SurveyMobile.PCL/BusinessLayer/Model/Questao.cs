using System.Collections.Generic;

namespace SurveyMobile.PCL.BusinessLayer.Model
{
    public class Questao
    {
        public int QuestaoId { get; set; }
        public bool Required { get; set; }
        public string Titulo { get; set; }
        public int TipoQuestao { get; set; }
        public int TipoResposta { get; set; }
        public int GrupoQuestaoId { get; set; }
        public List<Resposta> Respostas { get; set; }
    }
}
