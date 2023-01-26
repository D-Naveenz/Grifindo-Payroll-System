using System;
using System.Runtime.Serialization;

namespace GrifindoPS.Exceptions
{
    [Serializable]
    internal class InvalidCycleException : Exception
    {
        private DateTime value;
        private DateTime cycleEnd;

        public InvalidCycleException()
        {
        }

        public InvalidCycleException(string? message) : base(message)
        {
        }

        public InvalidCycleException(DateTime value, DateTime cycleEnd)
        {
            this.value = value;
            this.cycleEnd = cycleEnd;
        }

        public InvalidCycleException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidCycleException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}