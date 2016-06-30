using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SurveyMobile.Droid.Domain.Survey
{
    [Serializable]
    public class Questao : ISerializable
    {
        public int QuestaoId { get; set; }
        public string Titulo { get; set; }
        public int TipoQuestao { get; set; }
        public int TipoResposta { get; set; }
        public int GrupoQuestaoId { get; set; }
        public List<Resposta> Respostas { get; set; }
        public bool Obrigatoria { get; set; }
        //private int _questaoId { get; set; }
        //private string _titulo { get; set; }
        //private int _tipoQuestao { get; set; }
        //private int _tipoResposta { get; set; }
        //private int _grupoQuestaoId { get; set; }
        ////private List<Resposta> _respostas { get; set; }
        //private Resposta _resposta { get; set; }

        public int getQuestaoId() { return QuestaoId; }
        public string getTitulo() { return Titulo; }
        public int getTipoQuestao() { return TipoQuestao; }
        public int getTipoResposta() { return TipoResposta; }
        public int getGrupoQuestaoId() { return GrupoQuestaoId; }
        //public List<Resposta> getRespostas() { return _respostas; }
        public List<Resposta> getResposta() { return Respostas; }

        //public int getQuestaoId() { return _questaoId; }
        //public string getTitulo() { return _titulo; }
        //public int getTipoQuestao() { return _tipoQuestao; }
        //public int getTipoResposta() { return _tipoResposta; }
        //public int getGrupoQuestaoId() { return _grupoQuestaoId; }
        ////public List<Resposta> getRespostas() { return _respostas; }
        //public Resposta getResposta() { return _resposta; }

        public void setQuestaoId(int id) { QuestaoId = id; }
        public void setTitulo(string titulo) { Titulo = titulo; }
        public void setTipoQuestao(int tipoQuestao) { TipoQuestao = tipoQuestao; }

        //public void setQuestaoId(int id) { _questaoId = id; }
        //public void setTitulo(string titulo) { _titulo = titulo; }
        //public void setTipoQuestao(int tipoQuestao) { _tipoQuestao = tipoQuestao; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }
}