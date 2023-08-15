using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nekdu.FirmaPDF.Crypto.Exceptions
{
    public class CertificadoException : Exception
    {
        public CertificadoException() { }
        public CertificadoException(string message)
           : base(message)
        {
        }
        public CertificadoException(Exception innerException)
            : base("CertificadoException", innerException)
        {
        }
      }
}