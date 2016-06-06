namespace SurveyMobile.PCL.BusinessLayer.Model
{
    public class Pesquisa
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public int EquipeId { get; set; }
        public virtual Equipe Equipe { get; set; }
    }
}
