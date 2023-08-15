using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nekdu.FirmaPDF.Pdf.Exceptions
{
    public class PdfAlreadySignedByException : Exception
    {
        public PdfAlreadySignedByException() { }
        public PdfAlreadySignedByException(string message) : base(message) { }

        public PdfAlreadySignedByException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
