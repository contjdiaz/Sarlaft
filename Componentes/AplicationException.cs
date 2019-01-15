using System;
using System.Runtime.Serialization;

namespace Componentes
{
    public class AplicationException : Exception, ISerializable
    {
        public AplicationException() { }
        public AplicationException(string Mensaje) : base(Mensaje) { }
        public AplicationException(string Mensaje, Exception inner) : base(Mensaje, inner) { }
        protected AplicationException(SerializationInfo Info, StreamingContext Contexto) : base(Info, Contexto) { }

    }
}
