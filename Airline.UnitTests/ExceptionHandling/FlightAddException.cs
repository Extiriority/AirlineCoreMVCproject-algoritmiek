using System;
using System.Runtime.Serialization;

namespace Airline.UnitTests.Airline.UnitTests
{
    [Serializable]
    internal class FlightAddException : Exception
    {
        public FlightAddException()
        {
        }

        public FlightAddException(string message) : base(message)
        {
        }

        public FlightAddException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FlightAddException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}