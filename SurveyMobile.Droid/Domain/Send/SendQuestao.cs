using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SurveyMobile.Droid.Domain.Send
{
    [Serializable]
    public class SendQuestao : ISerializable
    {
        public int Id { get; set; }
        public List<SendResposta> Respostas { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }
}