using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyMobile.PCL.BusinessLayer.Model
{
    public class Regra
    {
        public int RegraId { get; set; }        
        public int QuestaoId { get; set; }
        public virtual Questao Questao { get; set; }
        public string[] Opcoes { get; set; }
        public string Operador { get; set; }
    }
}
