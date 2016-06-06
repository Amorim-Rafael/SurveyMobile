using System.Collections.Generic;

namespace SurveyMobile.PCL.BusinessLayer.Model
{
    public class Equipe
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public ICollection<Pesquisador> Pesquisadores { get; set; }
    }
}
