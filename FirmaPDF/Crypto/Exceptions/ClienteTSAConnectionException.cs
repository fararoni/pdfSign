using System;

namespace Nekdu.FirmaPDF.Crypto.Exceptions
{
    public class ClienteTSAConnectionException: Exception
    {
        public ClienteTSAConnectionException() { }
        public ClienteTSAConnectionException(string message) : base(message) { }

        public ClienteTSAConnectionException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
