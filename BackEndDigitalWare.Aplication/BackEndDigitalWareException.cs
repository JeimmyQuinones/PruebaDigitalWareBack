using System;
using System.Runtime.Serialization;

namespace BackEndDigitalWare.Aplication
{
    [Serializable]
    public class BackEndDigitalWareException:Exception
    {
        protected BackEndDigitalWareException(SerializationInfo info, StreamingContext context): base(info, context) { }
        public BackEndDigitalWareException (string message) : base(message) { }
    }
}
