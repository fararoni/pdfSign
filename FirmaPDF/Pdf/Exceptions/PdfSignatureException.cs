using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nekdu.FirmaPDF.Pdf.Exceptions
{
    public class PdfSignatureException : Exception
    {
        public PdfSignatureException() { }
        public PdfSignatureException(string message) : base(message) { }

        public PdfSignatureException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
