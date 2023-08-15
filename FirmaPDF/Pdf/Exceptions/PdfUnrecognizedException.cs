using System;

namespace Nekdu.FirmaPDF.Pdf.Exceptions
{
    public class PdfUnrecognizedException : Exception
    {
        public PdfUnrecognizedException() { }
        public PdfUnrecognizedException(string message) : base(message) { }

        public PdfUnrecognizedException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
