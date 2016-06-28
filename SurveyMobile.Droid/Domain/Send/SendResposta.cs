using System;
using System.Runtime.Serialization;

namespace SurveyMobile.Droid.Domain.Send
{
    [Serializable]
    public class SendResposta : ISerializable
    {
        public int RespostaId { get; set; }
        public string Descricao { get; set; }
        public int GridPosition { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }
}