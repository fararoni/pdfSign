using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nekdu.FirmaPDF.Crypto.Exceptions
{
    public class CertificadoMismatchException: Exception
    {
        public CertificadoMismatchException() { }
        public CertificadoMismatchException(string message) : base(message) { }

        public CertificadoMismatchException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
