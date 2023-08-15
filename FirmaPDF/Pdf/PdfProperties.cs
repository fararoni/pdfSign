using Nekdu.FirmaPDF.Crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nekdu.FirmaPDF.Pdf
{
    public class PdfProperties
    {
        public Certificado certificado { get; set; }
        public string pathFilePdfSrc { get; set; }
        public string pathFilePdfDest { get; set; }
        public string reason { get; set; }
        public string location { get; set; }
        public string component { get; set; }
        public string version { get; set; }
        public string actionLabel { get; set; }
        public string tsaUrl { get; set; }
    }
}
