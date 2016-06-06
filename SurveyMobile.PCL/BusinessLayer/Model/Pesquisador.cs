namespace SurveyMobile.PCL.BusinessLayer.Model
{
    public class Pesquisador
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public int PapelId { get; set; }
        public virtual Papel Papel  { get; set; }
    }
}
