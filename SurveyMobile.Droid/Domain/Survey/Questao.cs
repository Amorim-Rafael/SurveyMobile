using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SurveyMobile.Droid.Domain.Survey
{
    [Serializable]
    public class Questao : ISerializable
    {
        private int _questaoId { get; set; }
        private string _titulo { get; set; }
        private int _tipoQuestao { get; set; }
        private int _tipoResposta { get; set; }
        private int _grupoQuestaoId { get; set; }
        private List<Resposta> _respostas { get; set; }

        public int getQuestaoId() { return _questaoId; }
        public string getTitulo() { return _titulo; }
        public int getTipoQuestao() { return _tipoQuestao; }
        public int getTipoResposta() { return _tipoResposta; }
        public int getGrupoQuestaoId() { return _grupoQuestaoId; }
        public List<Resposta> getRespostas() { return _respostas; }

        public void setQuestaoId(int id) { _questaoId = id; }
        public void setTitulo(string titulo) { _titulo = titulo; }
        public void setTipoQuestao(int tipoQuestao) { _tipoQuestao = tipoQuestao; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }
}