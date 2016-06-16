using System.Collections.Generic;

namespace SurveyMobile.PCL.BusinessLayer.Model
{
    class Logica
    {
        public int LogicaId { get; set; }
        public string Acao { get; set; }
        public List<Regra> Regras { get; set; }
    }
}
